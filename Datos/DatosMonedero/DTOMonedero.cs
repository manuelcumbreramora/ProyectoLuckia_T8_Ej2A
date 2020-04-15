using System;

public class DTOMonedero
{
    public float Saldo { get; set; }
    public int IdMonedero { get; set; }
    public string Tipo { get; set; }

    public DTOMonedero(float saldo, int idMonedero, string tipo)
    {
        this.Saldo = saldo;
        this.IdMonedero = idMonedero;
        this.Tipo = tipo;
    }

    public float GetSaldoDTO()
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
    }
}