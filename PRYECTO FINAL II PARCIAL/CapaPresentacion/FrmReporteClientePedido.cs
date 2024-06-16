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
    public partial class FrmReporteClientePedido : Form
    {
        public FrmReporteClientePedido()
        {
            InitializeComponent();
        }

        private void FrmReporteClientePedido_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'carpinteriaDataSet.Pedidos' Puede moverla o quitarla según sea necesario.
            this.pedidosTableAdapter.Fill(this.carpinteriaDataSet.Pedidos);

            this.reportViewer1.RefreshReport();
        }
    }
}
