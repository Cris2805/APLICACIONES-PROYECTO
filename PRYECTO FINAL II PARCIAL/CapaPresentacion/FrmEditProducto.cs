﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class FrmEditProducto : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmEditProducto()
        {
            InitializeComponent();
            DesactivarCampos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        void SetComboBoxCantidad(int cantidad)
        {
            // Suponiendo que los valores en el ComboBox son strings que representan números
            string cantidadStr = cantidad.ToString();
            int index = Comboxcantidad.FindStringExact(cantidadStr);
            if (index != -1)
            {
                Comboxcantidad.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Cantidad no encontrada en las opciones disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DesactivarCampos()
        {
            lblCedula.Enabled = false;
            BtnGuardar.Enabled = false;
            Comboxcantidad.Enabled = false;
            ComboxEstado.Enabled = false;
            fechainicio.Enabled = false;
            Fichafin.Enabled = false;
        }

        private void ActivarCampos()
        {
            lblCedula.Enabled = true;
            BtnGuardar.Enabled = true;
            Comboxcantidad.Enabled = true;
            ComboxEstado.Enabled = true;
            fechainicio.Enabled = true;
            Fichafin.Enabled = true;
        }
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Maneja el evento para que no suene un beep

                int idProducto;
                if (int.TryParse(txtIDProducto.Text, out idProducto))
                {
                    try
                    {
                        var trabajo = logicaDatos.BuscarTrabajoPorId(idProducto);
                        if (trabajo != null)
                        {
                            lblTipoTrabajo.Text = trabajo.Descripcion;
                            ComboxEstado.SelectedItem = trabajo.Estado;
                            fechainicio.Value = trabajo.FechaInicio;
                            Fichafin.Value = trabajo.FechaFin;
                            // Establece la cantidad en el ComboBox
                            SetComboBoxCantidad(trabajo.Cantidad);

                            pictureBox1.Image = ConvertByteArrayToImage(trabajo.Foto);

                            // Activa los campos y botones
                            ActivarCampos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto con el ID proporcionado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Desactiva los campos y botones
                            DesactivarCampos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al buscar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Desactiva los campos y botones en caso de error
                        DesactivarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID válido.", "ID Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Desactiva los campos y botones
                    DesactivarCampos();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaActual = DateTime.Now.Date;
                DateTime fechaInicio = fechainicio.Value.Date;
                DateTime fechaFin = Fichafin.Value.Date;

                if (fechaInicio < fechaActual || fechaInicio > fechaActual.AddDays(4))
                {
                    MessageBox.Show("La fecha de inicio debe ser desde hoy hasta un máximo de 4 días posteriores.", "Fecha de Inicio Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (fechaFin < fechaInicio.AddDays(6) || fechaFin > fechaInicio.AddDays(15))
                {
                    MessageBox.Show("La fecha de fin debe ser desde 6 hasta 15 días posteriores desde la fecha de inicio.", "Fecha de Fin Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idTrabajo = int.Parse(txtIDProducto.Text);
                string estado = ComboxEstado.SelectedItem.ToString();
                int cantidad = int.Parse(Comboxcantidad.SelectedItem.ToString());

                logicaDatos.ActualizarTrabajo(idTrabajo, fechaInicio, fechaFin, cantidad, estado);

                MessageBox.Show("Producto actualizado correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
