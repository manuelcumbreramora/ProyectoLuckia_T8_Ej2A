using Datos.DatosTransaccion;
using Datos.UsuarioDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Sistema
    {
        private DAOTransaccion ConexionDBTransaccion;
        private DAOImpUsuario UsuarioDao;
        public Sistema()
        {
            ConexionDBTransaccion = new DAOTransaccion();
            UsuarioDao = new DAOImpUsuario();
        }

        public Usuario CrearUsuario(String Login, String Pass)
        {
            UsuarioDTO usuario = new UsuarioDTO(Login, Pass);
            usuario = this.UsuarioDao.AgregarUsuario(usuario);
            if (usuario.IdUsuario != null)
            {
                Usuario result = new Usuario(usuario.IdUsuario.GetValueOrDefault(), usuario.Login, usuario.Pass, usuario.EstadoCuenta, usuario.FechaCreacion);
                return result;
            }
            return null;

        }

        public Usuario ExisteLogin(String Login)
        {
            int? IdUsuario = this.UsuarioDao.BuscarUsuario(Login);
            if (IdUsuario != null)
            {
                return this.RecuperarUsuarioPorId(IdUsuario.GetValueOrDefault());
            }
            else
            {
                return null;
            }
        }

        public Usuario VerificarLogin(String Login, String Pass)
        {
            int? IdUsuario=this.UsuarioDao.BuscarUsuario(Login, Pass);
            if (IdUsuario != null)
            {
                return this.RecuperarUsuarioPorId(IdUsuario.GetValueOrDefault());
            }
            else
            {
                return null;
            }
        }

        public Usuario RecuperarUsuarioPorId(int IdUsuario)
        {
            UsuarioDTO usuario = this.UsuarioDao.RecuperarUsuario(IdUsuario);
            Usuario result = new Usuario(usuario.IdUsuario.GetValueOrDefault(), usuario.Login, usuario.Pass, usuario.EstadoCuenta, usuario.FechaCreacion);
            return result;
        }

        //TODO: Terminar este método agragando la parte de monedero
        public Usuario RegistroUsuario(String Login, String Pass)
        {
            Usuario usuario = this.CrearUsuario(Login, Pass);
            //Monedero monedero=new Monedero(usuario.GetIdUsuario());          

            return null;
        }

        public Transaccion InsertarTransaccion(int idMonedero, int importe, string tipo)
        {

            DTOTransaccion nuevoTransDTO = new DTOTransaccion(0, idMonedero, importe, DateTime.Now, tipo);
            nuevoTransDTO = this.ConexionDBTransaccion.AgregarTransaccionDAO(nuevoTransDTO);

            if (nuevoTransDTO.GetIdTransaccionDTO() != 0)
            {
                Transaccion transIngreso = new Transaccion(nuevoTransDTO.GetIdTransaccionDTO(), nuevoTransDTO.GetIdMonederoDTO(), nuevoTransDTO.GetImporteDTO(), nuevoTransDTO.GetFechaCreacionDTO(), nuevoTransDTO.GetTipoTransaccionDTO());
                return transIngreso;
            }
            return null;

        }

        public Transaccion RecuperarTransaccionPorIdTransaccion(int id)
        {
            DTOTransaccion transDTO = this.ConexionDBTransaccion.RecuperarTransaccionPorIdTransaccionDAO(id);
            if (transDTO != null)
            {
                Transaccion nuevaTrans = new Transaccion(transDTO.GetIdTransaccionDTO(), transDTO.GetIdMonederoDTO(), transDTO.GetImporteDTO(), transDTO.GetFechaCreacionDTO(), transDTO.GetTipoTransaccionDTO());
                return nuevaTrans;
            }

            else
            {
                return null;
            }

        }

        public List<Transaccion> RecuperarListaTransaccionPorIdMonedero(int id)
        {
            List<DTOTransaccion> listaTransDTO = this.ConexionDBTransaccion.RecuperarTransaccionPorIdMonederoDAO(id);
            List<Transaccion> listaTransacciones = new List<Transaccion>();

            foreach (DTOTransaccion oDTO in listaTransDTO)
            {
                Transaccion nuevaTrans = new Transaccion(oDTO.GetIdTransaccionDTO(), oDTO.GetIdMonederoDTO(), oDTO.GetImporteDTO(), oDTO.GetFechaCreacionDTO(), oDTO.GetTipoTransaccionDTO());

                listaTransacciones.Add(nuevaTrans);
            }
            return listaTransacciones;

        }

        public List<Transaccion> RecuperarListaTransaccionPorIdUsuario(int idUser)
        {
            List<DTOTransaccion> listaTransDTO = this.ConexionDBTransaccion.RecuperarTransaccionPorIdUsuarioDAO(idUser);
            List<Transaccion> listaTransacciones = new List<Transaccion>();

            foreach (DTOTransaccion oDTO in listaTransDTO)
            {
                Transaccion nuevaTrans = new Transaccion(oDTO.GetIdTransaccionDTO(), oDTO.GetIdMonederoDTO(), oDTO.GetImporteDTO(), oDTO.GetFechaCreacionDTO(), oDTO.GetTipoTransaccionDTO());

                listaTransacciones.Add(nuevaTrans);
            }
            return listaTransacciones;

        }
    }
}
