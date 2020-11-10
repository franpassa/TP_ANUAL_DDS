using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TPANUAL {

    [Table("usuario")]
	public class Usuario {

        [Key]
        [Column("ID_Usuario")]
        public int ID_Usuario { get; set; }

        [Column("Contraseņa")]
        public string Contraseņa { get; set; }

        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; }

        [Column("TipoUsuario")]
        public string TipoUsuario { get; set; }

        [Column("ID_Organizacion")]
        public int? ID_organizacion { get; set; }
        public Organizacion organizacionAsociada { get; set; }

        public List<Compra> ComprasRevisables{ get; set; }

        public Usuario(string contraseņa, string nombreUsuario)
        {
            Contraseņa = contraseņa;
            NombreUsuario = nombreUsuario;
            TipoUsuario = "estandar";
        }

        public Usuario() { }

        public void verMensajes(Compra compra)
        {
            compra.mostrarMensajes(this);
        }

        public void cambiarTipoUsuario()
        {
            if(TipoUsuario == "estandar")
            {
                TipoUsuario = "administrador";
            }
            else{
                TipoUsuario = "estandar";
            }
        }

        public bool validarContraseņa()
        {
            return ValidadorDeContraseņa.getInstanceValidadorContra().validarContraseņa(this.Contraseņa);
        }

        // Devuelve -1 si no encuentra al usuario, pero si existe devuelve el ID
        public static Usuario iniciarSesion(string _usuario, string _contraseņa)
        {
            using (var contexto = new DB_Context())
            {
                // Selecciono el usuario y la contraseņa que me dan en la base de datos
                var usuario = contexto.usuario
                    .Where(u =>
                        (u.NombreUsuario == _usuario)
                        &&
                        (u.Contraseņa == _contraseņa))
                    .FirstOrDefault();

                if(usuario != null)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
        }

	}//end Usuario

}//end namespace TPANUAL