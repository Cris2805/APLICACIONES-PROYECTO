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
    public partial class FrmMenuAdmi : Form
    {
        public FrmMenuAdmi()
        {
            InitializeComponent();
        }

        private void BtnIngresarDatos_Click(object sender, EventArgs e)
        {
            new Admi_AgregarDatos_Usuario().Show();

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            new FrmEditarPorNombre().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmEditarPorCedula().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FrmEliminarCliente().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FrmBuscarUsuario().Show();
        }

        private void cbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbReportes.SelectedIndex)
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

        private void FrmMenuAdmi_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmRegistrarPedidoAdmin obj = new FrmRegistrarPedidoAdmin();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEditProducto obj = new FrmEditProducto();
            obj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmEliminarProducto obj = new FrmEliminarProducto();
            obj.ShowDialog();
        }

        private void Btnsesion_Click(object sender, EventArgs e)
        {
            Form1 objform = new Form1();
            objform.Show();
            this.FindForm().Close();
        }
    }
}
