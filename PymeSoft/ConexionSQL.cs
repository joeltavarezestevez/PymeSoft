using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace PymeSoft
{
    class ConexionSQL
    {
        //string connstring = "Server=10.71.34.1;Port=5432;User Id=joeltavarezestevez;Password=DesPro09;Database=DomPlastic;";
        string connstring = "Server=192.168.0.3;Port=5432;User Id=joeltavarezestevez;Password=DesPro09;Database=DomPlastic;";
        public NpgsqlConnection conn;
        private NpgsqlCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public NpgsqlDataAdapter da;
        public NpgsqlCommand comando;

        public ConexionSQL()
        {
            conectar();
        }

        private void conectar()
        {
            conn = new NpgsqlConnection(connstring);
        }

        //Consultar Registros SQL
        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new NpgsqlDataAdapter(sql, conn);
            cmb = new NpgsqlCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        //Insertar Registros SQL
        public bool insertar(string sql)
        {
            conn.Open();
            comando = new NpgsqlCommand(sql, conn);
            int i = comando.ExecuteNonQuery();
            conn.Close();
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
        public bool eliminar(string tabla, string condicion)
        {
            conn.Open();
            string sql = "delete from " + tabla + " where " + condicion;
            comando = new NpgsqlCommand(sql, conn);
            int i = comando.ExecuteNonQuery();
            conn.Close();
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
        public bool actualizar(string tabla, string campos, string condicion)
        {
            conn.Open();
            string sql = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new NpgsqlCommand(sql, conn);
            int i = comando.ExecuteNonQuery();
            conn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable LlenarComboBox(string tabla, string orden, string condicion = "")
        {
            string sql = "";
            if(condicion.Length > 0)
                sql = "select * from " + tabla +" where " + condicion + " order by " + orden;
            else
                sql = "select * from " + tabla + " order by " + orden;
            da = new NpgsqlDataAdapter(sql, conn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }
    }
}
