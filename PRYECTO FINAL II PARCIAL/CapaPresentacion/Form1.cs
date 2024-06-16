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
        public Form1()
        {
            InitializeComponent();
            VerificarUsuarios();
        }

        private void VerificarUsuarios()
        {
            if (!logicaDatos.ExistenUsuariosRegistrados())
            {
                BtnIngresar.Enabled = false;
                MessageBox.Show("No hay usuarios registrados en el sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BtnIngresar.Enabled = true;
            }
        }

        private void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            new FrmRegistroLogin().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (new CapaLogica.ClaseLogicaDatos().ExistenUsuariosRegistrados())
            {
                BtnIngresar.Visible = true;
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContra.Text;

            Usuario usuario = logicaDatos.Login(username, password);

            if (usuario != null)
            {
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
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }
    }

    
}
