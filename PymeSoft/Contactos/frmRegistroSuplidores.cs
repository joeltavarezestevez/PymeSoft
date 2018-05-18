using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace DomPlastic_ERP
{
    public partial class frmRegistroSuplidores : Form
    {

        public frmRegistroSuplidores()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionSQL conexion = new ConexionSQL();
        ConexionSQL conexion2 = new ConexionSQL();
        int mayor = 0;
        int menor = 0;

        String SQL = "  SELECT " + 
                        "  suplidores.id AS Id," + 
                          "suplidores.Suplidor_nombre AS Nombre," + 
                          "suplidores.Suplidor_identificacion AS Identificación," + 
                          "suplidores.Suplidor_telefono AS Teléfono," +
                          "suplidores.Suplidor_balance AS Balance" +
                     " FROM " +
                          "public.suplidores";
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

                conexion.consultar(SQL, "suplidores");
                dgvSuplidores.DataSource = conexion.ds.Tables["suplidores"];
                dgvSuplidores.Refresh();
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
                cmbMunicipios.DataSource = conexion2.LlenarComboBox("municipios", "municipio_nombre","provincia_id = " + id);
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
            lblFechaRegistro.Text = lblUtimaCompra.Text = "-";
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
                Comando.CommandText = "Select max(id), min(id) From suplidores";
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
                NpgsqlDataReader LectorSuplidores;

                //Abrimos la conexion hacia la BD
                conexion.conn.Open();

                //Creamos una instruccion o comando SQL
                NpgsqlCommand Comando = new NpgsqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conn;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select * From suplidores where id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorSuplidores = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorSuplidores.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    txtNombre.Text = LectorSuplidores.GetString(1);
                    txtIdentificacion.Text = LectorSuplidores.GetString(2).ToString();
                    txtDireccion.Text = LectorSuplidores.GetString(3).ToString();
                    txtTelefono.Text = LectorSuplidores.GetString(4).ToString();
                    txtFax.Text = LectorSuplidores.GetString(5).ToString();
                    txtCorreoElectronico.Text = LectorSuplidores.GetString(6).ToString();
                    txtPaginaWeb.Text = LectorSuplidores.GetString(7).ToString();
                    txtObservaciones.Text = LectorSuplidores.GetString(8).ToString();
                    lblUtimaCompra.Text = LectorSuplidores.GetDateTime(9).ToShortDateString();
                    lblBalancePendiente.Text = LectorSuplidores.GetDecimal(10).ToString();
                    chkBloqueado.Checked = LectorSuplidores.GetBoolean(11);
                    cmbProvincias.SelectedValue = LectorSuplidores.GetInt32(12);
                    cmbProvincias_SelectionChangeCommitted(null,null);
                    cmbMunicipios.SelectedValue = LectorSuplidores.GetInt32(13);
                    cmbFormasPagos.SelectedValue = LectorSuplidores.GetInt32(14);
                    lblFechaRegistro.Text = LectorSuplidores.GetDateTime(15).ToShortDateString();
                    if (LectorSuplidores.GetString(16).Length > 0)
                    {
                        pbxSuplidor.Image = Image.FromFile(LectorSuplidores.GetString(16));
                        pbxSuplidor.ImageLocation = LectorSuplidores.GetString(16);
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
                LectorSuplidores.Close();
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

        private void frmRegistrosuplidores_Load(object sender, EventArgs e)
        {
            LlenarDataGridView();
            BuscarRegistroMayoryMenor();
            LLenarComboBoxProvincias();
            LLenarComboBoxFormasPagos();
            cmbFormasPagos.SelectedIndex = cmbMunicipios.SelectedIndex = cmbProvincias.SelectedIndex = -1;
        }

        private void cmbProvincias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LLenarComboBoxMunicipios(int.Parse(cmbProvincias.SelectedValue.ToString()));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbProvincias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar una provincia", "Registro Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cmbMunicipios.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un municipio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cmbFormasPagos.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar una forma de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {

                string sql = "insert into Suplidores ( Suplidor_Nombre, Suplidor_Identificacion, Suplidor_Direccion, Suplidor_Telefono,"   +
                                                       " Suplidor_Fax, Suplidor_Correo_Electronico, Suplidor_Pagina_Web, Suplidor_Observaciones," + 
                                                       " Suplidor_Bloqueado, Provincia_Id, Municipio_Id, Forma_Pago_Id, suplidor_imagen)" +
                                                       " values " +
                                                       " ('" + txtNombre.Text.Trim() + "', '" + txtIdentificacion.Text.Trim() + "', '" + txtDireccion.Text.Trim() + "'," +
                                                       " '" + txtTelefono.Text.Trim() + "', '" + txtFax.Text.Trim() + "', '" + txtCorreoElectronico.Text.Trim() + "'," +
                                                       " '" + txtPaginaWeb.Text.Trim() + "', '" + txtObservaciones.Text.Trim() + "','" + chkBloqueado.Checked + "', " +
                                                       " '" + cmbProvincias.SelectedValue + "','" + cmbMunicipios.SelectedValue + "', '" + cmbFormasPagos.SelectedValue + "', '" + pbxSuplidor.ImageLocation + "')";
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
                string campos = " Suplidor_nombre             = '" + txtNombre.Text.Trim() + "'," +
                                " Suplidor_identificacion     = '" + txtIdentificacion.Text.Trim() + "'," +
                                " Suplidor_direccion          = '" + txtDireccion.Text.Trim() + "'," +
                                " Suplidor_telefono           = '" + txtTelefono.Text.Trim() + "'," +
                                " Suplidor_fax                = '" + txtFax.Text.Trim() + "'," +
                                " Suplidor_correo_electronico = '" + txtCorreoElectronico.Text.Trim() + "'," +
                                " Suplidor_pagina_web         = '" + txtPaginaWeb.Text.Trim() + "'," +
                                " Suplidor_observaciones      = '" + txtObservaciones.Text.Trim() + "'," +
                                " Suplidor_bloqueado          = '" + chkBloqueado.Checked + "'," +
                                " provincia_id                = '" + cmbProvincias.SelectedValue + "'," +
                                " municipio_id                = '" + cmbMunicipios.SelectedValue + "'," +
                                " forma_pago_id               = '" + cmbFormasPagos.SelectedValue + "'," +
                                " suplidor_imagen             = '" + pbxSuplidor.ImageLocation + "'";
                string tabla = "Suplidores";
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
            if (e.RowIndex == dgvContactos.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dgvContactos.Columns["btnEliminar"].Index)
            {
                var image = Properties.Resources.Delete_icon1; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));

                e.Handled = true;
            }
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

        private void dgvsuplidores_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSuplidores.Rows.Count > 0)
            {
                txtCodigo.Text = dgvSuplidores[0, dgvSuplidores.SelectedCells[0].RowIndex].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarSuplidor_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                DialogResult d = MessageBox.Show("Está seguro que desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        conexion.eliminar("suplidores", "id=" + txtCodigo.Text);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Este suplidor no puede ser eliminado porque tiene registros dependientes (Facturas, Pagos, Devoluciones, etc.)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show("No hay un suplidor seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (rdbCodigo.Checked == false && rdbNombre.Checked == false && rdbIdentificacion.Checked == false)
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
                            query = SQL + " where public.suplidores.id = " + txtCriterio.Text.Trim();
                            conexion.consultar(query, "suplidores");
                            dgvSuplidores.DataSource = conexion.ds.Tables["suplidores"];
                            dgvSuplidores.Refresh();
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
                            query = SQL + " where public.suplidores.suplidor_nombre ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "suplidores");
                            dgvSuplidores.DataSource = conexion.ds.Tables["suplidores"];
                            dgvSuplidores.Refresh();
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
                            query = SQL + " where public.suplidores.suplidor_identificacion ILIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "suplidores");
                            dgvSuplidores.DataSource = conexion.ds.Tables["suplidores"];
                            dgvSuplidores.Refresh();
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
                            conexion.consultar(SQL, "suplidores");
                            dgvSuplidores.DataSource = conexion.ds.Tables["suplidores"];
                            dgvSuplidores.Refresh();
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
    }

}
