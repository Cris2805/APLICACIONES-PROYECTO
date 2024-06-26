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
    public partial class FrmRegistrarPedidoAdmin : Form
    {
        private ClaseLogicaDatos logicaDatos = new ClaseLogicaDatos();
        public FrmRegistrarPedidoAdmin()
        {
            InitializeComponent();
        }

        private void FrmRegistrarPedidoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void ComboxTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboxTrabajo.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = Properties.Resources.reconocido;
                    lbldescripcion.Text = "Puertas con vidrio de calidad superior, \nconocidas por su durabilidad y diseño atractivo";
                    lblPrecio.Text = "$100";
                    break;
                case 1:
                    pictureBox1.Image = Properties.Resources.Templado;
                    lbldescripcion.Text = "Puertas elegantes y seguras, equipadas \n con vidrio templado de alta resistencia";
                    lblPrecio.Text = "$300";
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Laminado;
                    lbldescripcion.Text = "Puertas robustas con vidrio laminado,\n que ofrecen una combinación de seguridad y estilo";
                    lblPrecio.Text = "$200";
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.sillas;
                    lbldescripcion.Text = "Sillas ergonómicas y confortables, diseñadas \n para ofrecer el máximo confort.";
                    lblPrecio.Text = "$25";
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.otros;
                    lbldescripcion.Text = "Productos que no se encuentran \n en las categorías anteriores,\n como mesas, estantes, etc.";
                    lblPrecio.Text = "$100";
                    break;
                default:
                    lbldescripcion.Text = string.Empty;
                    lblPrecio.Text = string.Empty;
                    pictureBox1.Image = null;
                    break;
            }

            // Limpiar y actualizar las opciones de cantidad
            Comboxcantidad.Items.Clear();
            for (int i = 1; i <= 20; i++)
            {
                Comboxcantidad.Items.Add(i.ToString());
            }
            Comboxcantidad.SelectedIndex = 0; // Seleccionar por defecto la cantidad 1
        }

        private void Comboxcantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now.Date;
            DateTime fechaInicio = fechainicio.Value.Date;
            DateTime fechaFin = Fichafin.Value.Date;

            // Validar fecha de inicio
            if (fechaInicio < fechaActual || fechaInicio > fechaActual.AddDays(4))
            {
                MessageBox.Show("La fecha de inicio debe ser desde hoy hasta un máximo de 4 días posteriores.", "Fecha de Inicio Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar fecha de fin
            if (fechaFin < fechaInicio.AddDays(6) || fechaFin > fechaInicio.AddDays(15))
            {
                MessageBox.Show("La fecha de fin debe ser desde 6 hasta 15 días posteriores desde la fecha de inicio.", "Fecha de Fin Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir el precio a un valor numérico
            decimal costo;
            if (!decimal.TryParse(lblPrecio.Text.Replace("$", ""), out costo))
            {
                MessageBox.Show("Error en el formato del precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convertir imagen a bytes
            byte[] imagenBytes = null;
            if (pictureBox1.Image != null)
            {
                imagenBytes = ImageToByteArray(pictureBox1.Image);
            }

            // Asumiendo que ya has validado los datos correctamente
            TrabajoCarpinteria nuevoTrabajo = new TrabajoCarpinteria
            {
                FechaInicio = fechainicio.Value.Date,
                FechaFin = Fichafin.Value.Date,
                Cantidad = int.Parse(Comboxcantidad.Text),
                Estado = ComboxEstado.SelectedItem.ToString(),
                Costo = costo, // Usar el valor numérico del costo
                Descripcion = ComboxTrabajo.SelectedItem.ToString(),
                Foto = imagenBytes
            };

            try
            {
                logicaDatos.InsertarTrabajoCarpinteria(nuevoTrabajo);
                MessageBox.Show("Trabajo registrado con éxito administrador.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
