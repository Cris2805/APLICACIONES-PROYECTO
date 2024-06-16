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

        public Admi_AgregarDatos_Usuario()
        {
            InitializeComponent();
            
        }


        private void Admi_AgregarDatos_Usuario_Load(object sender, EventArgs e)
        { 
        
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
                SendKeys.Send("{TAB}");  // Pasa al siguiente campo.
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");  // Pasa al siguiente campo.
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");  // Pasa al siguiente campo.
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                // Calcula la edad basada en la fecha seleccionada.
                var edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
                if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;
                if (edadCalculada < 15)
                {
                    MessageBox.Show("Se necesita una edad mínima de 15 años.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePicker1.Focus();
                }
                else
                {
                    SendKeys.Send("{TAB}");  // Pasa al siguiente campo si la edad es válida.
                }
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                int edadIngresada = int.Parse(txtEdad.Text);
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
                    SendKeys.Send("{TAB}");  // Pasa al siguiente campo si todo está correcto.
                }
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true; // Manejar el evento para no propagar el sonido de beep.

                // Verificación básica del formato del correo
                if (!txtCorreo.Text.Contains('@') || !txtCorreo.Text.Contains('.'))
                {
                    MessageBox.Show("El correo electrónico debe contener '@' y un dominio válido (ej. '.com').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                }
                else
                {
                    // Verificación de la unicidad del correo
                    if (logicaDatos.CorreoExiste(txtCorreo.Text))
                    {
                        MessageBox.Show("El correo ya está registrado. Por favor, ingrese un correo diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCorreo.Clear();
                        txtCorreo.Focus();
                    }
                    else
                    {
                        // Aquí podría ir el código para registrar al usuario si es que toda la validación ha pasado.
                        MessageBox.Show("Todos los datos son válidos. Proceda con el registro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
    }
    

}
