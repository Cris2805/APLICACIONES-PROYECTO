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
    public partial class FrmMenuUsuario : Form
    {
        public FrmMenuUsuario()
        {
            InitializeComponent();
        }

        private void cbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbReportes.SelectedIndex)
            {
                case 0:
                    FrmReporteClientes objrep1 = new FrmReporteClientes();
                    objrep1.ShowDialog();
                    break;
                case 1:
                    FrmReporteTrabajos objrep2 = new FrmReporteTrabajos();
                    objrep2.ShowDialog();
                    break;
                case 2:
                    FrmReporteClientePedido objrep3 = new FrmReporteClientePedido();
                    objrep3.ShowDialog();
                    break;
                case 3:
                    FrmReportePedidoEstado objrep4 = new FrmReportePedidoEstado();
                    objrep4.ShowDialog();
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmBuscarUsuario objbus = new FrmBuscarUsuario();
            objbus.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmRegistroPedido objreg = new FrmRegistroPedido();
            objreg.ShowDialog();
        }

        private void lblusuario_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBuscarPedido objbus = new FrmBuscarPedido();
            objbus.ShowDialog();
        }
    }
}
