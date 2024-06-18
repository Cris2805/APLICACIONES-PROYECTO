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
    public partial class Form1 : Form
    {

        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        private bool usuariosVerificados = false;
        public Form1()
        {
            InitializeComponent();
            VerificarUsuarios();
        }

        private void VerificarUsuarios()
        {
            if (!usuariosVerificados)
            {
                if (!logicaDatos.ExistenUsuariosRegistrados())
                {
                    txtUsuario.Enabled = false;
                    txtContra.Enabled = false;
                    BtnIngresar.Enabled = false;
                    MessageBox.Show("No hay usuarios registrados en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtUsuario.Enabled = true;
                    txtContra.Enabled = true;
                    BtnIngresar.Enabled = true;
                }
                usuariosVerificados = true;
            }
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            var registroForm = new FrmRegistroLogin();
            registroForm.RegistroCompletado += (s, args) => VerificarUsuarios(); // Suscribirse al evento RegistroCompletado
            registroForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VerificarUsuarios();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim();
            string password = txtContra.Text.Trim();

            bool usuarioExiste = logicaDatos.VerificarUsuario(username);
            bool contrasenaCorrecta = logicaDatos.VerificarContrasena(username, password);

            if (!usuarioExiste && !contrasenaCorrecta)
            {
                MessageBox.Show("Usuario y contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!usuarioExiste)
            {
                MessageBox.Show("Usuario incorrecto.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtUsuario.Focus();
            }
            else if (!contrasenaCorrecta)
            {
                MessageBox.Show("Contraseña incorrecta.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContra.Clear();
                txtContra.Focus();
            }
            else
            {
                Usuario usuario = logicaDatos.Login(username, password);
                if (usuario != null)
                {
                    // Asignar la cédula del usuario a la clase Sesion
                    Sesion.CedulaUsuario = logicaDatos.ObtenerCedulaUsuario(username);

                    switch (usuario.Role)
                    {
                        case "admin":
                            FrmMenuAdmi frmMenuAdmi = new FrmMenuAdmi();
                            frmMenuAdmi.Show();
                            this.Hide();
                            break;
                        case "user":
                            FrmMenuUsuario frmMenuUsuario = new FrmMenuUsuario();
                            frmMenuUsuario.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("No se reconoce el rol del usuario.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string username = txtUsuario.Text.Trim();
                bool usuarioExiste = logicaDatos.VerificarUsuario(username);

                if (!usuarioExiste)
                {
                    MessageBox.Show("Usuario incorrecto.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                else
                {
                    txtContra.Focus();
                }
            }
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                string username = txtUsuario.Text.Trim();
                string password = txtContra.Text.Trim();

                bool usuarioExiste = logicaDatos.VerificarUsuario(username);
                bool contrasenaCorrecta = logicaDatos.VerificarContrasena(username, password);

                if (!usuarioExiste)
                {
                    MessageBox.Show("Usuario incorrecto.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtUsuario.Focus();
                }
                else if (!contrasenaCorrecta)
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContra.Clear();
                    txtContra.Focus();
                }
                else
                {
                    BtnIngresar.Focus();
                }
            }
        }
    }
        
    

    
}
