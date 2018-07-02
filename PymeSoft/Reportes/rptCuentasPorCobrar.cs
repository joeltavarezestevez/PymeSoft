using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PymeSoft.Reportes
{
    public partial class rptCuentasPorCobrar : Form
    {
        public rptCuentasPorCobrar()
        {
            InitializeComponent();
        }

        private void rptVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsCuentasPorCobrar.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.dtsCuentasPorCobrar.Clientes);
            // TODO: esta línea de código carga datos en la tabla 'dtsEmpresa.Empresa' Puede moverla o quitarla según sea necesario.
            this.empresaTableAdapter.Fill(this.dtsEmpresa.Empresa);
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }
    }
}
