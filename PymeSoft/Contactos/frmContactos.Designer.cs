namespace PymeSoft.Contactos
{
    partial class frmContactos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactos));
            this.rdbIdentificacion = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbCodigo = new System.Windows.Forms.RadioButton();
            this.rdbNombre = new System.Windows.Forms.RadioButton();
            this.gbxParametros = new System.Windows.Forms.GroupBox();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gbxOpciones = new System.Windows.Forms.GroupBox();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.gbxParametros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbxOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbIdentificacion
            // 
            this.rdbIdentificacion.AutoSize = true;
            this.rdbIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbIdentificacion.Location = new System.Drawing.Point(370, 20);
            this.rdbIdentificacion.Name = "rdbIdentificacion";
            this.rdbIdentificacion.Size = new System.Drawing.Size(100, 21);
            this.rdbIdentificacion.TabIndex = 24;
            this.rdbIdentificacion.TabStop = true;
            this.rdbIdentificacion.Text = "Cédula/RNC";
            this.rdbIdentificacion.UseVisualStyleBackColor = true;
            this.rdbIdentificacion.CheckedChanged += new System.EventHandler(this.rdbIdentificacion_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(818, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 34);
            this.label1.TabIndex = 51;
            this.label1.Text = "Listado de\r\nContactos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbCodigo
            // 
            this.rdbCodigo.AutoSize = true;
            this.rdbCodigo.Location = new System.Drawing.Point(172, 19);
            this.rdbCodigo.Name = "rdbCodigo";
            this.rdbCodigo.Size = new System.Drawing.Size(70, 21);
            this.rdbCodigo.TabIndex = 22;
            this.rdbCodigo.TabStop = true;
            this.rdbCodigo.Text = "Código";
            this.rdbCodigo.UseVisualStyleBackColor = true;
            this.rdbCodigo.CheckedChanged += new System.EventHandler(this.rdbCodigo_CheckedChanged);
            // 
            // rdbNombre
            // 
            this.rdbNombre.AutoSize = true;
            this.rdbNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdbNombre.Location = new System.Drawing.Point(266, 19);
            this.rdbNombre.Name = "rdbNombre";
            this.rdbNombre.Size = new System.Drawing.Size(76, 21);
            this.rdbNombre.TabIndex = 23;
            this.rdbNombre.TabStop = true;
            this.rdbNombre.Text = "Nombre";
            this.rdbNombre.UseVisualStyleBackColor = true;
            this.rdbNombre.CheckedChanged += new System.EventHandler(this.rdbNombre_CheckedChanged);
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
            this.gbxParametros.Location = new System.Drawing.Point(4, 25);
            this.gbxParametros.Name = "gbxParametros";
            this.gbxParametros.Size = new System.Drawing.Size(766, 76);
            this.gbxParametros.TabIndex = 58;
            this.gbxParametros.TabStop = false;
            this.gbxParametros.Text = "Buscar Por:";
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(121, 47);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(430, 25);
            this.txtCriterio.TabIndex = 21;
            this.txtCriterio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCriterio_KeyPress);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.AllowUserToResizeColumns = false;
            this.dgvContactos.AllowUserToResizeRows = false;
            this.dgvContactos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvContactos.BackgroundColor = System.Drawing.Color.White;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Location = new System.Drawing.Point(6, 20);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.Size = new System.Drawing.Size(754, 506);
            this.dgvContactos.TabIndex = 25;
            this.dgvContactos.DoubleClick += new System.EventHandler(this.dgvVendedores_DoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(102)))));
            this.label7.Location = new System.Drawing.Point(812, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 53;
            this.label7.Text = "PymeSoft 1.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvContactos);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(4, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 532);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado de Contactos";
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
            this.button5.Location = new System.Drawing.Point(821, 334);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 48);
            this.button5.TabIndex = 56;
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
            this.button4.Location = new System.Drawing.Point(821, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 48);
            this.button4.TabIndex = 55;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(821, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 52;
            this.pictureBox2.TabStop = false;
            // 
            // gbxOpciones
            // 
            this.gbxOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOpciones.BackColor = System.Drawing.SystemColors.Control;
            this.gbxOpciones.Controls.Add(this.btnRetornar);
            this.gbxOpciones.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.gbxOpciones.Location = new System.Drawing.Point(780, 128);
            this.gbxOpciones.Name = "gbxOpciones";
            this.gbxOpciones.Size = new System.Drawing.Size(128, 112);
            this.gbxOpciones.TabIndex = 59;
            this.gbxOpciones.TabStop = false;
            this.gbxOpciones.Text = "Opciones";
            // 
            // btnRetornar
            // 
            this.btnRetornar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRetornar.BackgroundImage")));
            this.btnRetornar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRetornar.FlatAppearance.BorderSize = 0;
            this.btnRetornar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRetornar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRetornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetornar.Location = new System.Drawing.Point(41, 44);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(40, 40);
            this.btnRetornar.TabIndex = 20;
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
            // 
            // frmContactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 662);
            this.Controls.Add(this.gbxOpciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxParametros);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmContactos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PymeSoft 1.0 - Lista de Contactos";
            this.Load += new System.EventHandler(this.frmRegistroVendedores_Load);
            this.gbxParametros.ResumeLayout(false);
            this.gbxParametros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbxOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbIdentificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbCodigo;
        private System.Windows.Forms.RadioButton rdbNombre;
        private System.Windows.Forms.GroupBox gbxParametros;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxOpciones;
        private System.Windows.Forms.Button btnRetornar;
    }
}