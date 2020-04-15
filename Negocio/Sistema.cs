using Datos.DatosTransaccion;
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
        public Sistema()
        {
            ConexionDBTransaccion = new DAOTransaccion();
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
