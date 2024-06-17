using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;


namespace CapaDatos
{
    public  class CdOperaciones
    {
        private CdConexion conexion = new CdConexion();

        // Método para loguearse como administrador o cliente
        public Usuario Login(string username, string password)
        {
            conexion.abrir();
            // Modificamos la consulta para obtener los datos del usuario en lugar de contarlos
            SqlCommand command = new SqlCommand("SELECT * FROM Usuarios WHERE usuario = @Username AND contrasena = @Password", conexion.conexion);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            SqlDataReader reader = command.ExecuteReader();

            Usuario usuario = null;
            if (reader.Read()) // Si hay datos, construimos el objeto usuario
            {
                usuario = new Usuario
                {
                    Username = reader["usuario"].ToString(),
                    Password = reader["contrasena"].ToString(), // No es ideal devolver la contraseña, considera omitirla
                    Role = reader["rol"].ToString(),
                    Cedula = reader["cedula"].ToString()
                };
            }
            reader.Close();
            conexion.cerrar();
            return usuario;
        }

        public bool VerificarUsuario(string username)
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE usuario = @Username", conexion.conexion);
            command.Parameters.AddWithValue("@Username", username);
            int count = (int)command.ExecuteScalar();
            conexion.cerrar();
            return count > 0;
        }



