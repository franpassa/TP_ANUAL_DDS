
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class Usuario {

		private string constraseña;
		private string nombreUsuario;
		private string tipoUsuario;

        public string Constraseña { get => constraseña; set => constraseña = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }

        public Usuario(string constraseña, string nombreUsuario)
        {
            this.Constraseña = constraseña;
            this.NombreUsuario = nombreUsuario;
            this.TipoUsuario = "estandar";
        }

        public void verMensajes(Compra compra)
        {
            compra.mostrarMensajes(this);
        }

        public bool esRevisor(Compra compra)
        {
            foreach (Usuario usuario in compra.Revisores)
            {
                if (Equals(this, usuario))
                {
                    return true;
                }
            }

            return false;
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

        public bool validarContraseña()
        {
            return ValidadorDeContraseña.getInstanceValidadorContra.validarContraseña(this.Constraseña);
        }

	}//end Usuario

}//end namespace TPANUAL