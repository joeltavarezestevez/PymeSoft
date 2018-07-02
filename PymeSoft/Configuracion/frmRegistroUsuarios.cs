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
    public partial class frmRegistroUsuarios : Form
    {
        public frmRegistroUsuarios()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        int mayor = 0;
        int menor = 0;
        int Bloqueado = 0;
        String tabla;
        String campos;
        String valores;
        String condicion;
        String SQL = " SELECT usuarios.id as ID, usuarios.usuario_nombre_completo as Nombre, usuarios.usuario_nombre as Usuario, " +
                     " usuarios_tipos.usuario_tipo_nombre as Tipo, CASE WHEN usuarios.usuario_estado_registro = 1 THEN 'Activo' ELSE " +
                     "'Inactivo' END as Estado FROM usuarios INNER JOIN usuarios_tipos ON usuarios.usuario_tipo_id = usuarios_tipos.id";
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
                dgvUsuarios.DataSource = conexion.ds.Tables["Clientes"];
                dgvUsuarios.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LLenarComboBoxTiposUsuarios()
        {
            //Llenamos el combobox cmbMunicipios con los registros que hay en la tabla municipios
            string sql = "select * from usuarios_tipos";
            try
            {
                cmbTiposUsuarios.DataSource = conexion.llenarComboBox(sql, "usuarios_tipos");
                cmbTiposUsuarios.DisplayMember = "usuario_tipo_nombre";
                cmbTiposUsuarios.ValueMember = "id";
                cmbTiposUsuarios.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso  - LLenarComboBoxTiposUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

            lblFechaRegistro.Text = "-";
            cmbTiposUsuarios.SelectedIndex = 0;
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
                Comando.CommandText = "Select count(id) From Usuarios";
                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();
                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    if (LectorClientes.GetInt32(0) > 0)
                    {
                        LectorClientes.Close();
                        //Enviamos el parametro o la consulta que se desea realizar en SQL
                        Comando.CommandText = "Select max(id), min(id) From Usuarios";
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
                Comando.CommandText = "select * from usuarios where usuarios.id =" + txtCodigo.Text;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorClientes = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorClientes.Read() == true)
                {
                    //Asignando el valor de cada campo al objeto correspondiente
                    txtNombre.Text = LectorClientes.GetString(1);
                    txtUsuario.Text = LectorClientes.GetString(2).ToString();
                    txtContrasena.Text = LectorClientes.GetString(3).ToString();
                    cmbTiposUsuarios.SelectedValue = LectorClientes.GetInt32(4);
                    lblFechaRegistro.Text = LectorClientes.GetDateTime(5).ToShortDateString();
                    chkActivo.Checked = LectorClientes.GetBoolean(6);
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
            LLenarComboBoxTiposUsuarios();
            cmbTiposUsuarios.SelectedIndex = -1;
            cmbTiposUsuarios.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el nombre del usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtNombre.Focus();
                return;
            }

            if (txtUsuario.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar el usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtUsuario.Focus();
                return;
            }

            if (txtContrasena.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe indicar la contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtContrasena.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                tabla = "Usuarios";
                campos = " usuario_nombre_completo, usuario_nombre, usuario_contrasena, usuario_tipo_id, usuario_estado_registro";
                valores = "'" + txtNombre.Text.Trim() + "', '" + txtUsuario.Text.Trim() + "', md5('" + txtContrasena.Text.Trim() + "')," +
                          "'" + cmbTiposUsuarios.SelectedValue + "', '" + Bloqueado + "'";
                try
                {
                    if (conexion.insertarRegistro(tabla, campos, valores))
                    {
                        MessageBox.Show("Registro Insertado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar(this);
                        LlenarDataGridView();
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
                campos = " usuario_nombre_completo  = '" + txtNombre.Text.Trim() + "'," +
                         " usuario_nombre           = '" + txtUsuario.Text.Trim() + "'," +
                         " usuario_contrasena       = md5('" + txtContrasena.Text.Trim() + "')," +
                         " usuario_tipo_id          = '" + cmbTiposUsuarios.SelectedValue + "'," +
                         " usuario_estado_registro  = '" + Bloqueado + "'";
                tabla = " usuarios";
                condicion = " id =" + txtCodigo.Text;
                try
                {
                    if (conexion.actualizarRegistro(tabla, campos, condicion))
                    {
                        MessageBox.Show("Registro Actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar(this);
                        LlenarDataGridView();
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

        private void dgvUsuarios_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count > 0)
            {
                txtCodigo.Text = dgvUsuarios[0, dgvUsuarios.SelectedCells[0].RowIndex].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                DialogResult d = MessageBox.Show("Está seguro que desea eliminar este registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (d == DialogResult.Yes)
                {
                    try
                    {
                        conexion.eliminarRegistro("Usuarios", "id=" + txtCodigo.Text);
                        MessageBox.Show("Registro Eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Este usuario no puede ser eliminado porque tiene registros dependientes (Facturas, Accesos, Registros, etc.) " + error.Message, "Aviso - eliminarRegistro", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
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
                MessageBox.Show("No hay un usuario seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rdbUsuario_CheckedChanged(object sender, EventArgs e)
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
                if (rdbCodigo.Checked == false && rdbNombre.Checked == false && rdbUsuario.Checked == false && rdbTipo.Checked == false)
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
                            query = SQL + " WHERE usuarios.id = '" + txtCriterio.Text.Trim() + "'";
                            conexion.consultar(query, "usuarios");
                            dgvUsuarios.DataSource = conexion.ds.Tables["usuarios"];
                            dgvUsuarios.Refresh();
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
                            query = SQL + " WHERE usuarios.usuario_nombre_completo LIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "usuarios");
                            dgvUsuarios.DataSource = conexion.ds.Tables["usuarios"];
                            dgvUsuarios.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbUsuario.Checked == true)
                    {
                        try
                        {
                            query = SQL + " WHERE usuarios.usuario_nombre LIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "usuarios");
                            dgvUsuarios.DataSource = conexion.ds.Tables["usuarios"];
                            dgvUsuarios.Refresh();
                        }
                        catch (Exception Error)
                        {
                            MessageBox.Show(Error.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    else if (rdbTipo.Checked == true)
                    {
                        try
                        {
                            query = SQL + " WHERE usuarios_tipos.usuario_tipo_nombre LIKE '%" + txtCriterio.Text.Trim() + "%'";
                            conexion.consultar(query, "usuarios");
                            dgvUsuarios.DataSource = conexion.ds.Tables["usuarios"];
                            dgvUsuarios.Refresh();
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
                            conexion.consultar(SQL, "usuarios");
                            dgvUsuarios.DataSource = conexion.ds.Tables["usuarios"];
                            dgvUsuarios.Refresh();
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

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivo.Checked)
            {
                Bloqueado = 1;
            }
            else
            {
                Bloqueado = 0;
            }
        }

        private void btnVerContrasena_Click(object sender, EventArgs e)
        {
            if (txtContrasena.UseSystemPasswordChar)
                txtContrasena.UseSystemPasswordChar = false;
            else
                txtContrasena.UseSystemPasswordChar = true;
        }
    }
}
