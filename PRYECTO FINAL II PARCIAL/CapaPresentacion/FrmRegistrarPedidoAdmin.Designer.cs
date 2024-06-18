namespace CapaPresentacion
{
    partial class FrmRegistrarPedidoAdmin
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
            this.ComboxTrabajo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fechainicio = new System.Windows.Forms.DateTimePicker();
            this.lbldescripcion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Comboxcantidad = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblfechainicio = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.Fichafin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboxEstado = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboxTrabajo
            // 
            this.ComboxTrabajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboxTrabajo.FormattingEnabled = true;
            this.ComboxTrabajo.Items.AddRange(new object[] {
            "Puertas con vidrios templado",
            "Puertas con Vidrio flotado",
            "Puertas con Vidrio Laminado",
            "Sillas Estandar",
            "Otros"});
            this.ComboxTrabajo.Location = new System.Drawing.Point(280, 100);
            this.ComboxTrabajo.Margin = new System.Windows.Forms.Padding(2);
            this.ComboxTrabajo.Name = "ComboxTrabajo";
            this.ComboxTrabajo.Size = new System.Drawing.Size(195, 24);
            this.ComboxTrabajo.TabIndex = 65;
            this.ComboxTrabajo.SelectedIndexChanged += new System.EventHandler(this.ComboxTrabajo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(280, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 64;
            this.label4.Text = "Fecha Inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(482, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 61;
            this.label1.Text = "Precio c/u:";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.Location = new System.Drawing.Point(276, 79);
            this.lblCedula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(131, 19);
            this.lblCedula.TabIndex = 60;
            this.lblCedula.Text = "Tipo de Trabajo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.fechainicio);
            this.panel1.Controls.Add(this.lbldescripcion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Comboxcantidad);
            this.panel1.Controls.Add(this.lblPrecio);
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
            this.panel1.Controls.Add(this.ComboxTrabajo);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Maroon;
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 529);
            this.panel1.TabIndex = 105;
            // 
            // fechainicio
            // 
            this.fechainicio.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechainicio.Location = new System.Drawing.Point(280, 341);
            this.fechainicio.Margin = new System.Windows.Forms.Padding(2);
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Size = new System.Drawing.Size(195, 22);
            this.fechainicio.TabIndex = 100;
            // 
            // lbldescripcion
            // 
            this.lbldescripcion.AutoSize = true;
            this.lbldescripcion.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescripcion.ForeColor = System.Drawing.Color.Black;
            this.lbldescripcion.Location = new System.Drawing.Point(287, 150);
            this.lbldescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbldescripcion.Name = "lbldescripcion";
            this.lbldescripcion.Size = new System.Drawing.Size(0, 20);
            this.lbldescripcion.TabIndex = 99;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(278, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 98;
            this.label6.Text = "Descripción:";
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
            this.Comboxcantidad.Location = new System.Drawing.Point(282, 243);
            this.Comboxcantidad.Margin = new System.Windows.Forms.Padding(2);
            this.Comboxcantidad.Name = "Comboxcantidad";
            this.Comboxcantidad.Size = new System.Drawing.Size(193, 24);
            this.Comboxcantidad.TabIndex = 97;
            this.Comboxcantidad.SelectedIndexChanged += new System.EventHandler(this.Comboxcantidad_SelectedIndexChanged);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Black;
            this.lblPrecio.Location = new System.Drawing.Point(499, 243);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(0, 20);
            this.lblPrecio.TabIndex = 96;
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
            this.BtnCancelar.Location = new System.Drawing.Point(204, 459);
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
            this.BtnGuardar.Location = new System.Drawing.Point(204, 428);
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
            this.Fichafin.Location = new System.Drawing.Point(280, 390);
            this.Fichafin.Margin = new System.Windows.Forms.Padding(2);
            this.Fichafin.Name = "Fichafin";
            this.Fichafin.Size = new System.Drawing.Size(195, 22);
            this.Fichafin.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 19);
            this.label2.TabIndex = 91;
            this.label2.Text = "Cantidad disponible:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(280, 369);
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
            this.label3.Location = new System.Drawing.Point(280, 273);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 89;
            this.label3.Text = "Estado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(308, 14);
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
            this.ComboxEstado.Location = new System.Drawing.Point(282, 294);
            this.ComboxEstado.Margin = new System.Windows.Forms.Padding(2);
            this.ComboxEstado.Name = "ComboxEstado";
            this.ComboxEstado.Size = new System.Drawing.Size(92, 24);
            this.ComboxEstado.TabIndex = 76;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(143)))), ((int)(((byte)(201)))));
            this.label16.Location = new System.Drawing.Point(67, 11);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(220, 42);
            this.label16.TabIndex = 87;
            this.label16.Text = "REGISTRO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 79);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 333);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRegistrarPedidoAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(143)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(661, 553);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRegistrarPedidoAdmin";
            this.Text = "FrmRegistrarPedidoUsuario";
            this.Load += new System.EventHandler(this.FrmRegistrarPedidoUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ComboxTrabajo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker Fichafin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ComboBox Comboxcantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblfechainicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboxEstado;
        private System.Windows.Forms.Label lbldescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker fechainicio;
    }
}