        public bool VerificarContrasena(string username, string password)
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios WHERE usuario = @Username AND contrasena = @Password", conexion.conexion);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            int count = (int)command.ExecuteScalar();
            conexion.cerrar();
            return count > 0;
        }


        public bool ExistenUsuariosRegistrados()
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Usuarios", conexion.conexion);
            int count = (int)command.ExecuteScalar();
            conexion.cerrar();
            return count > 0;
        }

      

        public void InsertarUsuario(Usuario usuario)
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("INSERT INTO Usuarios (usuario, contrasena, rol, cedula) VALUES (@Username, @Password, @Role, @Cedula)", conexion.conexion);
            command.Parameters.AddWithValue("@Username", usuario.Username);
            command.Parameters.AddWithValue("@Password", usuario.Password);  // Considera hashear esta contraseña antes de almacenarla
            command.Parameters.AddWithValue("@Role", usuario.Role);
            command.Parameters.AddWithValue("@Cedula", usuario.Cedula);  // Asegúrate de que esto coincide con la propiedad modificada de la clase Usuario
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public bool CedulaExiste(string cedula)
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Clientes WHERE Cedula = @Cedula", conexion.conexion);
            command.Parameters.AddWithValue("@Cedula", cedula);
            int resultado = (int)command.ExecuteScalar();
            conexion.cerrar();
            return resultado > 0;
        }
        // Método para validar la cédula
        public bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 10)
                return false;

            int sumaPares = 0;
            int sumaImpares = 0;
            for (int i = 0; i < 9; i += 2)
            {
                sumaImpares += int.Parse(cedula[i].ToString()) * 2 > 9 ? int.Parse(cedula[i].ToString()) * 2 - 9 : int.Parse(cedula[i].ToString()) * 2;
            }

            for (int i = 1; i < 9; i += 2)
            {
                sumaPares += int.Parse(cedula[i].ToString());
            }

            int sumaTotal = sumaPares + sumaImpares;
            int decimo = 10 - (sumaTotal % 10);

            return decimo == int.Parse(cedula[9].ToString()) || (sumaTotal % 10 == 0 && cedula[9] == '0');
        }

        // Método para ingresar datos de cualquier entidad
        public void InsertarCliente(Cliente cliente)
        {
            conexion.abrir();
            string query = "INSERT INTO Clientes (Cedula, Nombre, Apellido, Ciudad, Edad, fecha_nacimiento, correo_electronico) VALUES (@Cedula, @Nombre, @Apellido, @Ciudad, @Edad, @FechaDeNacimiento, @CorreoElectronico)";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cedula", cliente.Cedula);
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            command.Parameters.AddWithValue("@Ciudad", cliente.Ciudad);
            command.Parameters.AddWithValue("@Edad", cliente.Edad);
            command.Parameters.AddWithValue("@FechaDeNacimiento", cliente.FechaDeNacimiento);
            command.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        // Método para actualizar datos de cliente por cédula (la cédula no se actualiza)
        public void ActualizarCliente(string cedula, Cliente clienteActualizado)
        {
            conexion.abrir();
            string query = @"
        UPDATE Clientes SET 
            Nombre = @Nombre,
            Apellido = @Apellido,
            Ciudad = @Ciudad,
            Edad = @Edad,
            fecha_nacimiento = @FechaDeNacimiento,
            correo_electronico = @CorreoElectronico
        WHERE Cedula = @Cedula";

            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Nombre", clienteActualizado.Nombre);
            command.Parameters.AddWithValue("@Apellido", clienteActualizado.Apellido);
            command.Parameters.AddWithValue("@Ciudad", clienteActualizado.Ciudad);
            command.Parameters.AddWithValue("@Edad", clienteActualizado.Edad);
            command.Parameters.AddWithValue("@FechaDeNacimiento", clienteActualizado.FechaDeNacimiento);
            command.Parameters.AddWithValue("@CorreoElectronico", clienteActualizado.CorreoElectronico);
            command.Parameters.AddWithValue("@Cedula", cedula);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public bool CorreoExiste(string correo)
        {
            conexion.abrir();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Clientes WHERE correo_electronico = @Correo", conexion.conexion);
            command.Parameters.AddWithValue("@Correo", correo);
            int resultado = (int)command.ExecuteScalar();
            conexion.cerrar();
            return resultado > 0;
        }

        public Cliente BuscarClientePorCorreo(string correo)
        {
            conexion.abrir();
            string query = "SELECT * FROM Clientes WHERE correo_electronico = @Correo";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Correo", correo);
            SqlDataReader reader = command.ExecuteReader();
            Cliente cliente = null;
            if (reader.Read())
            {
                cliente = new Cliente
                {
                    Nombre = reader["nombre"].ToString(),
                    Apellido = reader["apellido"].ToString(),
                    Ciudad = reader["ciudad"].ToString(),
                    Edad = Convert.ToInt32(reader["edad"]),
                    FechaDeNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                    CorreoElectronico = reader["correo_electronico"].ToString()
                };
            }
            reader.Close();
            conexion.cerrar();
            return cliente;
        }




        // Método para eliminar cliente por cédula
        public void EliminarCliente(string cedula)
        {
            conexion.abrir();
            string query = "DELETE FROM Clientes WHERE cedula = @Cedula";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cedula", cedula);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        // Método para buscar cliente por cédula
        public Cliente BuscarClientePorCedula(string cedula)
        {
            conexion.abrir();
            string query = "SELECT * FROM Clientes WHERE Cedula = @Cedula";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cedula", cedula);
            SqlDataReader reader = command.ExecuteReader();
            Cliente cliente = null;
            if (reader.Read())
            {
                cliente = new Cliente
                {
                    Cedula = reader["Cedula"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Ciudad = reader["Ciudad"].ToString(),
                    Edad = Convert.ToInt32(reader["Edad"]),
                    FechaDeNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                    CorreoElectronico = reader["correo_electronico"].ToString()
                };
            }
            reader.Close();
            conexion.cerrar();
            return cliente;
        }

        public void ActualizarClientePorCorreo(string correoOriginal, Cliente clienteActualizado)
        {
            conexion.abrir();
            string query = @"
                UPDATE Clientes SET 
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    Ciudad = @Ciudad,
                    Edad = @Edad,
                    fecha_nacimiento = @FechaDeNacimiento,
                    correo_electronico = @NuevoCorreo
                WHERE correo_electronico = @CorreoOriginal";

            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Nombre", clienteActualizado.Nombre);
            command.Parameters.AddWithValue("@Apellido", clienteActualizado.Apellido);
            command.Parameters.AddWithValue("@Ciudad", clienteActualizado.Ciudad);
            command.Parameters.AddWithValue("@Edad", clienteActualizado.Edad);
            command.Parameters.AddWithValue("@FechaDeNacimiento", clienteActualizado.FechaDeNacimiento);
            command.Parameters.AddWithValue("@NuevoCorreo", clienteActualizado.CorreoElectronico);
            command.Parameters.AddWithValue("@CorreoOriginal", correoOriginal);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public Cliente BuscarClientePorNombre(string nombre)
        {
            conexion.abrir();
            string query = "SELECT * FROM Clientes WHERE Nombre = @Nombre";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataReader reader = command.ExecuteReader();
            Cliente cliente = null;
            if (reader.Read())
            {
                cliente = new Cliente
                {
                    Cedula = reader["Cedula"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Ciudad = reader["Ciudad"].ToString(),
                    Edad = Convert.ToInt32(reader["Edad"]),
                    FechaDeNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                    CorreoElectronico = reader["correo_electronico"].ToString()
                };
            }
            reader.Close();
            conexion.cerrar();
            return cliente;
        }

        public void EliminarUsuarioPorCedula(string cedula)
        {
            conexion.abrir();
            string query = "DELETE FROM Usuarios WHERE cedula = @Cedula";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cedula", cedula);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public void InsertarTrabajoCarpinteria(TrabajoCarpinteria trabajo)
        {
            conexion.abrir();
            string query = @"
            INSERT INTO TrabajosCarpinteria (fecha_inicio, fecha_finalizacion, cantidad, estado, costo, descripcion, foto)
            VALUES (@FechaInicio, @FechaFin, @Cantidad, @Estado, @Costo, @Descripcion, @Foto)";

            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@FechaInicio", trabajo.FechaInicio);
            command.Parameters.AddWithValue("@FechaFin", trabajo.FechaFin);
            command.Parameters.AddWithValue("@Cantidad", trabajo.Cantidad);
            command.Parameters.AddWithValue("@Estado", trabajo.Estado);
            command.Parameters.AddWithValue("@Costo", trabajo.Costo);
            command.Parameters.AddWithValue("@Descripcion", trabajo.Descripcion);
            command.Parameters.AddWithValue("@Foto", trabajo.Foto);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }
        public TrabajoCarpinteria BuscarTrabajoPorId(int id)
        {
            conexion.abrir();
            string query = "SELECT * FROM TrabajosCarpinteria WHERE id = @Id";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();
            TrabajoCarpinteria trabajo = null;

            if (reader.Read())
            {
                trabajo = new TrabajoCarpinteria
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    FechaInicio = reader.GetDateTime(reader.GetOrdinal("fecha_inicio")),
                    FechaFin = reader.GetDateTime(reader.GetOrdinal("fecha_finalizacion")),
                    Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                    Estado = reader.GetString(reader.GetOrdinal("estado")),
                    Costo = reader.GetDecimal(reader.GetOrdinal("costo")),
                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                    Foto = (byte[])reader["foto"] // Asegúrate de manejar adecuadamente los datos binarios
                };
            }

            reader.Close();
            conexion.cerrar();
            return trabajo;
        }
        public void ActualizarTrabajo(int id, DateTime fechaInicio, DateTime fechaFin, int cantidad, string estado)
        {
            conexion.abrir();
            string query = @"
             UPDATE TrabajosCarpinteria SET
                fecha_inicio = @FechaInicio,
                fecha_finalizacion = @FechaFin,
            cantidad = @Cantidad,
                estado = @Estado
             WHERE id = @ID";

            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            command.Parameters.AddWithValue("@FechaFin", fechaFin);
            command.Parameters.AddWithValue("@Cantidad", cantidad);
            command.Parameters.AddWithValue("@Estado", estado);
            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }
        public void RegistrarPedido(Pedido pedido)
        {
            conexion.abrir();
            string query = @"
            INSERT INTO Pedidos (cantidad, total, fecha, id_trabajo, cedula_cliente)
            VALUES (@Cantidad, @Total, @Fecha, @IdTrabajo, @CedulaCliente)";

            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
            command.Parameters.AddWithValue("@Total", pedido.Total);
            command.Parameters.AddWithValue("@Fecha", pedido.Fecha);
            command.Parameters.AddWithValue("@IdTrabajo", pedido.IdTrabajo);
            command.Parameters.AddWithValue("@CedulaCliente", pedido.CedulaCliente);

            command.ExecuteNonQuery();
            conexion.cerrar();
        }
        public List<TrabajoCarpinteria> ObtenerTrabajosCarpinteria()
        {
            List<TrabajoCarpinteria> trabajos = new List<TrabajoCarpinteria>();
            conexion.abrir();
            string query = "SELECT id, descripcion, cantidad, costo, foto FROM TrabajosCarpinteria"; // Incluye la columna foto
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                trabajos.Add(new TrabajoCarpinteria
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Descripcion = reader["descripcion"].ToString(),
                    Cantidad = int.Parse(reader["cantidad"].ToString()),
                    Costo = decimal.Parse(reader["costo"].ToString()),
                    Foto = reader["foto"] as byte[] // Asegúrate de manejar los datos binarios correctamente
                });
            }

            reader.Close();
            conexion.cerrar();
            return trabajos;
        }

        public void ActualizarCantidadTrabajo(int idTrabajo, int nuevaCantidad)
        {
            conexion.abrir();
            string query = "UPDATE TrabajosCarpinteria SET cantidad = @Cantidad WHERE id = @IdTrabajo";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
            command.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public PedidoDetalle BuscarPedidoPorId(int id)
        {
            conexion.abrir();
            string query = @"
        SELECT p.cantidad, p.total, p.fecha, tc.descripcion, tc.estado, tc.foto
        FROM Pedidos p
        INNER JOIN TrabajosCarpinteria tc ON p.id_trabajo = tc.id
        WHERE p.id = @Id";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Id", id);

            SqlDataReader reader = command.ExecuteReader();
            PedidoDetalle pedidoDetalle = null;

            if (reader.Read())
            {
                pedidoDetalle = new PedidoDetalle
                {
                    Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                    Total = reader.GetDecimal(reader.GetOrdinal("total")),
                    Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                    Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                    Estado = reader.GetString(reader.GetOrdinal("estado")),
                    Foto = reader["foto"] as byte[]  // Asegúrate de manejar adecuadamente los datos binarios
                };
            }

            reader.Close();
            conexion.cerrar();
            return pedidoDetalle;
        }
        public bool HayPedidosParaProducto(int idProducto)
        {
            conexion.abrir();
            string query = "SELECT COUNT(*) FROM Pedidos WHERE id_trabajo = @IdProducto";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@IdProducto", idProducto);
            int count = (int)command.ExecuteScalar();
            conexion.cerrar();
            return count > 0;
        }
        public void EliminarPedidosPorTrabajo(int idProducto)
        {
            conexion.abrir();
            string query = "DELETE FROM Pedidos WHERE id_trabajo = @IdProducto";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@IdProducto", idProducto);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

        public void EliminarTrabajoCarpinteria(int id)
        {
            // Primero eliminar los pedidos asociados
            EliminarPedidosPorTrabajo(id);

            // Luego eliminar el trabajo
            conexion.abrir();
            string query = "DELETE FROM TrabajosCarpinteria WHERE id = @Id";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }
        public bool HayTrabajos()
        {
            conexion.abrir();
            string query = "SELECT COUNT(*) FROM TrabajosCarpinteria";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            int count = (int)command.ExecuteScalar();
            conexion.cerrar();
            return count > 0;
        }
        public void ReiniciarContadorTrabajosCarpinteria()
        {
            conexion.abrir();
            string query = "DBCC CHECKIDENT ('TrabajosCarpinteria', RESEED, 0)";
            SqlCommand command = new SqlCommand(query, conexion.conexion);
            command.ExecuteNonQuery();
            conexion.cerrar();
        }

    }
}

