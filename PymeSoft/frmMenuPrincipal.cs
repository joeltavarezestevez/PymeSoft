using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PymeSoft
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "";
            lblHora.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = lblHora.Text + " - " + DateTime.Now.ToLongTimeString();
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
                Application.Exit();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Está seguro que desea cerrar la sesión?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactos.frmContactos contactos = new Contactos.frmContactos();
            contactos.Show();
        }


    }
}
