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
    public partial class FrmBuscarUsuario : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmBuscarUsuario()
        {
            InitializeComponent();
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Maneja el evento Enter para no emitir el sonido de bip.

                string cedula = txtcedula.Text.Trim();
                if (string.IsNullOrEmpty(cedula))
                {
                    MessageBox.Show("Por favor, ingrese una cédula para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var cliente = logicaDatos.BuscarCliente(cedula);
                    if (cliente != null)
                    {
                        lblnombre.Text = cliente.Nombre;
                        lblapellido.Text = cliente.Apellido;
                        lblciudad.Text = cliente.Ciudad;
                        lbledad.Text = cliente.Edad.ToString();
                        lblcorreo.Text = cliente.CorreoElectronico;
                        lblfecha.Text = cliente.FechaDeNacimiento.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        MessageBox.Show("El cliente con la cédula especificada no está registrado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Opcional: limpiar las etiquetas si el cliente no es encontrado
                        lblnombre.Text = "-";
                        lblapellido.Text = "-";
                        lblciudad.Text = "-";
                        lbledad.Text = "-";
                        lblcorreo.Text = "-";
                        lblfecha.Text = "-";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmBuscarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblfecha_Click(object sender, EventArgs e)
        {

        }

        private void lblciudad_Click(object sender, EventArgs e)
        {

        }

        private void lblapellido_Click(object sender, EventArgs e)
        {

        }

        private void lblcorreo_Click(object sender, EventArgs e)
        {

        }

        private void lbledad_Click(object sender, EventArgs e)
        {

        }

        private void lblnombre_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
