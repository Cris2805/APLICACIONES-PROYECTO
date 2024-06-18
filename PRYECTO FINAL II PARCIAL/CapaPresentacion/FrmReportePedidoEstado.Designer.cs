namespace CapaPresentacion
{
    partial class FrmReportePedidoEstado
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
            this.trabajosCarpinteriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carpinteriaDataSet = new CapaPresentacion.CarpinteriaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.trabajosCarpinteriaTableAdapter = new CapaPresentacion.CarpinteriaDataSetTableAdapters.TrabajosCarpinteriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.trabajosCarpinteriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // trabajosCarpinteriaBindingSource
            // 
            this.trabajosCarpinteriaBindingSource.DataMember = "TrabajosCarpinteria";
            this.trabajosCarpinteriaBindingSource.DataSource = this.carpinteriaDataSet;
            // 
            // carpinteriaDataSet
            // 
            this.carpinteriaDataSet.DataSetName = "CarpinteriaDataSet";
            this.carpinteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReportePedidoEstado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1067, 554);
            this.reportViewer1.TabIndex = 0;
            // 
            // trabajosCarpinteriaTableAdapter
            // 
            this.trabajosCarpinteriaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReportePedidoEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmReportePedidoEstado";
            this.Text = "FrmReportePedidoEstado";
            this.Load += new System.EventHandler(this.FrmReportePedidoEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trabajosCarpinteriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CarpinteriaDataSet carpinteriaDataSet;
        private System.Windows.Forms.BindingSource trabajosCarpinteriaBindingSource;
        private CarpinteriaDataSetTableAdapters.TrabajosCarpinteriaTableAdapter trabajosCarpinteriaTableAdapter;
    }
}