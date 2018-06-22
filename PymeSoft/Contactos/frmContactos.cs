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
    public partial class frmContactos : Form
    {
        public frmContactos()
        {
            InitializeComponent();
        }

        //Creamos el vinculo de conexion desde C# hacia SQL
        ConexionMySQL conexion = new ConexionMySQL();
        String IdPersona = "";
        String TipoPersona = "";
        String SQL = " SELECT personas.id as ID, personas.persona_nombre as Nombre, personas.persona_identificacion as Identificación, " +
                     " personas.persona_direccion as Dirección, personas.persona_telefono_principal as 'Teléfono Principal'," +
                     " personas.persona_telefono_secundario as 'Teléfono Secundario', personas.persona_fax as Fax, " +
                     " personas.persona_celular as Celular, personas.persona_correo_electronico as 'Correo Electrónico'," +
                     " personas.persona_pagina_web as 'Sitio Web', personas_tipos.persona_tipo_nombre as 'Tipo de Contacto'" +
                     " FROM Personas INNER JOIN Personas_Tipos ON Personas.persona_tipo_id = Personas_Tipos.id";
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

                conexion.consultar(SQL, "personas");
                dgvContactos.DataSource = conexion.ds.Tables["personas"];
                dgvContactos.Refresh();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - LLenarDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /********************************************************************************
        *                              BuscarPersona()                                 *
        *                                     -                                        *
        *     Metodo para seleccionar y extraer los datos de un registro de la BD      *
        ********************************************************************************/
        private int BuscarPersona(string TipoPersona, string IdPersona)
        {
            string consultaSQL = "";

            if (TipoPersona == "Cliente")
                consultaSQL = "Select Id From Clientes Where Persona_Id = " + IdPersona;

            if (TipoPersona == "Proveedor")
                consultaSQL = "Select Id From Proveedores Where Persona_Id = " + IdPersona;

            if (TipoPersona == "Vendedor")
                consultaSQL = "Select Id From Vendedores Where Persona_Id = " + IdPersona;

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
                Comando.CommandText = consultaSQL;

                //Ejecutamos el comando y almacenamos el resultado en el Lector de datos.
                LectorPersona = Comando.ExecuteReader();

                //Si se encontró un registro, entonces mostramos los datos de este registro en el formulario.
                if (LectorPersona.Read() == true)
                {
                    int Id = LectorPersona.GetInt32(0);
                    //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                    LectorPersona.Close();
                    //Asignando el valor de cada campo al objeto correspondiente
                    return Id;
                }
                //De lo contrario, si no se encontró ningun registro, Enviamos un mensaje al usuario.
                else
                {
                    MessageBox.Show("No existe un registro con este código, verifique y trate de nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    //Borramos el lector que almacena el registro, para poder utilizarlo nuevamente
                    LectorPersona.Close();
                    return 0;
                }
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message, "Aviso - BuscarPersona", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return 0;
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
        }

        private void dgvVendedores_DoubleClick(object sender, EventArgs e)
        {
            if (dgvContactos.Rows.Count > 0)
            {
                IdPersona = dgvContactos[0, dgvContactos.SelectedCells[0].RowIndex].Value.ToString();
                TipoPersona = dgvContactos[10, dgvContactos.SelectedCells[0].RowIndex].Value.ToString();
                BuscarPersona(TipoPersona, IdPersona);
            }
            else
            {
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
                            query = SQL + " WHERE personas.id = '" + txtCriterio.Text.Trim() + "'";
                            conexion.consultar(query, "personas");
                            dgvContactos.DataSource = conexion.ds.Tables["personas"];
                            dgvContactos.Refresh();
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
                            conexion.consultar(query, "personas");
                            dgvContactos.DataSource = conexion.ds.Tables["personas"];
                            dgvContactos.Refresh();
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
                            conexion.consultar(query, "personas");
                            dgvContactos.DataSource = conexion.ds.Tables["personas"];
                            dgvContactos.Refresh();
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
                            conexion.consultar(SQL, "personas");
                            dgvContactos.DataSource = conexion.ds.Tables["personas"];
                            dgvContactos.Refresh();
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
    }
}