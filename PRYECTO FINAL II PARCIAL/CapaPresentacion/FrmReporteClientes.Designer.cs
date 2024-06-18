namespace CapaPresentacion
{
    partial class FrmReporteClientes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.carpinteriaDataSet = new CapaPresentacion.CarpinteriaDataSet();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesTableAdapter = new CapaPresentacion.CarpinteriaDataSetTableAdapters.ClientesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.clientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReporteUsuarios.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // carpinteriaDataSet
            // 
            this.carpinteriaDataSet.DataSetName = "CarpinteriaDataSet";
            this.carpinteriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.carpinteriaDataSet;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteClientes";
            this.Text = "FrmReporteClientes";
            this.Load += new System.EventHandler(this.FrmReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CarpinteriaDataSet carpinteriaDataSet;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private CarpinteriaDataSetTableAdapters.ClientesTableAdapter clientesTableAdapter;
    }
}