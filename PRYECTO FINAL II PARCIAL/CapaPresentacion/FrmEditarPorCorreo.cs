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
    public partial class FrmEditarPorNombre : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        private bool isInvalidDateShown = false; // Ba
        public FrmEditarPorNombre()
        {
            InitializeComponent();
        }

     

        private void txtcorreo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                // Validar la edad en base a la fecha de nacimiento seleccionada
                int edadIngresada = int.Parse(txtedad.Text);
                int edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

                if (edadIngresada != edadCalculada)
                {
                    MessageBox.Show("La edad debe coincidir con la fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar si el correo electrónico ya está registrado y es diferente al original
                string correoOriginal = textBox1.Text; // Correo inicial usado para cargar los datos
                if (logicaDatos.CorreoExiste(txtcorreo.Text) && txtcorreo.Text != correoOriginal)
                {
                    MessageBox.Show("El correo electrónico ya está registrado. Por favor, ingrese un correo diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcorreo.Focus();
                    txtcorreo.Clear();
                    return;
                }

                Cliente clienteActualizado = new Cliente
                {
                    Nombre = txtnombre.Text,
                    Apellido = txtapellido.Text,
                    Ciudad = txtciudad.Text,
                    Edad = edadIngresada,
                    FechaDeNacimiento = dateTimePicker1.Value,
                    CorreoElectronico = txtcorreo.Text
                };

                logicaDatos.ActualizarDatosClientePorCorreo(correoOriginal, clienteActualizado);
                MessageBox.Show("Datos actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;  // Prevenir más procesamiento de este keypress
                string correo = textBox1.Text.Trim();

                var cliente = logicaDatos.BuscarClientePorCorreo(correo);
                if (cliente != null)
                {
                    txtnombre.Text = cliente.Nombre;
                    txtapellido.Text = cliente.Apellido;
                    txtciudad.Text = cliente.Ciudad;
                    txtedad.Text = cliente.Edad.ToString();
                    dateTimePicker1.Value = cliente.FechaDeNacimiento;
                    txtcorreo.Text = cliente.CorreoElectronico;
                    dateTimePicker1.Enabled = false;
                    txtedad.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe un usuario registrado con ese correo electrónico.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar campos
                    txtnombre.Clear();
                    txtapellido.Clear();
                    txtciudad.Clear();
                    txtedad.Clear();
                    txtcorreo.Clear();
                    
                    dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
                    dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
                    dateTimePicker1.Value = dateTimePicker1.MaxDate;

                    dateTimePicker1.Enabled = false;
                    txtedad.Enabled = false;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

       
        private void FrmEditarPorNombre_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18); // Limita la fecha de nacimiento a hace 18 años desde hoy
            dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            var edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

            if (edadCalculada < 18 && !isInvalidDateShown)
            {
                MessageBox.Show("Se necesita una edad mínima de 18 años.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
                isInvalidDateShown = true; // Marca que el mensaje ya se mostró
            }
            else if (edadCalculada >= 18)
            {
                isInvalidDateShown = false; // Resetea la bandera si la fecha es válida
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
