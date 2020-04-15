using System;

 public class Monedero
    {
        public float saldo { get; set; }
        public int IdMonedero { get; set; }
        public string tipo { get; set; }

        public Monedero(float saldo, int idMonedero, string tipo)
        {
            this.saldo = saldo;
            IdMonedero = idMonedero;
            this.tipo = tipo;
        }

        public Monedero()
        {

        }

        public void CrearMonedero(float saldo, int IdMonedero)
        {
            

        }
        public float ComprobarSaldo()
        {
            return saldo;
        }

        public float restarSaldo()
        {

            return saldo;
        }

        public float sumarSaldo()
        {
            
            return saldo;
        }
    }