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

namespace CapaPresentacion
{
    public partial class FrmEliminarProducto : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmEliminarProducto()
        {
            InitializeComponent();
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido de beep en el formulario.

                int idProducto;
                if (int.TryParse(txtIDProducto.Text, out idProducto))
                {
                    // Verificar si hay pedidos asociados al producto
                    if (logicaDatos.HayPedidosParaProducto(idProducto))
                    {
                        if (MessageBox.Show("¿Está seguro de que desea eliminar este producto? Hay pedidos asociados que también se eliminarán.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                logicaDatos.EliminarTrabajo(idProducto);
                                MessageBox.Show("Producto y pedidos asociados eliminados correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtIDProducto.Clear();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe un producto con el ID proporcionado.", "Producto no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "ID Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDProducto.SelectAll(); // Selecciona todo el texto para facilitar la corrección del usuario.
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
