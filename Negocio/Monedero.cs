using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Monedero
    {
        public float saldo { get; set; }
        public int IdMonedero { get; set; }

        public Monedero(float saldo, int idMonedero)
        {
            this.saldo = saldo;
            IdMonedero = idMonedero;
        }

        public void crearMonedero(float saldo, int IdMonedero)
        {

        }
        public int ComprobarSaldo()
        {
            return saldo;
        }
    }
}
