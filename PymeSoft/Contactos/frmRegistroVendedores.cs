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

namespace PymeSoft.Contactos
{
    public partial class frmRegistroVendedores : Form
    {
        public frmRegistroVendedores()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        int mayor = 0;
        int menor = 0;
        int IdPersona = 0;
        int Comision = 0;
        String rutaImagen = "";
        String tabla;
        String campos;
        String valores;
        String condicion;
        String SQL = " SELECT vendedores.id as ID, personas.persona_nombre as Nombre, personas.persona_identificacion as Identificacion, " +
                     " personas.persona_direccion as Direccion, personas.persona_telefono_principal as 'Telefono Principal', personas.persona_celular " +
                     " as celular, personas.persona_correo_electronico as 'Correo Electrónico' FROM Vendedores INNER JOIN " +
                     " Personas ON Vendedores.persona_id = personas.id";
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

                conexion.consultar(SQL, "Vendedores");
                dgvVendedores.DataSource = conexion.ds.Tables["Vendedores"];
                dgvVendedores.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
            pbxVendedor.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxVendedor.ImageLocation = "";
            btnQuitarFoto.Visible = false;
            lblFechaRegistro.Text = lblUtimaCompra.Text = "-";
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
                MySqlDataReader LectorVendedores;
                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();
                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();
                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;
                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "Select count(id) From Vendedores";
                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorVendedores = Comando.ExecuteReader();
                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorVendedores.Read() == true)
                {
                    if (LectorVendedores.GetInt32(0) > 0)
                    {
                        LectorVendedores.Close();
                        //Enviamos el parametro o la consulta que se desea realizar en SQL
                        Comando.CommandText = "Select max(id), min(id) From Vendedores";
                        //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                        LectorVendedores = Comando.ExecuteReader();
                        if (LectorVendedores.Read() == true)
                        {
                            //Asignando el valor de cada campo al objeto correspondiente
                            mayor = LectorVendedores.GetInt32(0);
                            menor = LectorVendedores.GetInt32(1);
                            LectorVendedores.Close();
                        }
                    }
                }
                else
                {
                    //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                    LectorVendedores.Close();
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
                MySqlDataReader LectorVendedores;

                //Abrimos la conexion hacia la BD
                conexion.conexion.Open();

                //Creamos una instruccion o comando SQL
                MySqlCommand Comando = new MySqlCommand();

                //Le asignamos la conexion actual
                Comando.Connection = conexion.conexion;

                //Enviamos el parametro o la consulta que se desea realizar en SQL
                Comando.CommandText = "select Vendedores.*, personas.* from Vendedores INNER JOIN personas ON Vendedores.persona_id = personas.id where Vendedores.id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorVendedores = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorVendedores.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    IdPersona = LectorVendedores.GetInt32(1);
                    chkComision.Checked = LectorVendedores.GetBoolean(2);
                    if (LectorVendedores.GetDateTime(3).Equals(DateTime.MinValue))
                    {
                        lblUtimaCompra.Text = "-";
                    }
                    else
                    {
                        lblUtimaCompra.Text = LectorVendedores.GetDateTime(3).ToShortDateString();
                    }
                    txtNombre.Text = LectorVendedores.GetString(5);
                    txtIdentificacion.Text = LectorVendedores.GetString(6).ToString();
                    txtCorreoElectronico.Text = LectorVendedores.GetString(7).ToString();
                    txtDireccion.Text = LectorVendedores.GetString(8).ToString();
                    txtTelefono1.Text = LectorVendedores.GetString(9).ToString();
                    txtTelefono2.Text = LectorVendedores.GetString(10).ToString();
                    txtFax.Text = LectorVendedores.GetString(11).ToString();
                    txtCelular.Text = LectorVendedores.GetString(12).ToString();
                    txtObservaciones.Text = LectorVendedores.GetString(13).ToString();
                    lblFechaRegistro.Text = LectorVendedores.GetDateTime(15).ToShortDateString();
                    if (LectorVendedores.GetString(17).Length > 0)
                    {
                        pbxVendedor.Image = Image.FromFile(LectorVendedores.GetString(17));
                        pbxVendedor.ImageLocation = LectorVendedores.GetString(17);
                        btnQuitarFoto.Visible = true;
                    }
                    else
                    {
                        pbxVendedor.Image = PymeSoft.Properties.Resources.default_user_icon;
                        pbxVendedor.ImageLocation = "";
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
                LectorVendedores.Close();
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

        private void frmRegistroVendedores_Load(object sender, EventArgs e)
        {
            LlenarDataGridView();
            BuscarRegistroMayoryMenor();
            pbxVendedor.ImageLocation = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el nombre del vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                tabControlVendedores.SelectedTab = tabDatosGenerales;
                txtNombre.Focus();
                return;
            }

            if (pbxVendedor.ImageLocation.Length > 0)
            {
                rutaImagen = pbxVendedor.ImageLocation.Replace("\\", "\\\\");
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                tabla = "Personas";
                campos = " persona_nombre, persona_identificacion, persona_correo_electronico, persona_direccion, persona_telefono_principal, " +
                         " persona_telefono_secundario, persona_fax, persona_celular, persona_observaciones, persona_tipo_id, persona_imagen";
                valores = "'" + txtNombre.Text.Trim() + "', '" + txtIdentificacion.Text.Trim() + "',  '" + txtCorreoElectronico.Text.Trim() + "'," +
                          "'" + txtDireccion.Text.Trim() + "', '" + txtTelefono1.Text.Trim() + "', '" + txtTelefono2.Text.Trim() + "'," +
                          "'" + txtFax.Text.Trim() + "', '" + txtCelular.Text.Trim() + "', '" + txtObservaciones.Text.Trim() + "'," +
                          "'3', '" + rutaImagen + "'";
                try
                {
                    if (conexion.insertarRegistro(tabla, campos, valores))
                    {
                        BuscarPersona();
                        tabla = "Vendedores";
                        campos = " persona_id, vendedor_comision";
                        valores = "'" + IdPersona + "','" + Comision + "'";
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
                         " persona_imagen               = '" + rutaImagen + "'";
                tabla = " Personas";
                condicion = " id =" + IdPersona;
                try
                {
                    if (conexion.actualizarRegistro(tabla, campos, condicion))
                    {
                        campos = " vendedor_comision    = '" + Comision + "'";
                        tabla =  " Vendedores";
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

        private void dgvVendedores_DoubleClick(object sender, EventArgs e)
        {
            if (dgvVendedores.Rows.Count > 0)
            {
                txtCodigo.Text = dgvVendedores[0, dgvVendedores.SelectedCells[0].RowIndex].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarVendedor_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                DialogResult d = MessageBox.Show("Está seguro que desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        conexion.eliminarRegistro("Vendedores", "id=" + txtCodigo.Text);
                        conexion.eliminarRegistro("Personas", "id=" + IdPersona);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Este vendedor no puede ser eliminado porque tiene registros dependientes (Facturas, Pagos, etc.) " + error.Message, "Aviso - eliminarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show("No hay un vendedor seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            query = SQL + " WHERE Vendedores.id = '" + txtCriterio.Text.Trim() + "'";
                            conexion.consultar(query, "Vendedores");
                            dgvVendedores.DataSource = conexion.ds.Tables["Vendedores"];
                            dgvVendedores.Refresh();
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
                            conexion.consultar(query, "Vendedores");
                            dgvVendedores.DataSource = conexion.ds.Tables["Vendedores"];
                            dgvVendedores.Refresh();
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
                            conexion.consultar(query, "Vendedores");
                            dgvVendedores.DataSource = conexion.ds.Tables["Vendedores"];
                            dgvVendedores.Refresh();
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
                            conexion.consultar(SQL, "Vendedores");
                            dgvVendedores.DataSource = conexion.ds.Tables["Vendedores"];
                            dgvVendedores.Refresh();
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

        private void chkComision_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComision.Checked)
            {
                Comision = 1;
            }
            else
            {
                Comision = 0;
            }
        }

        private void pbxVendedor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen|*.jpg|*.gif|*.png";
            dialog.Title = "Buscar Imagen del Vendedor";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            DialogResult result = dialog.ShowDialog();

            // Si seleccionó una imagen, la mostramos en el PictureBox.
            if (result == DialogResult.OK)
            {
                this.pbxVendedor.Image = Image.FromFile(dialog.FileName);
                this.pbxVendedor.ImageLocation = dialog.FileName;
                btnQuitarFoto.Visible = true;
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            pbxVendedor.Image = PymeSoft.Properties.Resources.default_user_icon;
            pbxVendedor.ImageLocation = "";
            rutaImagen = "";
            btnQuitarFoto.Visible = false;
        }
    }
}