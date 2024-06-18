using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidades;
using System.IO;

namespace CapaPresentacion
{
    public partial class FrmRegistroPedido : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        private List<TrabajoCarpinteria> trabajosCarpinteria;

        public FrmRegistroPedido()
        {
            InitializeComponent();
            txtCedula.Text = Sesion.CedulaUsuario; // Asignar la cédula del usuario a txtCedula
            txtCedula.Enabled = false; // Deshabilitar el campo de cédula para que no pueda ser editado
            CargarTrabajos();
        }


        private void CargarTrabajos()
        {
            trabajosCarpinteria = logicaDatos.ObtenerTrabajosCarpinteria();
            comboBoxTrabajos.DataSource = trabajosCarpinteria;
            comboBoxTrabajos.DisplayMember = "Id";
            comboBoxTrabajos.ValueMember = "Id";

            if (trabajosCarpinteria.Count == 0)
            {
                comboBoxTrabajos.Enabled = false;
                txtCedula.Enabled = false;
                Comboxcantidad.Enabled = false;
                MessageBox.Show("No hay trabajos disponibles. Por favor, añada trabajos antes de realizar pedidos.", "Sin trabajos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comboBoxTrabajos.Enabled = true;
                comboBoxTrabajos.SelectedIndex = 0;
            }
        }

        private bool ValidarFechaEntrega()
        {
            DateTime fechaEntrega = fechainicio.Value.Date;
            DateTime fechaActual = DateTime.Now.Date;

            if (fechaEntrega < fechaActual)
            {
                MessageBox.Show("La fecha de entrega no puede ser una fecha pasada.", "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fechaEntrega > fechaActual.AddDays(16))
            {
                MessageBox.Show("La fecha de entrega debe estar dentro de los próximos 16 días.", "Fecha de Entrega Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void CalcularYMostrarTotal()
        {
            if (comboBoxTrabajos.SelectedItem is TrabajoCarpinteria trabajo && int.TryParse(Comboxcantidad.SelectedItem?.ToString(), out int cantidad))
            {
                decimal total = cantidad * trabajo.Costo;
                lbltotal.Text = total.ToString("C2");  // Formato de moneda
            }
        }
        private void Comboxcantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularYMostrarTotal();
        }

        private void comboBoxTrabajos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTrabajos.SelectedItem is TrabajoCarpinteria trabajo)
            {
                lbldescripcion.Text = trabajo.Descripcion;

                Comboxcantidad.Items.Clear();  // Limpiar las opciones de cantidad
                if (trabajo.Cantidad > 1) // Mostrar hasta cantidad - 1
                {
                    for (int i = 1; i < trabajo.Cantidad; i++) // Evitar la última cantidad
                    {
                        Comboxcantidad.Items.Add(i.ToString());
                    }

                    if (Comboxcantidad.Items.Count > 0)
                    {
                        Comboxcantidad.SelectedIndex = 0;  // Seleccionar la primera cantidad disponible
                        Comboxcantidad.Enabled = true;  // Habilitar el combobox si hay stock.
                        BtnGuardar.Enabled = true;  // Habilitar el botón de guardar si hay stock.
                    }
                    else
                    {
                        Comboxcantidad.Enabled = false;
                        BtnGuardar.Enabled = false;
                        MessageBox.Show("No hay cantidades disponibles para este trabajo.", "Stock no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Comboxcantidad.Enabled = false;  // Deshabilitar el combobox si no hay stock.
                    BtnGuardar.Enabled = false;  // Deshabilitar el botón de guardar si no hay stock.
                    MessageBox.Show("Actualmente no hay stock disponible para este trabajo.", "Stock no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Mostrar la imagen
                pictureBox1.Image = ConvertByteArrayToImage(trabajo.Foto);
            }
        }
        public Image ConvertByteArrayToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!logicaDatos.CedulaExiste(txtCedula.Text))
            {
                MessageBox.Show("No se encontró un cliente con la cédula proporcionada.", "Cliente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFechaEntrega())
                return;

            try
            {
                if (!(comboBoxTrabajos.SelectedItem is TrabajoCarpinteria trabajoSeleccionado))
                {
                    MessageBox.Show("No se ha seleccionado un trabajo válido.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int cantidadSeleccionada = Convert.ToInt32(Comboxcantidad.SelectedItem.ToString());
                decimal totalCalculado = Convert.ToDecimal(lbltotal.Text.Replace("$", ""));

                Pedido nuevoPedido = new Pedido
                {
                    IdTrabajo = trabajoSeleccionado.Id,
                    Cantidad = cantidadSeleccionada,
                    Total = totalCalculado,
                    Fecha = fechainicio.Value.Date,
                    CedulaCliente = txtCedula.Text
                };

                logicaDatos.RegistrarPedido(nuevoPedido);

                int nuevaCantidad = trabajoSeleccionado.Cantidad - cantidadSeleccionada;
                logicaDatos.ActualizarCantidadTrabajo(trabajoSeleccionado.Id, nuevaCantidad);

                MessageBox.Show("Pedido registrado correctamente. La cantidad disponible ha sido actualizada.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la lista de trabajos después de registrar el pedido
                trabajosCarpinteria = logicaDatos.ObtenerTrabajosCarpinteria();
                comboBoxTrabajos.DataSource = trabajosCarpinteria;
                // Si la cantidad del trabajo seleccionado es 1 o menos, eliminarlo de la lista
                if (nuevaCantidad <= 0)
                {
                    trabajosCarpinteria.Remove(trabajoSeleccionado);
                    comboBoxTrabajos.DataSource = null;
                    comboBoxTrabajos.DataSource = trabajosCarpinteria;
                    comboBoxTrabajos.DisplayMember = "Id";
                    comboBoxTrabajos.ValueMember = "Id";

                    if (trabajosCarpinteria.Count == 0)
                    {
                        MessageBox.Show("Productos agotados, te llevaste todo.", "Sin stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxTrabajos.Enabled = false;
                    }
                }

                this.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
