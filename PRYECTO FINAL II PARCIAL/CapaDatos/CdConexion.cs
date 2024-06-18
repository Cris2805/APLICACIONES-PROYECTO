using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CdConexion
    {
        public string cadena = "Data Source = PC_JUANCHO; Initial Catalog = Carpinteria; Integrated Security = True";
        public SqlConnection conexion = new SqlConnection();
        public CdConexion()
        {
            conexion.ConnectionString = cadena; conexion.Open();
        }
        public void abrir()
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión", ex.Message);
            }

        }

        public void cerrar()
        {
            try
            {
                conexion.Close();
                Console.WriteLine("Conexión cerrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión", ex.Message);
            }
        }
    }
}
