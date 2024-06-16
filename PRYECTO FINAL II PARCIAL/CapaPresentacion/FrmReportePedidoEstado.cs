using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReportePedidoEstado : Form
    {
        public FrmReportePedidoEstado()
        {
            InitializeComponent();
        }

        private void FrmReportePedidoEstado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'carpinteriaDataSet.TrabajosCarpinteria' Puede moverla o quitarla según sea necesario.
            this.trabajosCarpinteriaTableAdapter.Fill(this.carpinteriaDataSet.TrabajosCarpinteria);

            this.reportViewer1.RefreshReport();
        }
    }
}
