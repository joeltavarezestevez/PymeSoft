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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        ConexionMySQL conexion = new ConexionMySQL();

        int Id_Usuario = 0;
        int Tipo_Usuario = 0;
        int contador_de_intentos = 3;
        bool Habilitado;
        bool Actualizar;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (this.txtusuarionombre.Text == "")
            {
                MessageBox.Show("Debe indicar el nombre de usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (this.txtusuariocontrasena.Text == "")
            {
                MessageBox.Show("Debe indicar la contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                try
                {
                    MySqlDataReader LectorUsuario;  // para leer en la base de datos
                    conexion.conexion.Open();
                    MySqlCommand Comando = new MySqlCommand();
                    Comando.Connection = conexion.conexion;
                    Comando.CommandText = "Select * From usuarios where usuario_nombre ='" + this.txtusuarionombre.Text.Trim() + "' and usuario_contrasena = md5('" + this.txtusuariocontrasena.Text.Trim() + "')";
                    LectorUsuario = Comando.ExecuteReader();
                    if (LectorUsuario.Read() == true)
                    {
                        Id_Usuario = LectorUsuario.GetInt32(0);
                        Habilitado = LectorUsuario.GetBoolean(3);
                        Tipo_Usuario = LectorUsuario.GetInt32(4);
                        conexion.conexion.Close();
                    }
                    else
                    {
                        if (contador_de_intentos > 0)
                        {
                            MessageBox.Show("No existe un usuario con estos datos, verifique el nombre de usuario o la contraseña digitada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contador_de_intentos--;
                            this.txtusuariocontrasena.Focus();
                            return;
                        }
                        else
                        {
                            string campos = "usuario_activo='False'";
                            string tabla = "usuarios";
                            string condicion = " usuario_nombre ='" + txtusuarionombre.Text.Trim() + "'";
                            conexion.conexion.Close();
                            Actualizar = conexion.actualizarRegistro(tabla, campos, condicion);
                            if (Actualizar == true)
                            {
                                MessageBox.Show("Ha superado el límite de intentos de inicio de sesión", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    LectorUsuario.Close();
                }
                catch (Exception Error)
                {
                    MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                finally
                {
                    conexion.conexion.Close();
                }
                if (Habilitado == false)
                {
                    MessageBox.Show("Este usuario está deshabilitado. Comuníquese con el administrador del sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (conexion.insertarRegistro("historial_accesos_usuarios", "usuario_id", "'" + Id_Usuario + "'"))
                    {
                        MessageBox.Show("BIENVENIDO AL SISTEMA", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMenuPrincipal m = new frmMenuPrincipal();
                        m.usuario_logueado_id = Id_Usuario;
                        m.nombre_usuario_logueado = txtusuarionombre.Text;
                        m.Show();
                        Hide();
                    }
                }
            }
        }

        private void txtusuariocontrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }

        private void txtusuarionombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIniciarSesion.PerformClick();
                e.Handled = true;
            }
        }
    }
}
