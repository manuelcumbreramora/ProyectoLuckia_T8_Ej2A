using System;

 public class Monedero
    {
    private int IdMonedero;
    private float Saldo;
    private string Divisa;
    private int IdUsuario;

    public Monedero(int idMonedero, int idUsuario, float saldo, string divisa)
    {
        this.IdMonedero = idMonedero;
        this.IdUsuario = idUsuario;
        this.Saldo = saldo;
        this.Divisa = divisa;
    }

    public Monedero()
    {

    }

    public float GetSaldo()
    {
        return this.Saldo;
    }
    public void SetSaldo(float saldo)
    {
        this.Saldo = saldo;
    }
    public int GetIdMonedero()
    {
        return this.IdMonedero;
    }
    public void SetIdMonedero(int id)
    {
        this.IdMonedero = id;
    }
    public int GetIdUsuario()
    {
        return this.IdUsuario;

    }
    public void SetIdUsuario(int id)
    {
        this.IdUsuario = id;
    }

    public string GetDivisa()
    {
        return this.Divisa;
    }
    public void SetDivisa(string divisa)
    {
        this.Divisa = divisa;
    }

}