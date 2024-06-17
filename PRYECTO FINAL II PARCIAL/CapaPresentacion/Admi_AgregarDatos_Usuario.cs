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
    public partial class Admi_AgregarDatos_Usuario : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        private bool isInvalidDateShown = false; 

        public Admi_AgregarDatos_Usuario()
        {
            InitializeComponent();
            txtEdad.Enabled = false; // Deshabilitar el campo de edad

        }


        private void Admi_AgregarDatos_Usuario_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void txtCed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                try
                {
                    if (!logicaDatos.ValidarCedula(txtCed.Text))
                    {
                        MessageBox.Show("Número de cédula no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCed.Clear();
                        txtCed.Focus();
                        return;
                    }

                    if (logicaDatos.CedulaExiste(txtCed.Text))
                    {
                        MessageBox.Show("El cliente con esta cédula ya está registrado. Ingrese otro número de cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCed.Clear();
                        txtCed.Focus();
                        return;
                    }

                    SendKeys.Send("{TAB}");  // Pasa al siguiente campo si todo está correcto.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al validar la cédula: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
                {
                    MessageBox.Show("El campo Nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }
                else
                {
                    SendKeys.Send("{TAB}");  // Pasa al siguiente campo.
                }
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
                {
                    MessageBox.Show("El campo Apellido no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtApellido.Focus();
                }
                else
                {
                    SendKeys.Send("{TAB}");  // Pasa al siguiente campo.
                }
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrEmpty(txtCiudad.Text.Trim()))
                {
                    MessageBox.Show("El campo Ciudad no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCiudad.Focus();
                }
                else
                {
                    txtCorreo.Focus();  // Enfoca el campo de correo.
                }
            }
        }
        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Manejar el evento para no propagar el sonido de beep.

                if (string.IsNullOrEmpty(txtCorreo.Text.Trim()))
                {
                    MessageBox.Show("El campo Correo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Focus();
                }
                else if (!txtCorreo.Text.Contains('@') || !txtCorreo.Text.Contains('.'))
                {
                    MessageBox.Show("El correo electrónico debe contener '@' y un dominio válido (ej. '.com').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                }
                else
                {
                    if (logicaDatos.CorreoExiste(txtCorreo.Text))
                    {
                        MessageBox.Show("El correo ya está registrado. Por favor, ingrese un correo diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCorreo.Clear();
                        txtCorreo.Focus();
                    }
                    else
                    {
                        dateTimePicker1.Focus();  // Enfoca el campo de fecha de nacimiento.
                    }
                }
            }

        }
        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!int.TryParse(txtEdad.Text, out int edadIngresada))
                {
                    MessageBox.Show("Por favor, ingrese una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEdad.Clear();
                    txtEdad.Focus();
                    return;
                }

                var edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

                if (edadIngresada != edadCalculada)
                {
                    MessageBox.Show("La edad debe coincidir con la fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEdad.Clear();
                    txtEdad.Focus();
                }
                else
                {
                    btnGuardar.Focus();  // Enfocar el botón Guardar si todo está correcto.
                }
            }
        }

       
         
    private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string cedula = txtCed.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string ciudad = txtCiudad.Text.Trim();
                DateTime fechaNacimiento = dateTimePicker1.Value;
                int edad = int.Parse(txtEdad.Text);
                string correo = txtCorreo.Text.Trim();

                // Revalida la cédula por precaución antes de guardar
                if (!logicaDatos.ValidarCedula(cedula) || logicaDatos.CedulaExiste(cedula))
                {
                    MessageBox.Show("La cédula no es válida o ya está registrada.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crea el objeto cliente
                Cliente nuevoCliente = new Cliente
                {
                    Cedula = cedula,
                    Nombre = nombre,
                    Apellido = apellido,
                    Ciudad = ciudad,
                    Edad = edad,
                    FechaDeNacimiento = fechaNacimiento,
                    CorreoElectronico = correo
                };

                // Llama a la capa lógica para registrar al cliente
                logicaDatos.RegistrarCliente(nuevoCliente);

                MessageBox.Show("Cliente registrado con éxito.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                // Opcional: limpiar campos después de un registro exitoso o cerrar el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

            if (edadCalculada < 18)
            {
                MessageBox.Show("Debe tener al menos 18 años.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
                txtEdad.Clear();
            }
            else
            {
                txtEdad.Text = edadCalculada.ToString();
            }
        }
    }
    

}
