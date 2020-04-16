using System;

public interface IDAOMonedero
{
    DTOMonedero CrearMonederoDAO(DTOMonedero monederoDTO);

    DTOMonedero RecuperarMonederoPorIdMonederoDAO(int id);

    bool ModificarSaldoMonederoDTO(int idMonederoAmodificar, float saldoNuevo);

    DTOMonedero RecuperarMonederoPorIdUsuarioDAO(int idUsuario);

}
