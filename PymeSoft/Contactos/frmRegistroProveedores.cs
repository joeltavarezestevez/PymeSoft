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

namespace PymeSoft
{
    public partial class frmRegistroProveedores : Form
    {

        public frmRegistroProveedores()
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
        String SQL = " SELECT proveedores.id as ID, personas.persona_nombre as Nombre, personas.persona_identificacion as Identificacion, " +
                     " personas.persona_direccion as Direccion, personas.persona_telefono_principal as 'Telefono Principal', personas.persona_celular " +
                     " as celular, personas.persona_correo_electronico as 'Correo Electrónico', proveedores.proveedor_balance as Balance FROM proveedores INNER JOIN " +
                     " Personas ON proveedores.persona_id = personas.id";
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

                conexion.consultar(SQL, "Proveedores");
                dgvProveedores.DataSource = conexion.ds.Tables["Proveedores"];
                dgvProveedores.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            pbxProveedor.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxProveedor.ImageLocation = "";
            btnQuitarFoto.Visible = false;
            dgvContactos.Rows.Clear();
            lblFechaRegistro.Text = lblUtimaCompra.Text = "-";
            lblBalancePendiente.Text = "0.00";
            cmbTerminosPagos.SelectedIndex = 0;
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
                MySqlDataReader LectorProveedores;
                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();
                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();
                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;
                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select count(id) From Proveedores";
                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorProveedores = Comando.ExecuteReader();
                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorProveedores.Read() == true)
                {
                    if (LectorProveedores.GetInt32(0) > 0)
                    {
                        LectorProveedores.Close();
                        //Enviamos el parametro o la consulta que se desea realizar en SQL
                        Comando.CommandText = "Select max(id), min(id) From Proveedores";
                        //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                        LectorProveedores = Comando.ExecuteReader();
                        if (LectorProveedores.Read() == true)
                        {
                            //Asignando el valor de cada campo al objeto correspondiente
                            mayor = LectorProveedores.GetInt32(0);
                            menor = LectorProveedores.GetInt32(1);
                            LectorProveedores.Close();
                        }
                    }
                }
                else
                {
                    //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                    LectorProveedores.Close();
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
                MySqlDataReader LectorProveedores;

                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();

                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "select Proveedores.*, personas.* from Proveedores INNER JOIN personas ON Proveedores.persona_id = personas.id where Proveedores.id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorProveedores = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorProveedores.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    IdPersona = LectorProveedores.GetInt32(1);
                    cmbTerminosPagos.SelectedValue = LectorProveedores.GetInt32(2);
                    lblBalancePendiente.Text = LectorProveedores.GetDecimal(3).ToString();
                    if (LectorProveedores.GetDateTime(4).Equals(DateTime.MinValue))
                    {
                        lblUtimaCompra.Text = "-";
                    }
                    else
                    {
                        lblUtimaCompra.Text = LectorProveedores.GetDateTime(4).ToShortDateString();
                    }
                    chkBloqueado.Checked = LectorProveedores.GetBoolean(5);
                    txtNombre.Text = LectorProveedores.GetString(7);
                    txtIdentificacion.Text = LectorProveedores.GetString(8).ToString();
                    txtCorreoElectronico.Text = LectorProveedores.GetString(9).ToString();
                    txtDireccion.Text = LectorProveedores.GetString(10).ToString();
                    txtTelefono1.Text = LectorProveedores.GetString(11).ToString();
                    txtTelefono2.Text = LectorProveedores.GetString(12).ToString();
                    txtFax.Text = LectorProveedores.GetString(13).ToString();
                    txtCelular.Text = LectorProveedores.GetString(14).ToString();
                    txtObservaciones.Text = LectorProveedores.GetString(15).ToString();
                    txtPaginaWeb.Text = LectorProveedores.GetString(16).ToString();
                    lblFechaRegistro.Text = LectorProveedores.GetDateTime(17).ToShortDateString();
                    if (LectorProveedores.GetString(19).Length > 0)
                    {
                        pbxProveedor.Image = Image.FromFile(LectorProveedores.GetString(19));
                        pbxProveedor.ImageLocation = LectorProveedores.GetString(19);
                        btnQuitarFoto.Visible = true;
                    }
                    else
                    {
                        pbxProveedor.Image = PymeSoft.Properties.Resources.default_user_icon;
                        pbxProveedor.ImageLocation = "";
                        btnQuitarFoto.Visible = false;
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
                LectorProveedores.Close();
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

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmRegistroProveedores_Load(object sender, EventArgs e)
        {
            LlenarDataGridView();
            BuscarRegistroMayoryMenor();
            LLenarComboBoxTerminosPago();
            cmbTerminosPagos.SelectedIndex = -1;
            cmbTerminosPagos.SelectedIndex = 0;
            pbxProveedor.ImageLocation = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el nombre del proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                tabControlProveedores.SelectedTab = tabDatosGenerales;
                txtNombre.Focus();
                return;
            }

            if (pbxProveedor.ImageLocation.Length > 0)
            {
                rutaImagen = pbxProveedor.ImageLocation.Replace("\\", "\\\\");
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
                          "'" + txtPaginaWeb.Text.Trim() + "', '1', '" + rutaImagen + "'";
                try
                {
                    if (conexion.insertarRegistro(tabla, campos, valores))
                    {
                        BuscarPersona();
                        tabla = "Proveedores";
                        campos = " persona_id, termino_pago_id, proveedor_estado_registro";
                        valores = "'" + IdPersona + "', '" + cmbTerminosPagos.SelectedValue + "','" + Bloqueado + "'";
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
                        campos = " termino_pago_id              = '" + cmbTerminosPagos.SelectedValue + "'," +
                                 " proveedor_estado_registro    = '" + Bloqueado + "'";
                        tabla = " Proveedores";
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

        private void dgvProveedores_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProveedores.Rows.Count > 0)
            {
                txtCodigo.Text = dgvProveedores[0, dgvProveedores.SelectedCells[0].RowIndex].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                DialogResult d = MessageBox.Show("Está seguro que desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        conexion.eliminarRegistro("Proveedores", "id=" + txtCodigo.Text);
                        conexion.eliminarRegistro("Personas", "id=" + IdPersona);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Este proveedor no puede ser eliminado porque tiene registros dependientes (Compras, Pagos, etc.) " + error.Message, "Aviso - eliminarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show("No hay un proveedor seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbIdentificacion_CheckedChanged(object sender, EventArgs e)
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
                    MessageBox.Show("Elija un criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (rdbCodigo.Checked == true && txtCriterio.Text.Length > 0)
                    {
                        try
                        {
                            query = SQL + " WHERE Proveedores.id = '" + txtCriterio.Text.Trim() + "'";
                            conexion.consultar(query, "Proveedores");
                            dgvProveedores.DataSource = conexion.ds.Tables["Proveedores"];
                            dgvProveedores.Refresh();
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
                            conexion.consultar(query, "Proveedores");
                            dgvProveedores.DataSource = conexion.ds.Tables["Proveedores"];
                            dgvProveedores.Refresh();
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
                            conexion.consultar(query, "Proveedores");
                            dgvProveedores.DataSource = conexion.ds.Tables["Proveedores"];
                            dgvProveedores.Refresh();
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
                            conexion.consultar(SQL, "Proveedores");
                            dgvProveedores.DataSource = conexion.ds.Tables["Proveedores"];
                            dgvProveedores.Refresh();
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

        private void pbxProveedor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen|*.jpg|*.gif|*.png";
            dialog.Title = "Buscar Imagen del Proveedor";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            DialogResult result = dialog.ShowDialog();

            // Si seleccionó una imagen, la mostramos en el PictureBox.
            if (result == DialogResult.OK)
            {
                this.pbxProveedor.Image = Image.FromFile(dialog.FileName);
                this.pbxProveedor.ImageLocation = dialog.FileName;
                btnQuitarFoto.Visible = true;
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            pbxProveedor.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxProveedor.ImageLocation = "";
            rutaImagen = "";
            btnQuitarFoto.Visible = false;
        }
    }
}
