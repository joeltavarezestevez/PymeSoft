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

namespace PymeSoft.Configuracion
{
    public partial class frmConfiguracionEmpresa : Form
    {
        public frmConfiguracionEmpresa()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        //int IdConfiguracion = 0;
        String rutaImagen = "";
        String tabla;
        String campos;
        String condicion;

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

            pbxLogoEmpresa.Image = PymeSoft.Properties.Resources.image_icon;
            pbxLogoEmpresa.ImageLocation = "";
            btnQuitarFoto.Visible = false;
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
                Comando.CommandText = "SELECT configuracion_empresa_nombre, configuracion_empresa_eslogan, configuracion_empresa_rnc, " +
                                      "configuracion_empresa_direccion, configuracion_empresa_telefono, configuracion_empresa_correo_electronico, " +
                                      "configuracion_empresa_sitio_web, configuracion_empresa_logo FROM Configuracion_empresa where id = 1";

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente

                    txtNombre.Text = LectorClientes.GetString(0);
                    txtEslogan.Text = LectorClientes.GetString(1).ToString();
                    txtIdentificacion.Text = LectorClientes.GetString(2).ToString();
                    txtDireccion.Text = LectorClientes.GetString(3).ToString();
                    txtTelefono.Text = LectorClientes.GetString(4).ToString();
                    txtCorreoElectronico.Text = LectorClientes.GetString(5).ToString();
                    txtPaginaWeb.Text = LectorClientes.GetString(6).ToString();
                    if (LectorClientes.GetString(7).Length > 0)
                    {
                        pbxLogoEmpresa.Image = Image.FromFile(LectorClientes.GetString(7));
                        pbxLogoEmpresa.ImageLocation = LectorClientes.GetString(7);
                        btnQuitarFoto.Visible = true;
                    }
                    else
                    {
                        pbxLogoEmpresa.Image = PymeSoft.Properties.Resources.image_icon;
                        pbxLogoEmpresa.ImageLocation = "";
                        btnQuitarFoto.Visible = false;
                    }
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
            BuscarRegistro();
            pbxLogoEmpresa.ImageLocation = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el nombre de la empresa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                tabControlEmpresa.SelectedTab = tabDatosGenerales;
                txtNombre.Focus();
                return;
            }

            if (pbxLogoEmpresa.ImageLocation.Length > 0)
            {
                rutaImagen = pbxLogoEmpresa.ImageLocation.Replace("\\", "\\\\");
            }

            campos = " configuracion_empresa_nombre               = '" + txtNombre.Text.Trim() + "'," +
                        " configuracion_empresa_eslogan              = '" + txtEslogan.Text.Trim() + "'," +
                        " configuracion_empresa_rnc              = '" + txtIdentificacion.Text.Trim() + "'," +
                        " configuracion_empresa_direccion            = '" + txtDireccion.Text.Trim() + "'," +
                        " configuracion_empresa_telefono             = '" + txtTelefono.Text.Trim() + "'," +
                        " configuracion_empresa_correo_electronico   = '" + txtCorreoElectronico.Text.Trim() + "'," +
                        " configuracion_empresa_sitio_web            = '" + txtPaginaWeb.Text.Trim() + "'," +
                        " configuracion_empresa_logo                 = '" + rutaImagen + "'";
            tabla = "Configuracion_empresa";
            condicion = " id = 1";
            try
            {
                if (conexion.actualizarRegistro(tabla, campos, condicion))
                {
                    MessageBox.Show("Configuración Actualizada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al actualizar el registro: " + error.Message, "Aviso - actualizarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

       

        private void pbxLogoEmpresa_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Imagen|*.jpg|*.gif|*.png";
            dialog.Title = "Buscar Logo de la Empresa";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            DialogResult result = dialog.ShowDialog();

            // Si seleccionó una imagen, la mostramos en el PictureBox.
            if (result == DialogResult.OK)
            {
                this.pbxLogoEmpresa.Image = Image.FromFile(dialog.FileName);
                this.pbxLogoEmpresa.ImageLocation = dialog.FileName;
                btnQuitarFoto.Visible = true;
            }
        }

        private void btnQuitarFoto_Click(object sender, EventArgs e)
        {
            pbxLogoEmpresa.Image = PymeSoft.Properties.Resources.image_icon;
            pbxLogoEmpresa.ImageLocation = "";
            rutaImagen = "";
            btnQuitarFoto.Visible = false;
        }
    }
}
