using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace PymeSoft
{
    public partial class frmRegistroClientes : Form
    {

        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionSQL conexion = new ConexionSQL();
        int mayor = 0;
        int menor = 0;

        String SQL = "  SELECT " + 
                        "  clientes.id AS Id," + 
                          "clientes.cliente_nombre AS Nombre," + 
                          "clientes.cliente_identificacion AS Identificación," + 
                          "clientes.cliente_telefono AS Teléfono," + 
                          "vendedores.vendedor_nombre AS Vendedor," + 
                          "clientes.cliente_balance AS Balance" +
                     " FROM " +
                          "public.clientes INNER JOIN public.vendedores ON public.clientes.vendedor_id = public.vendedores.id ";
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

                conexion.consultar(SQL, "Clientes");
                dgvClientes.DataSource = conexion.ds.Tables["Clientes"];
                dgvClientes.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxMunicipios(int id)
        {
            //Llenamos el combobox cmbMunicipios con los registros que hay en la tabla municipios
            try
            {
                cmbMunicipios.DataSource = conexion.LlenarComboBox("municipios", "municipio_nombre","provincia_id = " + id);
                cmbMunicipios.DisplayMember = "municipio_nombre";
                cmbMunicipios.ValueMember = "id";
                cmbMunicipios.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxMunicipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxProvincias()
        {
            //Llenamos el combobox cmbProvincias con los registros que hay en la tabla provincias
            try
            {
                cmbProvincias.DataSource = conexion.LlenarComboBox("provincias", "provincia_nombre");
                cmbProvincias.DisplayMember = "provincia_nombre";
                cmbProvincias.ValueMember = "id";
                cmbProvincias.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxProvincias", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                conexion.conn.Close();
            }
        }

        private void LLenarComboBoxVendedores()
        {
            //Llenamos el combobox cmbVendedores con los registros que hay en la tabla vendedores
            try
            {
                cmbVendedores.DataSource = conexion.LlenarComboBox("vendedores", "vendedor_nombre");
                cmbVendedores.DisplayMember = "vendedor_nombre";
                cmbVendedores.ValueMember = "id";
                cmbVendedores.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarComboBoxVendedores", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxFormasPagos()
        {
            //Llenamos el combobox cmbFormasPagos con los registros que hay en la tabla formas_pagos
            try
            {
                cmbFormasPagos.DataSource = conexion.LlenarComboBox("formas_pagos", "forma_pago_nombre");
                cmbFormasPagos.DisplayMember = "forma_pago_nombre";
                cmbFormasPagos.ValueMember = "id";
                cmbFormasPagos.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarComboBoxFormasPagos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxTiposClientes()
        {
            //Llenamos el combobox cmbTiposClientes con los registros que hay en la tabla tipos_clientes
            try
            {
                cmbListaPrecios.DataSource = conexion.LlenarComboBox("tipos_clientes", "tipo_cliente_nombre");
                cmbListaPrecios.DisplayMember = "tipo_cliente_nombre";
                cmbListaPrecios.ValueMember = "id";
                cmbListaPrecios.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarComboBoxTiposClientes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

            dgvContactos.Rows.Clear();
            lblFechaRegistro.Text = lblUtimaVenta.Text = "-";
            lblBalancePendiente.Text = "0.00";
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
                NpgsqlDataReader LectorClientes;
                //Abrimos la conexion hacia la BD
                conexion.conn.Open();
                //Creamos una instruccion o comando SQL
                NpgsqlCommand Comando = new NpgsqlCommand();
                //Le asignamos la conexion actual
                Comando.Connection = conexion.conn;
                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select max(id), min(id) From Clientes";
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
                conexion.conn.Close();
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
                NpgsqlDataReader LectorClientes;

                //Abrimos la conexion hacia la BD
                conexion.conn.Open();

                //Creamos una instruccion o comando SQL
                NpgsqlCommand Comando = new NpgsqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conn;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select * From Clientes where id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    txtNombre.Text = LectorClientes.GetString(1);
                    txtIdentificacion.Text = LectorClientes.GetString(2).ToString();
                    txtDireccion.Text = LectorClientes.GetString(3).ToString();
                    txtTelefono1.Text = LectorClientes.GetString(4).ToString();
                    txtFax.Text = LectorClientes.GetString(5).ToString();
                    txtCorreoElectronico.Text = LectorClientes.GetString(6).ToString();
                    txtPaginaWeb.Text = LectorClientes.GetString(7).ToString();
                    txtObservaciones.Text = LectorClientes.GetString(8).ToString();
                    lblUtimaVenta.Text = LectorClientes.GetDateTime(9).ToShortDateString();
                    lblBalancePendiente.Text = LectorClientes.GetDecimal(10).ToString();
                    txtLimiteCredito.Text = LectorClientes.GetDecimal(11).ToString();
                    txtDescuento.Text = LectorClientes.GetInt32(12).ToString();
                    chkBloqueado.Checked = LectorClientes.GetBoolean(13);
                    cmbProvincias.SelectedValue = LectorClientes.GetInt32(14);
                    cmbProvincias_SelectionChangeCommitted(null,null);
                    cmbMunicipios.SelectedValue = LectorClientes.GetInt32(15);
                    cmbVendedores.SelectedValue = LectorClientes.GetInt32(16);
                    cmbFormasPagos.SelectedValue = LectorClientes.GetInt32(17);
                    cmbListaPrecios.SelectedValue = LectorClientes.GetInt32(18);
                    lblFechaRegistro.Text = LectorClientes.GetDateTime(19).ToShortDateString();
                    if (LectorClientes.GetString(20).Length > 0)
                    {
                        pbxCliente.Image = Image.FromFile(LectorClientes.GetString(20));
                        pbxCliente.ImageLocation = LectorClientes.GetString(20);
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
                conexion.conn.Close();
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
            LLenarComboBoxProvincias();
            LLenarComboBoxVendedores();
            LLenarComboBoxFormasPagos();
            LLenarComboBoxTiposClientes();
            cmbFormasPagos.SelectedIndex = cmbMunicipios.SelectedIndex = cmbProvincias.SelectedIndex = cmbListaPrecios.SelectedIndex = cmbVendedores.SelectedIndex = -1;
        }

        private void cmbProvincias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LLenarComboBoxMunicipios(int.Parse(cmbProvincias.SelectedValue.ToString()));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProvincias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar una provincia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbMunicipios.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un municipio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbVendedores.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbFormasPagos.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar una forma de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbListaPrecios.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un tipo de cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (string.IsNullOrEmpty(txtDescuento.Text))
            {
                txtDescuento.Text = "0";
            }

            if (string.IsNullOrEmpty(txtLimiteCredito.Text))
            {
                txtLimiteCredito.Text = "0";
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {

                string sql = "insert into Clientes ( Cliente_Nombre, Cliente_Identificacion, Cliente_Direccion, Cliente_Telefono,"   +
                                                   " Cliente_Fax, Cliente_Correo_Electronico, Cliente_Pagina_Web, Cliente_Observaciones, Cliente_Limite_Credito," + 
                                                   " Cliente_Descuento, Cliente_Bloqueado, Provincia_Id, Municipio_Id, Forma_Pago_Id, Tipo_Cliente_Id, Vendedor_Id, cliente_imagen)" +
                                                   " values " +
                                                   " ('" + txtNombre.Text.Trim() + "', '" + txtIdentificacion.Text.Trim() + "', '" + txtDireccion.Text.Trim() + "'," +
                                                   " '" + txtTelefono1.Text.Trim() + "', '" + txtFax.Text.Trim() + "', '" + txtCorreoElectronico.Text.Trim() + "'," +
                                                   " '" + txtPaginaWeb.Text.Trim() + "', '" + txtObservaciones.Text.Trim() + "', '" + txtLimiteCredito.Text.Trim() + "'," +
                                                   " '" + txtDescuento.Text.Trim() + "', '" + chkBloqueado.Checked + "', '" + cmbProvincias.SelectedValue + "'," +
                                                   " '" + cmbMunicipios.SelectedValue + "', '" + cmbFormasPagos.SelectedValue + "', '" + cmbListaPrecios.SelectedValue + "'," +
                                                   " '" + cmbVendedores.SelectedValue + "', '" + pbxCliente.ImageLocation + "')";
                if (conexion.insertar(sql))
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
                string campos = " cliente_nombre             = '" + txtNombre.Text.Trim() + "'," +
                                " cliente_identificacion     = '" + txtIdentificacion.Text.Trim() + "'," + 
                                " cliente_direccion          = '" + txtDireccion.Text.Trim() + "'," +
                                " cliente_telefono           = '" + txtTelefono1.Text.Trim() + "'," +
                                " cliente_fax                = '" + txtFax.Text.Trim() + "'," + 
                                " cliente_correo_electronico = '" + txtCorreoElectronico.Text.Trim() + "'," + 
                                " cliente_pagina_web         = '" + txtPaginaWeb.Text.Trim() + "'," + 
                                " cliente_observaciones      = '" + txtObservaciones .Text.Trim() + "'," + 
                                " cliente_limite_credito     = '" + txtLimiteCredito.Text.Trim() + "'," +
                                " cliente_descuento          = '" + txtDescuento.Text.Trim() + "'," + 
                                " cliente_bloqueado          = '" + chkBloqueado.Checked + "'," +
                                " provincia_id               = '" + cmbProvincias.SelectedValue + "'," +
                                " municipio_id               = '" + cmbMunicipios.SelectedValue + "'," +
                                " vendedor_id                = '" + cmbVendedores.SelectedValue + "'," +
                                " forma_pago_id              = '" + cmbFormasPagos.SelectedValue + "'," +
                                " tipo_cliente_id            = '" + cmbListaPrecios.SelectedValue + "'," +
                                " cliente_imagen             = '" + pbxCliente.ImageLocation + "'";
                string tabla = "Clientes";
                string condicion = " id =" + txtCodigo.Text;
                if (conexion.actualizar(tabla, campos, condicion))
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

        private void dgvContactos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /*if (e.RowIndex == dgvContactos.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvContactos.Columns["btnEliminar"].Index)
            {
                var image = Properties.Resources.Delete_icon1; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));

                e.Handled = true;
            }*/
        }

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dgvContactos.NewRowIndex || e.RowIndex < 0)
                 
            //Check if click is on specific column 
            if (e.ColumnIndex == dgvContactos.Columns["btnEliminar"].Index)
            {
                //Put some logic here, for example to remove row from your binding list.
                dgvContactos.Rows.RemoveAt(e.RowIndex);
            }
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
            txtNombre.Focus();
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                txtCodigo.Text = dgvClientes[0, dgvClientes.SelectedCells[0].RowIndex].Value.ToString();
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
                        conexion.eliminar("Clientes", "id=" + txtCodigo.Text);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Este cliente no puede ser eliminado porque tiene registros dependientes (Facturas, Pagos, Devoluciones, etc.)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                    finally
                    {
                        conexion.conn.Close();
                    }

                    Limpiar(this);
                    LlenarDataGridView();
                }
            }
            else
            {
                MessageBox.Show("No hay un cliente seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericosDecimales(e.KeyChar);
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidarCamposNumericos(e.KeyChar);
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
                if (rdbCodigo.Checked == false && rdbNombre.Checked == false && rdbIdentificacion.Checked == false && rdbVendedor.Checked == false)
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
                            query = SQL + " where public.clientes.id = '" + txtCriterio.Text.Trim() + "'";

                            conexion.consultar(query, "clientes");
                            dgvClientes.DataSource = conexion.ds.Tables["clientes"];
                            dgvClientes.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbNombre.Checked == true)
                    {
                        try
                        {
                            query = SQL + " where public.clientes.cliente_nombre ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "Clientes");
                            dgvClientes.DataSource = conexion.ds.Tables["Clientes"];
                            dgvClientes.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbIdentificacion.Checked == true)
                    {
                        try
                        {
                            query = SQL + " where public.clientes.cliente_identificacion ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "Clientes");
                            dgvClientes.DataSource = conexion.ds.Tables["Clientes"];
                            dgvClientes.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbVendedor.Checked == true)
                    {
                        try
                        {
                            query = SQL + " where vendedores.vendedor_nombre ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "Clientes");
                            dgvClientes.DataSource = conexion.ds.Tables["Clientes"];
                            dgvClientes.Refresh();
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
                            conexion.consultar(SQL, "clientes");
                            dgvClientes.DataSource = conexion.ds.Tables["clientes"];
                            dgvClientes.Refresh();
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
                int codigoanterior =  int.Parse(txtCodigo.Text) - 1;

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
    }

}
