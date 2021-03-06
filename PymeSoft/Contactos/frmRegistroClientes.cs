﻿using System;
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

namespace PymeSoft
{
    public partial class frmRegistroClientes : Form
    {

        public frmRegistroClientes()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        int mayor = 0;
        int menor = 0;
        int IdPersona = 0;
        int Bloqueado = 0;
        String rutaImagen = "";
        String tabla;
        String campos;
        String valores;
        String condicion;
        String SQL = " SELECT clientes.id as ID, personas.persona_nombre as Nombre, personas.persona_identificacion as Identificacion, " +
                     " personas.persona_direccion as Direccion, personas.persona_telefono_principal as 'Telefono Principal', personas.persona_celular " +
                     " as Celular, personas.persona_correo_electronico as 'Correo Electrónico', p2.persona_nombre as Vendedor, clientes.cliente_balance as Balance FROM clientes INNER JOIN " +
                     " Personas ON clientes.persona_id = personas.id INNER JOIN vendedores ON clientes.vendedor_id = vendedores.id INNER JOIN personas p2 " +
                     " ON vendedores.persona_id = p2.id";
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

        private void LLenarComboBoxVendedores()
        {
            //Llenamos el combobox cmbMunicipios con los registros que hay en la tabla municipios
            string sql = "select vendedores.id, personas.persona_nombre from vendedores INNER JOIN Personas ON vendedores.persona_id = personas.id";
            try
            {
                cmbVendedores.DataSource = conexion.llenarComboBox(sql, "vendedores");
                cmbVendedores.DisplayMember = "persona_nombre";
                cmbVendedores.ValueMember = "id";
                cmbVendedores.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxVendedores", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxTerminosPago()
        {
            //Llenamos el combobox cmbProvincias con los registros que hay en la tabla provincias
            string sql = "select * From Terminos_Pago";
            try
            {
                cmbTerminosPagos.DataSource = conexion.llenarComboBox(sql, "Terminos_Pago");
                cmbTerminosPagos.DisplayMember = "termino_pago_nombre";
                cmbTerminosPagos.ValueMember = "id";
                cmbTerminosPagos.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxTerminosPago", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            pbxCliente.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxCliente.ImageLocation = "";
            btnQuitarFoto.Visible = false;
            dgvContactos.Rows.Clear();
            lblFechaRegistro.Text = lblUtimaVenta.Text = "-";
            lblBalancePendiente.Text = "0.00";
            cmbVendedores.SelectedIndex = cmbTerminosPagos.SelectedIndex = 0;
            btnRegistroAnterior.Enabled = btnRegistroSiguiente.Enabled = false;
        }


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
                Comando.CommandText = "Select count(id) From Clientes";
                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();
                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    if (LectorClientes.GetInt32(0) > 0)
                    {
                        LectorClientes.Close();
                        //Enviamos el parametro o la consulta que se desea realizar en SQL
                        Comando.CommandText = "Select max(id), min(id) From Clientes";
                        //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                        LectorClientes = Comando.ExecuteReader();
                        if (LectorClientes.Read() == true)
                        {
                            //Asignando el valor de cada campo al objeto correspondiente
                            mayor = LectorClientes.GetInt32(0);
                            menor = LectorClientes.GetInt32(1);
                            LectorClientes.Close();
                        }
                    }
                }
                else
                {
                    //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                    LectorClientes.Close();
                }
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
                Comando.CommandText = "select clientes.*, personas.* from clientes INNER JOIN personas ON clientes.persona_id = personas.id where clientes.id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    IdPersona = LectorClientes.GetInt32(1);
                    cmbVendedores.SelectedValue = LectorClientes.GetInt32(2);
                    cmbTerminosPagos.SelectedValue = LectorClientes.GetInt32(3);
                    lblBalancePendiente.Text = LectorClientes.GetDecimal(4).ToString();
                    txtLimiteCredito.Text = LectorClientes.GetDecimal(5).ToString();
                    if (LectorClientes.GetDateTime(6).Equals(DateTime.MinValue))
                    {
                        lblUtimaVenta.Text = "-";
                    }
                    else
                    {
                        lblUtimaVenta.Text = LectorClientes.GetDateTime(6).ToShortDateString();
                    }
                    chkBloqueado.Checked = LectorClientes.GetBoolean(7);
                    txtNombre.Text = LectorClientes.GetString(9);
                    txtIdentificacion.Text = LectorClientes.GetString(10).ToString();
                    txtCorreoElectronico.Text = LectorClientes.GetString(11).ToString();
                    txtDireccion.Text = LectorClientes.GetString(12).ToString();
                    txtTelefono1.Text = LectorClientes.GetString(13).ToString();
                    txtTelefono2.Text = LectorClientes.GetString(14).ToString();
                    txtFax.Text = LectorClientes.GetString(15).ToString();
                    txtCelular.Text = LectorClientes.GetString(16).ToString();
                    txtObservaciones.Text = LectorClientes.GetString(17).ToString();
                    txtPaginaWeb.Text = LectorClientes.GetString(18).ToString();
                    lblFechaRegistro.Text = LectorClientes.GetDateTime(19).ToShortDateString();
                    if (LectorClientes.GetString(21).Length > 0)
                    {
                        pbxCliente.Image = Image.FromFile(LectorClientes.GetString(21));
                        pbxCliente.ImageLocation = LectorClientes.GetString(21);
                        btnQuitarFoto.Visible = true;
                    }
                    else
                    { 
                        pbxCliente.Image = PymeSoft.Properties.Resources.default_user_icon;
                        pbxCliente.ImageLocation = "";
                        btnQuitarFoto.Visible = false;
                    }
                    //cmbListaPrecios.SelectedValue = LectorClientes.GetInt32(18);
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
         *                              BuscarPersona()                                 *
         *                                     -                                        *
         *     Metodo para seleccionar y extraer los datos de un registro de la BD      *
         ********************************************************************************/
        private void BuscarPersona()
        {
            try
            {
                //Para extraer los datos del registro seleccionado en la base de datos
                MySqlDataReader LectorPersona;

                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();

                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "select max(id) from personas";

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorPersona = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorPersona.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    IdPersona = LectorPersona.GetInt32(0);
                }
                //De lo contrario, si no se encontró ningun registro, Enviamos un mensaje al usuario.
                else
                {
                    MessageBox.Show("No existe un registro con este código, verifique y trate de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Limpiar(this);
                    return;
                }

                //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                LectorPersona.Close();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - BuscarPersona", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            LLenarComboBoxVendedores();
            LLenarComboBoxTerminosPago();
            cmbTerminosPagos.SelectedIndex = cmbListaPrecios.SelectedIndex = cmbVendedores.SelectedIndex = -1;
            cmbVendedores.SelectedIndex = cmbTerminosPagos.SelectedIndex = 0;
            pbxCliente.ImageLocation = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el nombre del cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                tabControlClientes.SelectedTab = tabDatosGenerales;
                txtNombre.Focus();
                return;
            }

            /*if (cmbListaPrecios.SelectedIndex < 0)
            {
                MessageBox.Show("Debe indicar un tipo de cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }*/

            if (string.IsNullOrEmpty(txtLimiteCredito.Text))
            {
                txtLimiteCredito.Text = "0";
            }

            if (pbxCliente.ImageLocation.Length > 0)
            {
                rutaImagen = pbxCliente.ImageLocation.Replace("\\", "\\\\");
            }            

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                tabla = "Personas";
                campos = " persona_nombre, persona_identificacion, persona_correo_electronico, persona_direccion, persona_telefono_principal, " +
                         " persona_telefono_secundario, persona_fax, persona_celular, persona_observaciones, persona_pagina_web, " +
                         " persona_tipo_id, persona_imagen";

                valores = "'" + txtNombre.Text.Trim() + "', '" + txtIdentificacion.Text.Trim() + "',  '" + txtCorreoElectronico.Text.Trim() + "'," +
                          "'" + txtDireccion.Text.Trim() + "', '" + txtTelefono1.Text.Trim() + "', '" + txtTelefono2.Text.Trim() + "'," +
                          "'" + txtFax.Text.Trim() + "', '" + txtCelular.Text.Trim() + "', '" + txtObservaciones.Text.Trim() + "'," +
                          "'" + txtPaginaWeb.Text.Trim() + "', '1', '" + rutaImagen +"'";
                try
                {
                    if (conexion.insertarRegistro(tabla, campos, valores))
                    {
                        BuscarPersona();
                        tabla = "Clientes";
                        campos = " persona_id, vendedor_id, termino_pago_id, cliente_limite_credito, cliente_estado_registro";
                        valores = "'" + IdPersona + "', '" + cmbVendedores.SelectedValue + "',  '" + cmbTerminosPagos.SelectedValue + "'," +
                                  "'" + txtLimiteCredito.Text.Trim() + "', '" + Bloqueado + "'";
                        if (conexion.insertarRegistro(tabla, campos, valores))
                        {

                            MessageBox.Show("Registro Insertado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar(this);
                            LlenarDataGridView();
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al insertar el registro: " + error.Message, "Aviso - insertarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                campos = " persona_nombre               = '" + txtNombre.Text.Trim() + "'," +
                         " persona_identificacion       = '" + txtIdentificacion.Text.Trim() + "'," +
                         " persona_correo_electronico   = '" + txtCorreoElectronico.Text.Trim() + "'," +
                         " persona_direccion            = '" + txtDireccion.Text.Trim() + "'," +
                         " persona_telefono_principal   = '" + txtTelefono1.Text.Trim() + "'," +
                         " persona_telefono_secundario  = '" + txtTelefono2.Text.Trim() + "'," +
                         " persona_fax                  = '" + txtFax.Text.Trim() + "'," +
                         " persona_celular              = '" + txtCelular.Text.Trim() + "'," +
                         " persona_observaciones        = '" + txtObservaciones.Text.Trim() + "'," +
                         " persona_pagina_web           = '" + txtPaginaWeb.Text.Trim() + "'," +
                         " persona_imagen               = '" + rutaImagen + "'";
                tabla = " Personas";
                condicion = " id =" + IdPersona;
                try
                {
                    if (conexion.actualizarRegistro(tabla, campos, condicion))
                    {
                        campos = " vendedor_id                  = '" + cmbVendedores.SelectedValue + "'," +
                                 " termino_pago_id              = '" + cmbTerminosPagos.SelectedValue + "'," +
                                 " cliente_limite_credito       = '" + txtLimiteCredito.Text.Trim() + "'," +
                                 " cliente_estado_registro      = '" + Bloqueado + "'";
                        tabla = " Clientes";
                        condicion = " id =" + txtCodigo.Text;
                        if (conexion.actualizarRegistro(tabla, campos, condicion))
                        {
                            MessageBox.Show("Registro Actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar(this);
                            LlenarDataGridView();
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al actualizar el registro: " + error.Message, "Aviso - actualizarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        conexion.eliminarRegistro("Clientes", "id=" + txtCodigo.Text);
                        conexion.eliminarRegistro("Personas", "id=" + IdPersona);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("Este cliente no puede ser eliminado porque tiene registros dependientes (Facturas, Pagos, Devoluciones, etc.) " + error.Message, "Aviso - eliminarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                        return;
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
                    MessageBox.Show("Elija un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (rdbCodigo.Checked == true && txtCriterio.Text.Length > 0)
                    {
                        try
                        {
                            query = SQL + " WHERE clientes.id = '" + txtCriterio.Text.Trim() + "'";
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
                            query = SQL + " WHERE personas.persona_nombre LIKE '%" + txtCriterio.Text.Trim() + "%'";
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
                            query = SQL + " WHERE personas.persona_identificacion LIKE '%" + txtCriterio.Text.Trim() + "%'";
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
                            query = SQL + " WHERE p2.persona_nombre LIKE '%" + txtCriterio.Text.Trim() + "%'";
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

        private void chkBloqueado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBloqueado.Checked)
            {
                Bloqueado = 1;
            }
            else
            {
                Bloqueado = 0;
            }
        }

        private void pbxCliente_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen|*.jpg|*.gif|*.png";
            dialog.Title = "Buscar Imagen del Cliente";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);                

            DialogResult result = dialog.ShowDialog();

            // Si seleccionó una imagen, la mostramos en el PictureBox.
            if (result == DialogResult.OK)
            {
                this.pbxCliente.Image = Image.FromFile(dialog.FileName);
                this.pbxCliente.ImageLocation = dialog.FileName;
                btnQuitarFoto.Visible = true;
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            pbxCliente.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxCliente.ImageLocation = "";
            rutaImagen = "";
            btnQuitarFoto.Visible = false;
        }
    }
}
