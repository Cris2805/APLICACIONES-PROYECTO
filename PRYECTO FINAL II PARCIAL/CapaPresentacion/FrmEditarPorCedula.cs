using CapaEntidades;
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
    public partial class FrmEditarPorCedula : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmEditarPorCedula()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int edadIngresada = int.Parse(txtedad.Text);
                int edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

                if (edadIngresada != edadCalculada)
                {
                    MessageBox.Show("La edad debe coincidir con la fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Si la validación es correcta, actualizar los datos
                Cliente clienteActualizado = new Cliente
                {
                    Nombre = txtnombre.Text,
                    Apellido = txtapellido.Text,
                    Ciudad = txtciudad.Text,
                    Edad = edadIngresada,
                    FechaDeNacimiento = dateTimePicker1.Value,
                    CorreoElectronico = txtcorreo.Text


                };

                logicaDatos.ActualizarDatosCliente(txtCedula.Text, clienteActualizado);
                MessageBox.Show("Datos actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string nombre = txtCedula.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("Ingrese un número de cédula para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    var cliente = logicaDatos.BuscarCliente(cedula); // Asegúrate de que este método exista y sea implementado correctamente
                    if (cliente != null)
                    {
                        txtnombre.Text = cliente.Nombre;
                        txtapellido.Text = cliente.Apellido;
                        txtciudad.Text = cliente.Ciudad;
                        txtedad.Text = cliente.Edad.ToString();
                        txtcorreo.Text = cliente.CorreoElectronico;
                        dateTimePicker1.Value = cliente.FechaDeNacimiento;
                        dateTimePicker1.Enabled = false;
                        txtedad.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No existe un registro con el nombre ingresado.", "No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Opcional: limpiar los campos si el cliente no es encontrado
                        dateTimePicker1.Enabled = false;
                        txtedad.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditarPorCedula_Load(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
