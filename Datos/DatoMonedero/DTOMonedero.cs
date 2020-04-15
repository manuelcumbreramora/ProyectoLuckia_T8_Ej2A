using System;

public class DTOMonedero
{
    public int IdMonedero { get; set; }
    public string Tipo { get; internal set; }
    public string Divisa { get; internal set; }
    public float Saldo { get; internal set; }

    public DTOMonedero(float saldo, int idMonedero, string tipo, string Divisa)
    {
        this.Saldo = saldo;
        this.IdMonedero = idMonedero;
        this.Tipo = tipo;
        this.Divisa = Divisa;
    }

    public DTOMonedero()
    {
    }

    /* public float GetSaldoDTO()
     {
         return this.Saldo;
     }
     public void SetSaldoDTO(float saldo)
     {
         this.Saldo = saldo;
     }
     public int GetIdMonederoDTO()
     {
         return this.IdMonedero;
     }
     public void SetIdMonederoDTO(int id)
     {
         this.IdMonedero = id;
     }
     public string GetTipoDTO()
     {
         return this.Tipo;
     }
     public void SetTipoDTO(string tipo)
     {
         this.Tipo = tipo;
     }*/
}