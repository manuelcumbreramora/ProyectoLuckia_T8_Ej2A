using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocio;

namespace Presentacion.Service
{
    public class SistemasService
    {
        Sistema sistema = new Sistema();
        public Transaccion insertarTransaccion(int idMonedero, int importe, string tipo)
        {
            return sistema.InsertarTransaccion(idMonedero, importe, tipo);
        }

        public List<Transaccion> RecuperarListaTransaccionPorIdMonedero(int idMonedero)
        {
            return sistema.RecuperarListaTransaccionPorIdMonedero(idMonedero);

        }

        public List<Transaccion> RecuperarListaTransaccionPorIdUsuario(int idUser)
        {
            return sistema.RecuperarListaTransaccionPorIdUsuario(idUser);
        }

        public Usuario CrearUsuario(String Login, String Pass)
        {
            return sistema.CrearUsuario(Login, Pass);
        }
        public Usuario ExisteLogin(String Login)
        {
            return sistema.ExisteLogin(Login);
        }
        public Usuario VerificarLogin(String Login, String Pass)
        {
            return sistema.VerificarLogin(Login, Pass);
        }
        public Usuario RecuperarUsuarioPorId(int IdUsuario)
        {
            return sistema.RecuperarUsuarioPorId(IdUsuario);
        }
        public Usuario RegistroUsuario(String Login, String Pass)
        {
            return sistema.RegistroUsuario(Login, Pass);
        }
    }
}