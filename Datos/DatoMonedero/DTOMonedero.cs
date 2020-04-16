using System;

public class DTOMonedero
{
    private int IdMonedero;
    private int IdUsuario;
    private string Divisa;
    private float Saldo;

    public DTOMonedero(int idMonedero, int idUsuario, float saldo, string divisa)
    {
        this.IdMonedero = idMonedero;
        this.IdUsuario = idUsuario;
        this.Saldo = saldo;
        this.Divisa = divisa;
    }

    public DTOMonedero()
    {
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
    public int GetIdUsuarioDTO()
    {
        return this.IdUsuario;
    }
    public void SetIdUsuarioDTO(int id)
    {
        this.IdUsuario = id;
    }
    public string GetDivisaDTO()
    {
        return this.Divisa;
    }
    public void SetDivisaDTO(string divisa)
    {
        this.Divisa = divisa;
    }
}