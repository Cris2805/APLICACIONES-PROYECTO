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
        public event EventHandler RegistroCompletado;
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();

        public FrmRegistroLogin()
        {
            InitializeComponent();

            txtEdad.Enabled = false;

            // Limitar la fecha mínima del DateTimePicker
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            AjustarOpcionesComboBox();
        }
        private void AjustarOpcionesComboBox()
        {
            if (logicaDatos.ExistenUsuariosRegistrados())
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("user");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("admin");
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
            }
        }


        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
                else if (logicaDatos.UsuarioExiste(txtUsuario.Text))
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elige otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                else
                {
                    txtContra.Focus();
                }
                e.Handled = true;
            }
        }

        

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContra.Text;
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
                string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(ciudad) ||
                string.IsNullOrWhiteSpace(correo))
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

                logicaDatos.RegistrarCliente(nuevoCliente);
            }

            // Crea un nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                Username = username,
                Password = password,
                Role = role,
                Cedula = cedula
            };

            try
            {
                logicaDatos.RegistrarUsuario(nuevoUsuario);
                MessageBox.Show("El usuario ha sido registrado con éxito.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lanzar el evento RegistroCompletado
                RegistroCompletado?.Invoke(this, EventArgs.Empty);

                this.Close();
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
                dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
                dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
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
                dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
                dateTimePicker1.MinDate = new DateTime(1900, 1, 1);
                dateTimePicker1.Value = dateTimePicker1.MaxDate;
            }
            txtNombre.Focus();
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtCed.Text))
                {
                    MessageBox.Show("Por favor, ingrese la cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCed.Focus();
                }
                else if (!logicaDatos.ValidarCedula(txtCed.Text))
                {
                    MessageBox.Show("La cédula ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCed.Clear();
                    txtCed.Focus();
                }
                else
                {
                    txtNombre.Focus();
                }
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; //
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
                {
                    MessageBox.Show("Por favor, ingrese el correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Focus();
                }
                else if (!txtCorreo.Text.Contains('@') || !txtCorreo.Text.Contains('.'))
                {
                    MessageBox.Show("El correo electrónico debe contener '@' y un dominio válido (ej. '.com').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                }
                else if (logicaDatos.CorreoExiste(txtCorreo.Text))
                {
                    MessageBox.Show("El correo ya está registrado. Por favor, ingrese un correo diferente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCorreo.Clear();
                    txtCorreo.Focus();
                }
                else
                {
                    txtCiudad.Focus();
                }
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void FrmRegistroLogin_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtContra.Text.Length < 6)
                {
                    MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña demasiado corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContra.Clear();
                    txtContra.Focus();
                }
                else
                {
                    txtconfirmarcontra.Focus();
                }
                e.Handled = true;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }
                else
                {
                    txtApellido.Focus();
                }
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Por favor, ingrese el apellido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtApellido.Focus();
                }
                else
                {
                    txtCorreo.Focus();
                }
            }

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                txtCiudad.Focus();
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtCiudad.Text))
                {
                    MessageBox.Show("Por favor, ingrese la ciudad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCiudad.Focus();
                }
                else
                {
                    dateTimePicker1.Focus();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int edadCalculada = DateTime.Today.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Today.AddYears(-edadCalculada)) edadCalculada--;

            if (edadCalculada < 18)
            {
                MessageBox.Show("Debe tener al menos 18 años.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
            }
            else
            {
                txtEdad.Text = edadCalculada.ToString();
                txtUsuario.Focus();
            }
        }

        private void txtconfirmarcontra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtconfirmarcontra.Text != txtContra.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden. Por favor, ingrese nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtconfirmarcontra.Clear();
                    txtconfirmarcontra.Focus();
                }
                else
                {
                    BtnGuardar.Focus();
                }
                e.Handled = true;
            }
        }
    }
}
