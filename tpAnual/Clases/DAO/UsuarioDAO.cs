using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TPANUAL.Clases.DAO
{
    public class UsuarioDAO
    {
        private UsuarioDAO() { }

        // Metodo estático que apartir de un string _usuario y _contraseña
        // devuelve el usuario de la base de datos, o null si no lo encuentra
        public static Usuario iniciarSesion(string _usuario, string _contraseña)
        {
            using (var contexto = new DB_Context())
            {
                // Selecciono el usuario y la contraseña que me dan en la base de datos
                var usuario = contexto.usuario
                    .Where(u =>
                        (u.NombreUsuario == _usuario)
                        &&
                        (u.Contraseña == _contraseña))
                    .FirstOrDefault();

                if (usuario != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public static Usuario registrarse(string _usuario, string _contraseña)
        {
            if (!ValidadorDeContraseña.getInstanceValidadorContra().validarContraseña(_contraseña))
            {
                return null;
            }
            else
            {
                using (var contexto = new DB_Context())
                {
                    Usuario usuarioNuevo = new Usuario(_contraseña, _usuario);
                    contexto.usuario.Add(usuarioNuevo);
                    contexto.SaveChanges();
                    return usuarioNuevo;
                }
            }
        }
    }
}
