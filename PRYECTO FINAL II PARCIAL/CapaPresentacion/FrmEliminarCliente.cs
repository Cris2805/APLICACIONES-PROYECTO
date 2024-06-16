using CapaLogica;
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
    public partial class FrmEliminarCliente : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmEliminarCliente()
        {
            InitializeComponent();
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;  // Manejar el evento para que no suene un beep
                string cedula = txtcedula.Text.Trim();

                // Validar la cédula con el algoritmo
                if (!logicaDatos.ValidarCedula(cedula))
                {
                    MessageBox.Show("Cédula inválida. Por favor, ingrese una cédula correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcedula.Focus();
                    txtcedula.SelectAll();
                    return;
                }

                // Verificar si el cliente existe
                if (!logicaDatos.CedulaExiste(cedula))
                {
                    MessageBox.Show("Cliente no encontrado con el número de cédula ingresado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Intentar eliminar el usuario asociado y luego el cliente
                try
                {
                    // Eliminar primero el usuario para evitar conflictos de integridad referencial
                    logicaDatos.EliminarUsuariosPorCedula(cedula);
                    // Una vez eliminado el usuario, eliminar el cliente
                    logicaDatos.EliminarCliente(cedula);
                    MessageBox.Show("El usuario y el cliente han sido eliminados satisfactoriamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcedula.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmEliminarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
