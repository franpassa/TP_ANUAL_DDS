
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class Usuario {

		private string constrase�a;
		private string nombreUsuario;
		private string tipoUsuario;

        public string Constrase�a { get => constrase�a; set => constrase�a = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }

        public Usuario(string constrase�a, string nombreUsuario)
        {
            this.Constrase�a = constrase�a;
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

        public bool validarContrase�a()
        {
            return ValidadorDeContrase�a.getInstanceValidadorContra.validarContrase�a(this.Constrase�a);
        }

	}//end Usuario

}//end namespace TPANUAL