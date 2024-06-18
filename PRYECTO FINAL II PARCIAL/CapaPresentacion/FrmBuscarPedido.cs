using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.IO;

namespace CapaPresentacion
{
    public partial class FrmBuscarPedido : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmBuscarPedido()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private void ClearFields()
        {
            lblcantidad.Text = "";
            LblPrecio.Text = "";
            lblEstado.Text = "";
            lblfin.Text = "";
            LblPrecio.Text = "";
            pictureBox1.Image = null;
            lblTrabajo.Text = "";
        }
        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Maneja el evento Enter para no emitir el sonido de bip.

                if (string.IsNullOrEmpty(txtidtraba.Text))
                {
                    MessageBox.Show("Por favor, ingrese un ID de pedido para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    if (!int.TryParse(txtidtraba.Text.Trim(), out int idPedido))
                    {
                        MessageBox.Show("El ID debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var pedidoDetalle = logicaDatos.BuscarPedidoPorId(idPedido);  // Cambia el método según lo que necesites para buscar por ID de pedido

                    if (pedidoDetalle != null)
                    {
                        // Actualizar los controles de la interfaz con la información del pedido y el trabajo asociado
                        lblcantidad.Text = pedidoDetalle.Cantidad.ToString();
                        lblTrabajo.Text = pedidoDetalle.Descripcion;
                        lblEstado.Text = pedidoDetalle.Estado;
                        lblfin.Text = pedidoDetalle.Fecha.ToString("dd/MM/yyyy"); // Asumiendo que quieres mostrar la misma fecha o ajusta según tu lógica
                        LblPrecio.Text = pedidoDetalle.Total.ToString("C2");  // Formato de moneda
                        pictureBox1.Image = ConvertByteArrayToImage(pedidoDetalle.Foto);
                    }
                    else
                    {
                        MessageBox.Show("Pedido no encontrado con el ID proporcionado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Limpiar los campos si no se encuentra el pedido
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtidtraba.SelectAll();  // Selecciona el texto para facilitar una nueva entrada
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
