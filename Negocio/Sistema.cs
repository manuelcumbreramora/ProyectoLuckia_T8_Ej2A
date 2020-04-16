using Datos;
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
        private DAOIMPLMonedero ConexionDBMonedero;
        public Sistema()
        {
            ConexionDBTransaccion = new DAOTransaccion();
            UsuarioDao = new DAOImpUsuario();
            ConexionDBMonedero = new DAOIMPLMonedero();
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

            if (nuevoTransDTO != null)
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

        public Monedero InsertarMonedero(int idUsuario, int saldo, string divisa)
        {

            DTOMonedero nuevoMonederoDTO = new DTOMonedero(0, idUsuario, saldo, divisa);
            nuevoMonederoDTO = this.ConexionDBMonedero.CrearMonederoDAO(nuevoMonederoDTO);

            if (nuevoMonederoDTO != null)
            {
                Monedero monederoIngreso = new Monedero(nuevoMonederoDTO.GetIdMonederoDTO(), nuevoMonederoDTO.GetIdUsuarioDTO(), nuevoMonederoDTO.GetSaldoDTO(), nuevoMonederoDTO.GetDivisaDTO());
                return monederoIngreso;
            }
            return null;

        }
        public Monedero RecuperarMonederoPorIdMonedero(int idMonedero)
        {
            DTOMonedero monederoDTO = this.ConexionDBMonedero.RecuperarMonederoPorIdMonederoDAO(idMonedero);
            if (monederoDTO != null)
            {
                Monedero nuevoMonedero = new Monedero(monederoDTO.GetIdMonederoDTO(), monederoDTO.GetIdUsuarioDTO(), monederoDTO.GetSaldoDTO(), monederoDTO.GetDivisaDTO());
                return nuevoMonedero;
            }

            else
            {
                return null;
            }

        }
        public Monedero RecuperarMonederoPorIdUsuario(int idUsuario)
        {
            DTOMonedero monederoDTO = this.ConexionDBMonedero.RecuperarMonederoPorIdUsuarioDAO(idUsuario);
            if (monederoDTO != null)
            {
                Monedero nuevoMonedero = new Monedero(monederoDTO.GetIdMonederoDTO(), monederoDTO.GetIdUsuarioDTO(), monederoDTO.GetSaldoDTO(), monederoDTO.GetDivisaDTO());
                return nuevoMonedero;
            }

            else
            {
                return null;
            }

        }
        public Monedero IngresarSaldoMonedero(int idMonedero, float importeSumar)
        {
            DTOMonedero monederoDTO = this.ConexionDBMonedero.RecuperarMonederoPorIdMonederoDAO(idMonedero);
            float nuevoSaldo = monederoDTO.GetSaldoDTO() + importeSumar;
            if (this.ConexionDBMonedero.ModificarSaldoMonederoDTO(idMonedero, nuevoSaldo))
            {
                Monedero monederoModificado = new Monedero(monederoDTO.GetIdMonederoDTO(), monederoDTO.GetIdUsuarioDTO(), nuevoSaldo, monederoDTO.GetDivisaDTO());
                return monederoModificado;
            }
            else
            {
                return null;
            }


        }
        public Monedero RetirarSaldoMonedero(int idMonedero, float importeRestar)
        {
            DTOMonedero monederoDTO = this.ConexionDBMonedero.RecuperarMonederoPorIdMonederoDAO(idMonedero);
            float nuevoSaldo = monederoDTO.GetSaldoDTO() - importeRestar;
            if (this.ConexionDBMonedero.ModificarSaldoMonederoDTO(idMonedero, nuevoSaldo))
            {
                Monedero monederoModificado = new Monedero(monederoDTO.GetIdMonederoDTO(), monederoDTO.GetIdUsuarioDTO(), nuevoSaldo, monederoDTO.GetDivisaDTO());
                return monederoModificado;
            }
            else
            {
                return null;
            }


        }



    }
}
