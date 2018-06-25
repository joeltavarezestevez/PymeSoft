using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace PymeSoft.Inventario
{
    public partial class frmRegistroItemsdeVenta : Form
    {
        public frmRegistroItemsdeVenta()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        int mayor = 0;
        int menor = 0;

        String SQL = "  SELECT " +
                        "  productos.id AS Id," +
                          "productos.producto_nombre AS Nombre," +
                          "productos.producto_referencia AS Referencia," +
                          "productos.producto_costo AS Costo," +
                          "productos.producto_precio AS Precio," +
                          "suplidores.suplidor_nombre AS Suplidor," +
                          "tipos_productos.tipo_producto_nombre AS Tipo," +
                          "productos.producto_existencia AS Existencia" +
                     " FROM " +
                          "public.productos INNER JOIN public.suplidores ON public.productos.suplidor_id = public.suplidores.id " +
                          "INNER JOIN public.tipos_productos ON public.productos.tipo_producto_id = public.tipos_productos.id ";
        String query = "";
        /********************************************************************************
         *                              LlenarDatagridView()                            *
         *                                       -                                      *
         * Metodo para seleccionar y mostrar los datos de una tabla de la BD en un DGV  *
         ********************************************************************************/
        private void LlenarDataGridView()
        {
            try
            {

                conexion.consultar(SQL, "Productos");
                dgvProductosTerminados.DataSource = conexion.ds.Tables["Productos"];
                dgvProductosTerminados.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxSuplidores()
        {
            //Llenamos el combobox cmbSuplidor con los registros que hay en la tabla suplidores
            try
            {
                cmbSuplidor.DataSource = conexion.llenarComboBox("proveedores", "suplidor_nombre");
                cmbSuplidor.DisplayMember = "suplidor_nombre";
                cmbSuplidor.ValueMember = "id";
                cmbSuplidor.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxSuplidores", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxTiposProductos()
        {
            //Llenamos el combobox cmbTipoProducto con los registros que hay en la tabla tipos_productos
            try
            {
                cmbTipoProducto.DataSource = conexion.llenarComboBox("tipos_productos", "tipo_producto_nombre");
                cmbTipoProducto.DisplayMember = "tipo_producto_nombre";
                cmbTipoProducto.ValueMember = "id";
                cmbTipoProducto.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxTiposProductos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                conexion.conexion.Close();
            }
        }

        private void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    Limpiar(c);
                }

                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }

                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).ResetText();
                    ((ComboBox)c).SelectedValue = 0;
                    ((ComboBox)c).SelectedIndex = -1;
                    ((ComboBox)c).SelectedItem = "";
                }
            }

            dataGridView2.Rows.Clear();
            lblFechaRegistro.Text = lblUltimaVenta.Text = "-";
            lblExistencia.Text = "0.00";
            btnRegistroAnterior.Enabled = btnRegistroSiguiente.Enabled = false;
        }
        /********************************************************************************
         *                              BuscarRegistroMayoryMenor()                      *
         *                                     -                                         *
         *     Metodo para seleccionar y extraer el primer y el ultimo registro de la BD *
         ********************************************************************************/
        private void BuscarRegistroMayoryMenor()
        {
            try
            {
                //Para extraer los datos del registro seleccionado en la base de datos
                MySqlDataReader LectorClientes;
                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();
                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();
                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;
                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select max(id), min(id) From productos";
                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();
                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    mayor = LectorClientes.GetInt32(0);
                    menor = LectorClientes.GetInt32(1);
                }
                //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                LectorClientes.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - BuscarRegistroMayoryMenor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                conexion.conexion.Close();
            }
        }
        /********************************************************************************
         *                              BuscarRegistro()                                *
         *                                     -                                        *
         *     Metodo para seleccionar y extraer los datos de un registro de la BD      *
         ********************************************************************************/
        private void BuscarRegistro()
        {
            try
            {
                //Para extraer los datos del registro seleccionado en la base de datos
                MySqlDataReader LectorClientes;

                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();

                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select * From Productos where id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    txtDenominacion.Text = LectorClientes.GetString(1);
                    txtReferencia.Text = LectorClientes.GetString(2).ToString();
                    txtCodigoBarra.Text = LectorClientes.GetString(3).ToString();
                    txtCosto.Text = LectorClientes.GetDecimal(4).ToString();
                    txtPrecioVenta.Text = LectorClientes.GetDecimal(5).ToString();
                    txtDescripcion.Text = LectorClientes.GetString(6).ToString();
                    txtMesesGarantia.Text = LectorClientes.GetInt32(7).ToString();
                    txtDiasEntrega.Text = LectorClientes.GetInt32(8).ToString();
                    chkBloqueado.Checked = LectorClientes.GetBoolean(9);
                    chkITBIS.Checked = LectorClientes.GetBoolean(10);
                    chkProductoInventario.Checked = LectorClientes.GetBoolean(11);
                    lblExistencia.Text = LectorClientes.GetDecimal(12).ToString();
                    lblFechaRegistro.Text = LectorClientes.GetDateTime(13).ToShortDateString();
                    lblUltimaVenta.Text = LectorClientes.GetDateTime(14).ToShortDateString();
                    cmbTipoProducto.SelectedValue = LectorClientes.GetInt32(15);
                    cmbSuplidor.SelectedValue = LectorClientes.GetInt32(16);
                    if (LectorClientes.GetString(17).Length > 0)
                    {
                        pbxProducto.Image = Image.FromFile(LectorClientes.GetString(17));
                        pbxProducto.ImageLocation = LectorClientes.GetString(17);
                    }
                    btnRegistroAnterior.Enabled = btnRegistroSiguiente.Enabled = true;
                }
                //De lo contrario, si no se encontró ningun registro, Enviamos un mensaje al usuario.
                else
                {
                    MessageBox.Show("No existe un registro con este código, verifique y trate de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Limpiar(this);
                    return;
                }

                //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                LectorClientes.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - BuscarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                conexion.conexion.Close();
            }
        }

        /********************************************************************************
         *                              ValidarCamposNumericos()                        *
         *                                        -                                     *
         *       Metodo que permite validar si la tecla pulsada es un numero o no       *
         ********************************************************************************/
        private bool ValidarCamposNumericos(char caracter)
        {
            if ((caracter >= 48 && caracter <= 57) || (caracter == 8))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /********************************************************************************
         *                     ValidarCamposNumericosDecimales()                        *
         *                                     -                                        *
         *    Metodo que permite validar si la tecla pulsada es un numero/punto o no    *
         ********************************************************************************/
        private bool ValidarCamposNumericosDecimales(char caracter)
        {
            if ((caracter >= 48 && caracter <= 57) || (caracter == 8) || caracter == 46)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmRegistroClientes_Load(object sender, EventArgs e)
        {
            LlenarDataGridView();
            BuscarRegistroMayoryMenor();
            LLenarComboBoxTiposProductos();
            LLenarComboBoxSuplidores();
            cmbSuplidor.SelectedIndex = cmbTipoProducto.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTipoProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un tipo de producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbSuplidor.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un suplidor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (string.IsNullOrEmpty(txtMesesGarantia.Text))
            {
                txtMesesGarantia.Text = "0";
            }

            if (string.IsNullOrEmpty(txtDiasEntrega.Text))
            {
                txtDiasEntrega.Text = "0";
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                string tabla = "productos";
                string campos = "producto_nombre, producto_referencia, producto_codigo_barra, producto_costo, producto_precio, producto_descripcion, " +
                                "producto_meses_garantia, producto_dias_entrega, producto_bloqueado, producto_itbis, producto_inventario, " +
                                "tipo_producto_id, suplidor_id, producto_imagen";
                string valores = "'" + txtDenominacion.Text.Trim() + "', '" + txtReferencia.Text.Trim() + "', '" + txtCodigoBarra.Text.Trim() + "'," +
                                  "'" + txtCosto.Text.Trim() + "', '" + txtPrecioVenta.Text.Trim() + "', '" + txtDescripcion.Text.Trim() + "'," +
                                  "'" + txtMesesGarantia.Text.Trim() + "', '" + txtDiasEntrega.Text.Trim() + "', '" + chkBloqueado.Checked + "'," +
                                  "'" + chkITBIS.Checked + "', '" + chkProductoInventario.Checked + "', '" + cmbTipoProducto.SelectedValue + "'," +
                                  "'" + cmbSuplidor.SelectedValue + "', '" + pbxProducto.ImageLocation + "'";
                if (conexion.insertarRegistro(tabla, campos, valores))
                {
                    MessageBox.Show("Registro Insertado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar(this);
                    LlenarDataGridView();
                }
                else
                {
                    MessageBox.Show("Error al insertar registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                string campos = " producto_nombre            = '" + txtDenominacion.Text.Trim() + "'," +
                                " producto_referencia        = '" + txtReferencia.Text.Trim() + "'," +
                                " producto_codigo_barra      = '" + txtCodigoBarra.Text.Trim() + "'," +
                                " producto_costo             = '" + txtCosto.Text.Trim() + "'," +
                                " producto_precio            = '" + txtPrecioVenta.Text.Trim() + "'," +
                                " producto_descripcion       = '" + txtDescripcion.Text.Trim() + "'," +
                                " producto_meses_garantia    = '" + txtMesesGarantia.Text.Trim() + "'," +
                                " producto_dias_entrega      = '" + txtDiasEntrega.Text.Trim() + "'," +
                                " producto_bloqueado         = '" + chkBloqueado.Checked + "'," +
                                " producto_itbis             = '" + chkITBIS.Checked + "'," +
                                " producto_inventario        = '" + chkProductoInventario.Checked + "'," +
                                " tipo_producto_id           = '" + cmbTipoProducto.SelectedValue + "'," +
                                " suplidor_id                = '" + cmbSuplidor.SelectedValue + "'," +
                                " producto_imagen            = '" + pbxProducto.ImageLocation + "'";
                string tabla = "productos";
                string condicion = " id =" + txtCodigo.Text;
                if (conexion.actualizarRegistro(tabla, campos, condicion))
                {
                    MessageBox.Show("Registro Actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar(this);
                    LlenarDataGridView();

                }
                else
                {
                    MessageBox.Show("Error al actualizar el registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
        }
        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                BuscarRegistro();
            }
            else
            {
                Limpiar(this);
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(this);
            txtDenominacion.Focus();
        }

        private void dgvProductosTerminados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProductosTerminados.Rows.Count > 0)
            {
                txtCodigo.Text = dgvProductosTerminados[0, dgvProductosTerminados.SelectedCells[0].RowIndex].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                DialogResult d = MessageBox.Show("Está seguro que desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        conexion.eliminarRegistro("productos", "id=" + txtCodigo.Text);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Este producto no puede ser eliminado porque tiene registros dependientes (Facturas, Compras, Devoluciones, etc.)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                    finally
                    {
                        conexion.conexion.Close();
                    }

                    Limpiar(this);
                    LlenarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("No hay un producto seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbDescripción_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbTipo_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void TxtCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            query = "";
            if (e.KeyChar == 13)
            {
                if (rdbCodigo.Checked == false && rdbDenominacion.Checked == false && rdbReferencia.Checked == false)
                {
                    MessageBox.Show("Elija un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (rdbCodigo.Checked == true && txtCriterio.Text.Length > 0)
                    {
                        try
                        {
                            query = SQL + " where public.productos.id = '" + txtCriterio.Text.Trim() + "'";

                            conexion.consultar(query, "productos");
                            dgvProductosTerminados.DataSource = conexion.ds.Tables["productos"];
                            dgvProductosTerminados.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbDenominacion.Checked == true)
                    {
                        try
                        {
                            query = SQL + " where public.productos.producto_nombre ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "productos");
                            dgvProductosTerminados.DataSource = conexion.ds.Tables["productos"];
                            dgvProductosTerminados.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbReferencia.Checked == true)
                    {
                        try
                        {
                            query = SQL + " where public.productos.producto_referencia ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "productos");
                            dgvProductosTerminados.DataSource = conexion.ds.Tables["productos"];
                            dgvProductosTerminados.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            conexion.consultar(SQL, "productos");
                            dgvProductosTerminados.DataSource = conexion.ds.Tables["productos"];
                            dgvProductosTerminados.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }
                e.Handled = true;
            }
        }

        private void btnRegistroAnterior_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                int codigoanterior = int.Parse(txtCodigo.Text) - 1;

                if (codigoanterior >= menor)
                {
                    txtCodigo.Text = codigoanterior.ToString();
                }
            }
        }

        private void btnRegistroSiguiente_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                int codigosiguiente = int.Parse(txtCodigo.Text) + 1;

                if (codigosiguiente <= mayor)
                {
                    txtCodigo.Text = codigosiguiente.ToString();
                }
            }
        }

        private void txtMesesGarantia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericos(e.KeyChar);
        }

        private void txtDiasEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericos(e.KeyChar);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericosDecimales(e.KeyChar);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericosDecimales(e.KeyChar);
        }
    }
}
