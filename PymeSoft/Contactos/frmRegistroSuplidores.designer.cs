﻿namespace DomPlastic_ERP
{
    partial class frmRegistroSuplidores
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroSuplidores));
            this.lblUtimaVenta = new System.Windows.Forms.LinkLabel();
            this.lblBalancePendiente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.gbxParametros = new System.Windows.Forms.GroupBox();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.rdbIdentificacion = new System.Windows.Forms.RadioButton();
            this.rdbNombre = new System.Windows.Forms.RadioButton();
            this.rdbCodigo = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegistroSiguiente = new System.Windows.Forms.Button();
            this.btnRegistroAnterior = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnEliminarSuplidor = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.tabControlClientes = new System.Windows.Forms.TabControl();
            this.tabDatosGenerales = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelefono2 = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefono1 = new System.Windows.Forms.MaskedTextBox();
            this.pbxCliente = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabCondiciones = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo_Electronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.chkBloqueado = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbFormasPagos = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxOpciones = new System.Windows.Forms.GroupBox();
            this.gbxParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControlClientes.SuspendLayout();
            this.tabDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCliente)).BeginInit();
            this.tabCondiciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.gbxOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUtimaVenta
            // 
            this.lblUtimaVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUtimaVenta.BackColor = System.Drawing.Color.White;
            this.lblUtimaVenta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtimaVenta.Location = new System.Drawing.Point(579, 259);
            this.lblUtimaVenta.Name = "lblUtimaVenta";
            this.lblUtimaVenta.Size = new System.Drawing.Size(74, 17);
            this.lblUtimaVenta.TabIndex = 11;
            this.lblUtimaVenta.TabStop = true;
            this.lblUtimaVenta.Text = "-";
            this.lblUtimaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalancePendiente
            // 
            this.lblBalancePendiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalancePendiente.BackColor = System.Drawing.Color.White;
            this.lblBalancePendiente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalancePendiente.Location = new System.Drawing.Point(575, 319);
            this.lblBalancePendiente.Name = "lblBalancePendiente";
            this.lblBalancePendiente.Size = new System.Drawing.Size(86, 18);
            this.lblBalancePendiente.TabIndex = 34;
            this.lblBalancePendiente.Text = "0.00";
            this.lblBalancePendiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(771, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Registro de Suplidores";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaRegistro.BackColor = System.Drawing.Color.White;
            this.lblFechaRegistro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRegistro.Location = new System.Drawing.Point(582, 199);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(74, 17);
            this.lblFechaRegistro.TabIndex = 32;
            this.lblFechaRegistro.Text = "-";
            this.lblFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(566, 302);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 17);
            this.label17.TabIndex = 31;
            this.label17.Text = "Balance Pendiente";
            // 
            // gbxParametros
            // 
            this.gbxParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxParametros.Controls.Add(this.txtCriterio);
            this.gbxParametros.Controls.Add(this.rdbIdentificacion);
            this.gbxParametros.Controls.Add(this.rdbNombre);
            this.gbxParametros.Controls.Add(this.rdbCodigo);
            this.gbxParametros.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbxParametros.Location = new System.Drawing.Point(4, 422);
            this.gbxParametros.Name = "gbxParametros";
            this.gbxParametros.Size = new System.Drawing.Size(746, 76);
            this.gbxParametros.TabIndex = 36;
            this.gbxParametros.TabStop = false;
            this.gbxParametros.Text = "Buscar Por:";
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(121, 47);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(430, 25);
            this.txtCriterio.TabIndex = 20;
            // 
            // rdbIdentificacion
            // 
            this.rdbIdentificacion.AutoSize = true;
            this.rdbIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbIdentificacion.Location = new System.Drawing.Point(370, 20);
            this.rdbIdentificacion.Name = "rdbIdentificacion";
            this.rdbIdentificacion.Size = new System.Drawing.Size(100, 21);
            this.rdbIdentificacion.TabIndex = 23;
            this.rdbIdentificacion.TabStop = true;
            this.rdbIdentificacion.Text = "Cédula/RNC";
            this.rdbIdentificacion.UseVisualStyleBackColor = true;
            // 
            // rdbNombre
            // 
            this.rdbNombre.AutoSize = true;
            this.rdbNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbNombre.Location = new System.Drawing.Point(266, 19);
            this.rdbNombre.Name = "rdbNombre";
            this.rdbNombre.Size = new System.Drawing.Size(76, 21);
            this.rdbNombre.TabIndex = 22;
            this.rdbNombre.TabStop = true;
            this.rdbNombre.Text = "Nombre";
            this.rdbNombre.UseVisualStyleBackColor = true;
            // 
            // rdbCodigo
            // 
            this.rdbCodigo.AutoSize = true;
            this.rdbCodigo.Location = new System.Drawing.Point(172, 19);
            this.rdbCodigo.Name = "rdbCodigo";
            this.rdbCodigo.Size = new System.Drawing.Size(70, 21);
            this.rdbCodigo.TabIndex = 21;
            this.rdbCodigo.TabStop = true;
            this.rdbCodigo.Text = "Código";
            this.rdbCodigo.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(575, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 17);
            this.label16.TabIndex = 30;
            this.label16.Text = "Ultima Venta";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeColumns = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(6, 20);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(734, 130);
            this.dgvClientes.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(572, 178);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 17);
            this.label15.TabIndex = 29;
            this.label15.Text = "Fecha Registro";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaginaWeb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaginaWeb.Location = new System.Drawing.Point(14, 229);
            this.txtPaginaWeb.MaxLength = 100;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(496, 25);
            this.txtPaginaWeb.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvClientes);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(4, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 160);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Suplidores";
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoElectronico.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoElectronico.Location = new System.Drawing.Point(14, 181);
            this.txtCorreoElectronico.MaxLength = 200;
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(326, 25);
            this.txtCorreoElectronico.TabIndex = 8;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(14, 279);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(496, 50);
            this.txtObservaciones.TabIndex = 10;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(121, 84);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(389, 25);
            this.txtDireccion.TabIndex = 4;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(14, 84);
            this.txtIdentificacion.MaxLength = 15;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(101, 25);
            this.txtIdentificacion.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(121, 33);
            this.txtNombre.MaxLength = 200;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(387, 25);
            this.txtNombre.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(14, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(101, 25);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::PymeSoft.Properties.Resources.Save_icon;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(36, 69);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(64, 64);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnRegistroSiguiente
            // 
            this.btnRegistroSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistroSiguiente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistroSiguiente.BackgroundImage")));
            this.btnRegistroSiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegistroSiguiente.Enabled = false;
            this.btnRegistroSiguiente.FlatAppearance.BorderSize = 0;
            this.btnRegistroSiguiente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRegistroSiguiente.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRegistroSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroSiguiente.Location = new System.Drawing.Point(841, 108);
            this.btnRegistroSiguiente.Name = "btnRegistroSiguiente";
            this.btnRegistroSiguiente.Size = new System.Drawing.Size(40, 40);
            this.btnRegistroSiguiente.TabIndex = 31;
            this.btnRegistroSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnRegistroAnterior
            // 
            this.btnRegistroAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistroAnterior.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegistroAnterior.BackgroundImage")));
            this.btnRegistroAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegistroAnterior.Enabled = false;
            this.btnRegistroAnterior.FlatAppearance.BorderSize = 0;
            this.btnRegistroAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRegistroAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRegistroAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistroAnterior.Location = new System.Drawing.Point(795, 108);
            this.btnRegistroAnterior.Name = "btnRegistroAnterior";
            this.btnRegistroAnterior.Size = new System.Drawing.Size(40, 40);
            this.btnRegistroAnterior.TabIndex = 29;
            this.btnRegistroAnterior.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(816, 539);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 48);
            this.button5.TabIndex = 34;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(816, 470);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 48);
            this.button4.TabIndex = 33;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // btnEliminarSuplidor
            // 
            this.btnEliminarSuplidor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminarSuplidor.BackgroundImage")));
            this.btnEliminarSuplidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEliminarSuplidor.FlatAppearance.BorderSize = 0;
            this.btnEliminarSuplidor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEliminarSuplidor.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminarSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarSuplidor.Location = new System.Drawing.Point(36, 129);
            this.btnEliminarSuplidor.Name = "btnEliminarSuplidor";
            this.btnEliminarSuplidor.Size = new System.Drawing.Size(64, 64);
            this.btnEliminarSuplidor.TabIndex = 16;
            this.btnEliminarSuplidor.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(239, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 17);
            this.label24.TabIndex = 39;
            this.label24.Text = "*";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PymeSoft.Properties.Resources.help_icon_2;
            this.pictureBox3.Location = new System.Drawing.Point(362, 39);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 19);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(807, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // btnRetornar
            // 
            this.btnRetornar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRetornar.BackgroundImage")));
            this.btnRetornar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetornar.FlatAppearance.BorderSize = 0;
            this.btnRetornar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRetornar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRetornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetornar.Location = new System.Drawing.Point(46, 204);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(40, 40);
            this.btnRetornar.TabIndex = 17;
            this.btnRetornar.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(346, 162);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 17);
            this.label20.TabIndex = 38;
            this.label20.Text = "Celular";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImage = global::PymeSoft.Properties.Resources.New_icon;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(46, 24);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(40, 40);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // txtCelular
            // 
            this.txtCelular.Culture = new System.Globalization.CultureInfo("es-ES");
            this.txtCelular.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(346, 181);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(160, 25);
            this.txtCelular.TabIndex = 37;
            // 
            // tabControlClientes
            // 
            this.tabControlClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlClientes.Controls.Add(this.tabDatosGenerales);
            this.tabControlClientes.Controls.Add(this.tabCondiciones);
            this.tabControlClientes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlClientes.Location = new System.Drawing.Point(0, 0);
            this.tabControlClientes.Name = "tabControlClientes";
            this.tabControlClientes.SelectedIndex = 0;
            this.tabControlClientes.Size = new System.Drawing.Size(750, 403);
            this.tabControlClientes.TabIndex = 26;
            // 
            // tabDatosGenerales
            // 
            this.tabDatosGenerales.BackColor = System.Drawing.SystemColors.Control;
            this.tabDatosGenerales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDatosGenerales.Controls.Add(this.label24);
            this.tabDatosGenerales.Controls.Add(this.label20);
            this.tabDatosGenerales.Controls.Add(this.txtCelular);
            this.tabDatosGenerales.Controls.Add(this.label18);
            this.tabDatosGenerales.Controls.Add(this.txtTelefono2);
            this.tabDatosGenerales.Controls.Add(this.lblUtimaVenta);
            this.tabDatosGenerales.Controls.Add(this.lblBalancePendiente);
            this.tabDatosGenerales.Controls.Add(this.lblFechaRegistro);
            this.tabDatosGenerales.Controls.Add(this.label17);
            this.tabDatosGenerales.Controls.Add(this.label16);
            this.tabDatosGenerales.Controls.Add(this.label15);
            this.tabDatosGenerales.Controls.Add(this.txtPaginaWeb);
            this.tabDatosGenerales.Controls.Add(this.txtCorreoElectronico);
            this.tabDatosGenerales.Controls.Add(this.txtObservaciones);
            this.tabDatosGenerales.Controls.Add(this.txtDireccion);
            this.tabDatosGenerales.Controls.Add(this.txtIdentificacion);
            this.tabDatosGenerales.Controls.Add(this.txtNombre);
            this.tabDatosGenerales.Controls.Add(this.txtCodigo);
            this.tabDatosGenerales.Controls.Add(this.label13);
            this.tabDatosGenerales.Controls.Add(this.label12);
            this.tabDatosGenerales.Controls.Add(this.label11);
            this.tabDatosGenerales.Controls.Add(this.txtFax);
            this.tabDatosGenerales.Controls.Add(this.label10);
            this.tabDatosGenerales.Controls.Add(this.txtTelefono1);
            this.tabDatosGenerales.Controls.Add(this.pbxCliente);
            this.tabDatosGenerales.Controls.Add(this.label6);
            this.tabDatosGenerales.Controls.Add(this.label5);
            this.tabDatosGenerales.Controls.Add(this.label4);
            this.tabDatosGenerales.Controls.Add(this.label3);
            this.tabDatosGenerales.Controls.Add(this.label2);
            this.tabDatosGenerales.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDatosGenerales.Location = new System.Drawing.Point(4, 26);
            this.tabDatosGenerales.Name = "tabDatosGenerales";
            this.tabDatosGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatosGenerales.Size = new System.Drawing.Size(742, 373);
            this.tabDatosGenerales.TabIndex = 0;
            this.tabDatosGenerales.Text = "Generales";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(180, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 17);
            this.label18.TabIndex = 36;
            this.label18.Text = "Teléfono 2";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Culture = new System.Globalization.CultureInfo("es-ES");
            this.txtTelefono2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono2.Location = new System.Drawing.Point(180, 134);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(160, 25);
            this.txtTelefono2.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Página Web";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "Correo Electrónico";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(346, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Fax";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFax
            // 
            this.txtFax.Culture = new System.Globalization.CultureInfo("es-ES");
            this.txtFax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(346, 134);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(160, 25);
            this.txtFax.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Teléfono 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Culture = new System.Globalization.CultureInfo("es-ES");
            this.txtTelefono1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono1.Location = new System.Drawing.Point(14, 134);
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(160, 25);
            this.txtTelefono1.TabIndex = 7;
            // 
            // pbxCliente
            // 
            this.pbxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCliente.Image = ((System.Drawing.Image)(resources.GetObject("pbxCliente.Image")));
            this.pbxCliente.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxCliente.InitialImage")));
            this.pbxCliente.Location = new System.Drawing.Point(553, 33);
            this.pbxCliente.Name = "pbxCliente";
            this.pbxCliente.Size = new System.Drawing.Size(133, 119);
            this.pbxCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxCliente.TabIndex = 10;
            this.pbxCliente.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Observaciones";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cédula/RNC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre del Suplidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código";
            // 
            // tabCondiciones
            // 
            this.tabCondiciones.Controls.Add(this.linkLabel1);
            this.tabCondiciones.Controls.Add(this.pictureBox3);
            this.tabCondiciones.Controls.Add(this.label14);
            this.tabCondiciones.Controls.Add(this.dgvContactos);
            this.tabCondiciones.Controls.Add(this.chkBloqueado);
            this.tabCondiciones.Controls.Add(this.label23);
            this.tabCondiciones.Controls.Add(this.cmbFormasPagos);
            this.tabCondiciones.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCondiciones.Location = new System.Drawing.Point(4, 26);
            this.tabCondiciones.Name = "tabCondiciones";
            this.tabCondiciones.Size = new System.Drawing.Size(742, 373);
            this.tabCondiciones.TabIndex = 2;
            this.tabCondiciones.Text = "Condiciones y Contactos";
            this.tabCondiciones.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(280, 149);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(172, 17);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Agregar Persona de Contacto";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(3, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(736, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "Contactos Asociados";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Visible = false;
            // 
            // dgvContactos
            // 
            this.dgvContactos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cargo,
            this.Extension,
            this.Telefono,
            this.Correo_Electronico,
            this.btnEliminar});
            this.dgvContactos.Location = new System.Drawing.Point(3, 193);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContactos.RowTemplate.Height = 50;
            this.dgvContactos.Size = new System.Drawing.Size(736, 176);
            this.dgvContactos.TabIndex = 32;
            this.dgvContactos.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 89.54314F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Cargo
            // 
            this.Cargo.FillWeight = 89.54314F;
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            // 
            // Extension
            // 
            this.Extension.FillWeight = 89.54314F;
            this.Extension.HeaderText = "Ext.";
            this.Extension.Name = "Extension";
            // 
            // Telefono
            // 
            this.Telefono.FillWeight = 89.54314F;
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            // 
            // Correo_Electronico
            // 
            this.Correo_Electronico.FillWeight = 89.54314F;
            this.Correo_Electronico.HeaderText = "Correo Electrónico";
            this.Correo_Electronico.Name = "Correo_Electronico";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.btnEliminar.FillWeight = 152.2843F;
            this.btnEliminar.HeaderText = "Opciones";
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Width = 56;
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.AutoSize = true;
            this.chkBloqueado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBloqueado.Location = new System.Drawing.Point(276, 38);
            this.chkBloqueado.Name = "chkBloqueado";
            this.chkBloqueado.Size = new System.Drawing.Size(91, 21);
            this.chkBloqueado.TabIndex = 28;
            this.chkBloqueado.Text = "Bloqueado?";
            this.chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(16, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(175, 17);
            this.label23.TabIndex = 27;
            this.label23.Text = "Términos de Pago por defecto";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFormasPagos
            // 
            this.cmbFormasPagos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormasPagos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormasPagos.FormattingEnabled = true;
            this.cmbFormasPagos.Location = new System.Drawing.Point(14, 34);
            this.cmbFormasPagos.MaxDropDownItems = 10;
            this.cmbFormasPagos.Name = "cmbFormasPagos";
            this.cmbFormasPagos.Size = new System.Drawing.Size(240, 25);
            this.cmbFormasPagos.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(792, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "PymeSoft 1.0";
            // 
            // gbxOpciones
            // 
            this.gbxOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOpciones.BackColor = System.Drawing.SystemColors.Control;
            this.gbxOpciones.Controls.Add(this.btnNuevo);
            this.gbxOpciones.Controls.Add(this.btnRetornar);
            this.gbxOpciones.Controls.Add(this.btnEliminarSuplidor);
            this.gbxOpciones.Controls.Add(this.btnGuardar);
            this.gbxOpciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbxOpciones.Location = new System.Drawing.Point(770, 158);
            this.gbxOpciones.Name = "gbxOpciones";
            this.gbxOpciones.Size = new System.Drawing.Size(128, 263);
            this.gbxOpciones.TabIndex = 32;
            this.gbxOpciones.TabStop = false;
            this.gbxOpciones.Text = "Opciones";
            // 
            // frmRegistroSuplidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxParametros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegistroSiguiente);
            this.Controls.Add(this.btnRegistroAnterior);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabControlClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gbxOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmRegistroSuplidores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PymeSoft 1.0 - Registro de Suplidores";
            this.Load += new System.EventHandler(this.frmRegistrosuplidores_Load);
            this.gbxParametros.ResumeLayout(false);
            this.gbxParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControlClientes.ResumeLayout(false);
            this.tabDatosGenerales.ResumeLayout(false);
            this.tabDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCliente)).EndInit();
            this.tabCondiciones.ResumeLayout(false);
            this.tabCondiciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.gbxOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblUtimaVenta;
        private System.Windows.Forms.Label lblBalancePendiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gbxParametros;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.RadioButton rdbIdentificacion;
        private System.Windows.Forms.RadioButton rdbNombre;
        private System.Windows.Forms.RadioButton rdbCodigo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegistroSiguiente;
        private System.Windows.Forms.Button btnRegistroAnterior;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnEliminarSuplidor;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.TabControl tabControlClientes;
        private System.Windows.Forms.TabPage tabDatosGenerales;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox txtTelefono2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtFax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtTelefono1;
        private System.Windows.Forms.PictureBox pbxCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabCondiciones;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo_Electronico;
        private System.Windows.Forms.DataGridViewButtonColumn btnEliminar;
        private System.Windows.Forms.CheckBox chkBloqueado;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbFormasPagos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbxOpciones;

    }
}