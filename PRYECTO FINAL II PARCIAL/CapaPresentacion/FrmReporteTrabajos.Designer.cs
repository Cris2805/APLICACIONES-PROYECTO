namespace CapaPresentacion
{
    partial class FrmReporteTrabajos
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
            this.trabajosCarpinteriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trabajosCarpinteriaTableAdapter = new CapaPresentacion.CarpinteriaDataSetTableAdapters.TrabajosCarpinteriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trabajosCarpinteriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.trabajosCarpinteriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.ReporteTrabajo.rdlc";
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
            // trabajosCarpinteriaBindingSource
            // 
            this.trabajosCarpinteriaBindingSource.DataMember = "TrabajosCarpinteria";
            this.trabajosCarpinteriaBindingSource.DataSource = this.carpinteriaDataSet;
            // 
            // trabajosCarpinteriaTableAdapter
            // 
            this.trabajosCarpinteriaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteTrabajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteTrabajos";
            this.Text = "FrmReporteTrabajos";
            this.Load += new System.EventHandler(this.FrmReporteTrabajos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carpinteriaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trabajosCarpinteriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CarpinteriaDataSet carpinteriaDataSet;
        private System.Windows.Forms.BindingSource trabajosCarpinteriaBindingSource;
        private CarpinteriaDataSetTableAdapters.TrabajosCarpinteriaTableAdapter trabajosCarpinteriaTableAdapter;
    }
}