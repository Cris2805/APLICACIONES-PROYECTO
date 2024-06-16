using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class TrabajoCarpinteria
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public decimal Costo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }

    }
    public class PedidoDetalle
    {
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
    }
    public class Cliente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ciudad { get; set; }
        public int Edad { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public List<TrabajoCarpinteria> TrabajosCarpinteria { get; set; } = new List<TrabajoCarpinteria>(); // Lista de trabajos asociados al cliente
    }

    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; } // Considera usar hashing y salting en lugar de almacenar texto plano
        public string Role { get; set; } // Puede ser "Administrador" o "Cliente"
        public string Cedula { get; set; } // Clave foránea a Cliente
        public Cliente Cliente { get; set; } // Propiedad de navegación
    }
    public class Pedido
    {
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTrabajo { get; set; }
        public string CedulaCliente { get; set; }
    }
}
