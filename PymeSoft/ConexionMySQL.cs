using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace PymeSoft
{
    class ConexionMySQL
    {
        public MySqlConnection conexion;
        private MySqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public MySqlDataAdapter da;
        public MySqlCommand comando;
        private string servidor;
        private string baseDatos;
        private string uid;
        private string password;

        public ConexionMySQL()
        {
            conectar();
        }

        private void conectar()
        {
            servidor = "localhost";
            baseDatos = "pymesoft";
            uid = "root";
            password = "";
            string parametrosDeConexion;
            parametrosDeConexion = "SERVER = " + servidor + "; DATABASE = " + baseDatos + "; UID = " + uid + "; PASSWORD=" + password + ";CHARSET=utf8;Convert Zero Datetime=True;";
            conexion = new MySqlConnection(parametrosDeConexion);
        }

        //Consultar Registros SQL
        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new MySqlDataAdapter(sql, conexion);
            cmb = new MySqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        //Insertar Registros SQL
        public bool insertarRegistro(string tabla, string campos, string valores)
        {
            string sql = "insert into " + tabla + "(" + campos + ") values (" + valores + ")";
            conexion.Open();
            comando = new MySqlCommand(sql, conexion);
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Eliminar Registros SQL
        public bool eliminarRegistro(string tabla, string condicion)
        {
            conexion.Open();
            string sql = "delete from " + tabla + " where " + condicion;
            comando = new MySqlCommand(sql, conexion);
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Actualizar Registros SQL
        public bool actualizarRegistro(string tabla, string campos, string condicion)
        {
            conexion.Open();
            string sql = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new MySqlCommand(sql, conexion);
            int i = comando.ExecuteNonQuery();
            conexion.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable llenarComboBox(string sql, string tabla)
        {
            //string sql = "select * from " + tabla;
            da = new MySqlDataAdapter(sql, conexion);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
    }
}
