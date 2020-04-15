using System;

public interface IDAOMonedero
{
    void CrearMonedero(DTOMonedero monedero);

    int RecuperarMonedero(int id);

}
