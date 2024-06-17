using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaLogica
{
    public  class ClaseLogicaDatos
    {

        private CdOperaciones operaciones = new CdOperaciones();

       public Usuario Login(string username, string password)
        {
            return operaciones.Login(username, password);
        }

        public void RegistrarCliente(Cliente cliente)
        {
            operaciones.InsertarCliente(cliente);
        }

        public bool VerificarUsuario(string username)
        {
            return operaciones.VerificarUsuario(username);
        }

        public bool VerificarContrasena(string username, string password)
        {
            return operaciones.VerificarContrasena(username, password);
        }
        public bool ExistenUsuariosRegistrados()
        {
            return operaciones.ExistenUsuariosRegistrados();
        }
        public void RegistrarUsuario(Usuario usuario)
        {
            operaciones.InsertarUsuario(usuario);
        }

        public void ActualizarDatosCliente(string cedula, Cliente clienteActualizado)
        {
            operaciones.ActualizarCliente(cedula, clienteActualizado);
        }

        public bool CorreoExiste(string correo)
        {
            return operaciones.CorreoExiste(correo);
        }

        public Cliente BuscarClientePorCorreo(string correo)
        {
            return operaciones.BuscarClientePorCorreo(correo);
        }


        public void EliminarCliente(string cedula)
        {
            operaciones.EliminarCliente(cedula);
        }

        public Usuario VerificarCredenciales(string username, string password)
        {
            return operaciones.Login(username, password);  // Asegúrate de que este método devuelva un objeto Usuario si las credenciales son correctas
        }


        public Cliente BuscarCliente(string cedula)
        {
            return operaciones.BuscarClientePorCedula(cedula);
        }

        public bool UsuarioExiste(string username)
        {
            return operaciones.VerificarUsuario(username);
        }

        public void ActualizarDatosClientePorCorreo(string correoOriginal, Cliente clienteActualizado)
        {
            operaciones.ActualizarClientePorCorreo(correoOriginal, clienteActualizado);
        }


        public bool CedulaExiste(string cedula)
        {
            return operaciones.CedulaExiste(cedula);
        }
        public bool ValidarCedula(string cedula)
        {
            return operaciones.ValidarCedula(cedula);
        }
        public void EliminarUsuariosPorCedula(string cedula)
        {
            operaciones.EliminarUsuarioPorCedula(cedula);
        }

        public Cliente BuscarClientePorNombre(string nombre)
        {
            return operaciones.BuscarClientePorNombre(nombre);
        }

        public void InsertarTrabajoCarpinteria(TrabajoCarpinteria trabajo)
        {
            operaciones.InsertarTrabajoCarpinteria(trabajo);
        }
        public TrabajoCarpinteria BuscarTrabajoPorId(int id)
        {
            return operaciones.BuscarTrabajoPorId(id);
        }

        public void ActualizarTrabajo(int idTrabajo, DateTime fechaInicio, DateTime fechaFin, int cantidad, string estado)
        {
            try
            {
                operaciones.ActualizarTrabajo(idTrabajo, fechaInicio, fechaFin, cantidad, estado);
            }
            catch (Exception ex)
            {
                // Manejar o re-lanzar la excepción según sea necesario
                throw new Exception("No se pudo actualizar el trabajo.", ex);
            }
        }
        public void RegistrarPedido(Pedido pedido)
        {
            operaciones.RegistrarPedido(pedido);
        }
        public List<TrabajoCarpinteria> ObtenerTrabajosCarpinteria()
        {
            return operaciones.ObtenerTrabajosCarpinteria();
        }
        public void ActualizarCantidadTrabajo(int idTrabajo, int nuevaCantidad)
        {
            operaciones.ActualizarCantidadTrabajo(idTrabajo, nuevaCantidad);
        }
        public PedidoDetalle BuscarPedidoPorId(int id)
        {
            return operaciones.BuscarPedidoPorId(id);
        }
        public bool HayPedidosParaProducto(int idProducto)
        {
            return operaciones.HayPedidosParaProducto(idProducto);
        }
        public void EliminarTrabajo(int idProducto)
        {
            operaciones.EliminarTrabajoCarpinteria(idProducto);
            ReiniciarContadorSiNoHayTrabajos();
        }

        private void ReiniciarContadorSiNoHayTrabajos()
        {
            if (!operaciones.HayTrabajos())
            {
                operaciones.ReiniciarContadorTrabajosCarpinteria();
            }
        }
    }
}


