namespace CapaPresentacion
{
    partial class FrmEditProducto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIDProducto = new System.Windows.Forms.TextBox();
            this.lblTipoTrabajo = new System.Windows.Forms.Label();
            this.fechainicio = new System.Windows.Forms.DateTimePicker();
            this.Comboxcantidad = new System.Windows.Forms.ComboBox();
            this.lblfechainicio = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.Fichafin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboxEstado = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtIDProducto);
            this.panel1.Controls.Add(this.lblTipoTrabajo);
            this.panel1.Controls.Add(this.fechainicio);
            this.panel1.Controls.Add(this.Comboxcantidad);
            this.panel1.Controls.Add(this.lblfechainicio);
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnGuardar);
            this.panel1.Controls.Add(this.Fichafin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.ComboxEstado);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lblCedula);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Maroon;
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 491);
            this.panel1.TabIndex = 106;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.Cedula;
            this.pictureBox3.Location = new System.Drawing.Point(290, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 117;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(142, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 25);
            this.label8.TabIndex = 115;
            this.label8.Text = "ID de producto";
            // 
            // txtIDProducto
            // 
            this.txtIDProducto.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDProducto.Location = new System.Drawing.Point(330, 72);
            this.txtIDProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDProducto.Name = "txtIDProducto";
            this.txtIDProducto.Size = new System.Drawing.Size(143, 33);
            this.txtIDProducto.TabIndex = 116;
            this.txtIDProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
            // 
            // lblTipoTrabajo
            // 
            this.lblTipoTrabajo.AutoSize = true;
            this.lblTipoTrabajo.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoTrabajo.ForeColor = System.Drawing.Color.Black;
            this.lblTipoTrabajo.Location = new System.Drawing.Point(286, 175);
            this.lblTipoTrabajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoTrabajo.Name = "lblTipoTrabajo";
            this.lblTipoTrabajo.Size = new System.Drawing.Size(0, 20);
            this.lblTipoTrabajo.TabIndex = 101;
            // 
            // fechainicio
            // 
            this.fechainicio.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechainicio.Location = new System.Drawing.Point(284, 287);
            this.fechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Size = new System.Drawing.Size(195, 22);
            this.fechainicio.TabIndex = 100;
            // 
            // Comboxcantidad
            // 
            this.Comboxcantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comboxcantidad.FormattingEnabled = true;
            this.Comboxcantidad.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.Comboxcantidad.Location = new System.Drawing.Point(284, 239);
            this.Comboxcantidad.Margin = new System.Windows.Forms.Padding(2);
            this.Comboxcantidad.Name = "Comboxcantidad";
            this.Comboxcantidad.Size = new System.Drawing.Size(193, 24);
            this.Comboxcantidad.TabIndex = 97;
            // 
            // lblfechainicio
            // 
            this.lblfechainicio.AutoSize = true;
            this.lblfechainicio.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfechainicio.ForeColor = System.Drawing.Color.Black;
            this.lblfechainicio.Location = new System.Drawing.Point(280, 349);
            this.lblfechainicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblfechainicio.Name = "lblfechainicio";
            this.lblfechainicio.Size = new System.Drawing.Size(0, 20);
            this.lblfechainicio.TabIndex = 95;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Maroon;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Linen;
            this.BtnCancelar.Location = new System.Drawing.Point(207, 428);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(227, 31);
            this.BtnCancelar.TabIndex = 94;
            this.BtnCancelar.Text = "Cerrar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(143)))), ((int)(((byte)(201)))));
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(207, 397);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(227, 31);
            this.BtnGuardar.TabIndex = 93;
            this.BtnGuardar.Text = "Guardar:";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // Fichafin
            // 
            this.Fichafin.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fichafin.Location = new System.Drawing.Point(284, 336);
            this.Fichafin.Margin = new System.Windows.Forms.Padding(2);
            this.Fichafin.Name = "Fichafin";
            this.Fichafin.Size = new System.Drawing.Size(195, 22);
            this.Fichafin.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 19);
            this.label2.TabIndex = 91;
            this.label2.Text = "Cantidad disponible:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(284, 266);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 64;
            this.label4.Text = "Fecha Inicio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(284, 315);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 90;
            this.label5.Text = "Fecha Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(492, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 89;
            this.label3.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 19);
            this.label1.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(259, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 39);
            this.label9.TabIndex = 88;
            this.label9.Text = "PRODUCTOS";
            // 
            // ComboxEstado
            // 
            this.ComboxEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboxEstado.FormattingEnabled = true;
            this.ComboxEstado.Items.AddRange(new object[] {
            "en desarrollo",
            "terminado"});
            this.ComboxEstado.Location = new System.Drawing.Point(496, 171);
            this.ComboxEstado.Margin = new System.Windows.Forms.Padding(2);
            this.ComboxEstado.Name = "ComboxEstado";
            this.ComboxEstado.Size = new System.Drawing.Size(122, 24);
            this.ComboxEstado.TabIndex = 76;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(143)))), ((int)(((byte)(201)))));
            this.label16.Location = new System.Drawing.Point(83, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 42);
            this.label16.TabIndex = 87;
            this.label16.Text = "EDITAR";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(280, 150);
            this.lblCedula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(131, 19);
            this.lblCedula.TabIndex = 60;
            this.lblCedula.Text = "Tipo de Trabajo:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(31, 126);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // FrmEditProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(143)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(664, 510);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEditProducto";
            this.Text = "FrmEliminarProducto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker fechainicio;
        private System.Windows.Forms.ComboBox Comboxcantidad;
        private System.Windows.Forms.Label lblfechainicio;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DateTimePicker Fichafin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ComboxEstado;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTipoTrabajo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtIDProducto;
        private System.Windows.Forms.Label label8;
    }
}