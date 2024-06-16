using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FrmRegistroLogin : Form
    {

        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();

        public FrmRegistroLogin()
        {
            InitializeComponent();
            this.txtUsuario.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
            this.txtContra.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
            this.txtCed.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
            this.comboBox1.KeyPress += new KeyPressEventHandler(Txt_KeyPress);
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Control nextControl = this.GetNextControl((Control)sender, true);
                if (nextControl != null)
                {
                    e.Handled = true;  // Indica que el evento KeyPress ha sido manejado
                    nextControl.Focus();  // Mueve el foco al siguiente control
                }
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (logicaDatos.UsuarioExiste(txtUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elige otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                else
                {
                    // Mover el foco al siguiente control si la validación es exitosa
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                e.Handled = true; // Maneja el evento Enter para no propagar el sonido de beep
            }
        }

        

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContra.Text; // Considera hashear la contraseña
            string role = comboBox1.SelectedItem.ToString();
            string cedula = txtCed.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string ciudad = txtCiudad.Text;
            int edad = int.Parse(txtEdad.Text);
            DateTime fechaNacimiento = dateTimePicker1.Value;
            string correo = txtCorreo.Text;


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica si el cliente ya existe
            Cliente clienteExistente = logicaDatos.BuscarCliente(cedula);

            if (clienteExistente == null)
            {
                // Si no existe, crea un nuevo cliente
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

                logicaDatos.RegistrarCliente(nuevoCliente); // Asume que este método maneja la inserción en la base de datos
            }

            // Crea un nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                Username = username,
                Password = password, // Asegúrate de hashear la contraseña aquí
                Role = role,
                Cedula = cedula
            };

            try
            {
                logicaDatos.RegistrarUsuario(nuevoUsuario);
                MessageBox.Show("El usuario ha sido registrado con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Opcional: Cierra el formulario después del registro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cedula = txtCed.Text.Trim();

            if (string.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Por favor, ingrese una cédula para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente cliente = logicaDatos.BuscarCliente(cedula);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtCiudad.Text = cliente.Ciudad;
                txtEdad.Text = cliente.Edad.ToString();
                dateTimePicker1.Value = cliente.FechaDeNacimiento;
                txtCorreo.Text = cliente.CorreoElectronico;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Por favor, verifique la cédula o ingrese los datos para un nuevo registro.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCiudad.Clear();
                txtEdad.Clear();
                txtCorreo.Clear();
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCed_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (!logicaDatos.ValidarCedula(txtCed.Text))
                    {
                        MessageBox.Show("La cédula ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCed.Clear();
                        txtCed.Focus();
                    }
                    else
                    {
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }
                    e.Handled = true;
                }
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!int.TryParse(txtEdad.Text, out int edadIngresada) || edadIngresada <= 0)
                {
                    MessageBox.Show("Ingrese una edad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEdad.Clear();
                    txtEdad.Focus();
                }
                else
                {
                    // Calcula la edad basada en la fecha de nacimiento seleccionada
                    int calculoEdad = DateTime.Today.Year - dateTimePicker1.Value.Year;
                    if (dateTimePicker1.Value > DateTime.Today.AddYears(-calculoEdad)) calculoEdad--;

                    if (calculoEdad != edadIngresada)
                    {
                        MessageBox.Show("La edad no coincide con la fecha de nacimiento proporcionada. Por favor, corrija la edad o la fecha de nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtEdad.Focus();
                    }
                    else
                    {
                        // Mover el foco al siguiente control si la edad es correcta
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }
                }
                e.Handled = true; // Maneja el evento Enter para evitar el sonido de beep
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            
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
                        // Si todo está correcto, pasar al siguiente control
                        this.SelectNextControl((Control)sender, true, true, true, true);
                    }
                }
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
              
                
                    this.SelectNextControl((Control)sender, true, true, true, true);
                
                e.Handled = true;
            }
        }

        private void FrmRegistroLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Verifica si la contraseña cumple con una longitud mínima de 6 caracteres
                // y podría incluir más validaciones de complejidad si fuera necesario
                if (txtContra.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña demasiado corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContra.Clear();
                    txtContra.Focus();
                }
                else
                {
                    // Mueve el foco al siguiente control si la contraseña es válida
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
                e.Handled = true; // Maneja el evento Enter para no propagar el sonido de beep
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
