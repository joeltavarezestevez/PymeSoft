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
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        ConexionMySQL conexion = new ConexionMySQL();

        public int usuario_logueado_id;
        public String nombre_usuario_logueado;

        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private bool terminarSesion()
        {
            string campos = "historial_acceso_fecha_salida=CURRENT_TIMESTAMP, historial_acceso_usuario_conectado='0'";
            string tabla = "historial_accesos_usuarios";
            string condicion = " id = (select max(id) from historial_accesos_usuarios where usuario_id  = " + usuario_logueado_id + ")";
            conexion.conexion.Close();
            if (conexion.actualizarRegistro(tabla, campos, condicion))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroClientes clientes = new frmRegistroClientes();
            clientes.Show();
        }

        private void configuraciónGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.frmConfiguracionEmpresa empresa = new Configuracion.frmConfiguracionEmpresa();
            empresa.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroProveedores proveedores = new frmRegistroProveedores();
            proveedores.Show();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactos.frmRegistroVendedores vendedores = new Contactos.frmRegistroVendedores();
            vendedores.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                //if (terminarSesion())
                //{
                    Close();
                    Application.Exit();
                //}
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea cerrar la sesión?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                //if (terminarSesion())
                //{
                    Hide();
                    frmLogin fl = new frmLogin();
                    fl.Show();
                //}
            }
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactos.frmContactos contactos = new Contactos.frmContactos();
            contactos.Show();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = nombre_usuario_logueado;
        }

        private void itemsDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario.frmRegistroItemsdeVenta itemsdeVenta = new Inventario.frmRegistroItemsdeVenta();
            itemsdeVenta.Show();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.frmRegistroUsuarios usuarios = new Configuracion.frmRegistroUsuarios();
            usuarios.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reportes.rptCuentasPorCobrar cpc = new Reportes.rptCuentasPorCobrar();
            cpc.Show();
        }
    }
}
