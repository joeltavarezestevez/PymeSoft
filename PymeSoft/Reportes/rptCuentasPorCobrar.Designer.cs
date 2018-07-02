namespace PymeSoft.Reportes
{
    partial class rptCuentasPorCobrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtsEmpresa = new PymeSoft.dtsEmpresa();
            this.dtsEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empresaTableAdapter = new PymeSoft.dtsEmpresaTableAdapters.EmpresaTableAdapter();
            this.dtsCuentasPorCobrar = new PymeSoft.dtsCuentasPorCobrar();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesTableAdapter = new PymeSoft.dtsCuentasPorCobrarTableAdapters.ClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtsEmpresa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsEmpresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsCuentasPorCobrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dtsEncabezado";
            reportDataSource3.Value = this.empresaBindingSource;
            reportDataSource4.Name = "dtsCuentasPorCobrar";
            reportDataSource4.Value = this.clientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PymeSoft.Reportes.rpt.rptCuentasPorCobrar.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(546, 103);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtsEmpresa
            // 
            this.dtsEmpresa.DataSetName = "dtsEmpresa";
            this.dtsEmpresa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtsEmpresaBindingSource
            // 
            this.dtsEmpresaBindingSource.DataSource = this.dtsEmpresa;
            this.dtsEmpresaBindingSource.Position = 0;
            // 
            // empresaBindingSource
            // 
            this.empresaBindingSource.DataMember = "Empresa";
            this.empresaBindingSource.DataSource = this.dtsEmpresaBindingSource;
            // 
            // empresaTableAdapter
            // 
            this.empresaTableAdapter.ClearBeforeFill = true;
            // 
            // dtsCuentasPorCobrar
            // 
            this.dtsCuentasPorCobrar.DataSetName = "dtsCuentasPorCobrar";
            this.dtsCuentasPorCobrar.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.dtsCuentasPorCobrar;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // rptCuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 103);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rptCuentasPorCobrar";
            this.Text = "rptVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.rptVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsEmpresa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsEmpresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsCuentasPorCobrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dtsEmpresa dtsEmpresa;
        private System.Windows.Forms.BindingSource dtsEmpresaBindingSource;
        private System.Windows.Forms.BindingSource empresaBindingSource;
        private dtsEmpresaTableAdapters.EmpresaTableAdapter empresaTableAdapter;
        private dtsCuentasPorCobrar dtsCuentasPorCobrar;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private dtsCuentasPorCobrarTableAdapters.ClientesTableAdapter clientesTableAdapter;

    }
}