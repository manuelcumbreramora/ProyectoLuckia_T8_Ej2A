using System;

public interface IDAOMonedero
{
    void CrearMonedero(DTOMonedero monedero);

    float ComprobarSaldo(DTOMonedero monedero);

    float restarSaldo(DTOMonedero monedero);

    float sumarSaldo(DTOMonedero monedero);

}
