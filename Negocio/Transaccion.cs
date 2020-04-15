using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class Transaccion
    {
        private int IdTransaccion;
        private float Importe;
        private int IdMonedero;
        private DateTime FechaCreacion;
        private String TipoTransaccion;

        public Transaccion()
        {

        }
        public Transaccion(int idTransaccion, int idMonedero, float importe, DateTime fechaCreacion, string tipoTransaccion)
        {
            IdTransaccion = idTransaccion;
            IdMonedero = idMonedero;
            Importe = importe;
            FechaCreacion = fechaCreacion;
            TipoTransaccion = tipoTransaccion;
        }

        public int GetIdTransaccion()
        {
            return this.IdTransaccion;
        }
        public void SetIdTransaccion(int id)
        {
            this.IdTransaccion = id;
        }
        public int GetIdMonedero()
        {
            return this.IdMonedero;
        }
        public void SetIdMonedero(int id)
        {
            this.IdMonedero = id;
        }
        public float GetImporte()
        {
            return this.Importe;
        }
        public void SetImporte(float imp)
        {
            this.Importe = imp;
        }
        public DateTime GetFechaCreacion()
        {
            return this.FechaCreacion;
        }
        public void SetFechaCreacion(DateTime fecha)
        {
            this.FechaCreacion = fecha;
        }

        public string GetTipoTransaccion()
        {
            return this.TipoTransaccion;
        }
        public void SetTipoTransaccion(string tipo)
        {
            this.TipoTransaccion = tipo;
        }
    }
}
