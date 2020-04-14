using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DatosTransaccion
{
   public class DTOTransaccion
    {
        private int IdTransaccion;
        private float Importe;
        private int IdMonedero;
        private DateTime FechaCreacion;
        private String TipoTransaccion;

        public DTOTransaccion()
        {

        }
        public DTOTransaccion(int idTransaccion, int idMonedero, float importe, DateTime fechaCreacion, string tipoTransaccion)
        {
            IdTransaccion = idTransaccion;
            IdMonedero = idMonedero;
            Importe = importe;
            FechaCreacion = fechaCreacion;
            TipoTransaccion = tipoTransaccion;
        }

        public int GetIdTransaccionDTO()
        {
            return this.IdTransaccion;
        }
        public void SetIdTransaccionDTO(int id)
        {
            this.IdTransaccion = id;
        }
        public int GetIdMonederoDTO()
        {
            return this.IdMonedero;
        }
        public void SetIdMonederoDTO(int id)
        {
            this.IdMonedero = id;
        }
        public float GetImporteDTO()
        {
            return this.Importe;
        }
        public void SetImporteDTO(float imp)
        {
            this.Importe = imp;
        }
        public DateTime GetFechaCreacionDTO()
        {
            return this.FechaCreacion;
        }
        public void SetFechaCreacionDTO(DateTime fecha)
        {
            this.FechaCreacion = fecha;
        }

        public string GetTipoTransaccionDTO()
        {
            return this.TipoTransaccion;
        }
        public void SetTipoTransaccionDTO(string tipo)
        {
            this.TipoTransaccion = tipo;
        }
    }
}
