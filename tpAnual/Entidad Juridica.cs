
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class EntidadJuridica : TipoEntidad {

		private EntidadBase basesAsociadas;
		private string codigoInscripcion;
		private string CUIT;
		private string direccionPostal;
		private string razonSocial;
		public EntidadBase m_EntidadBase;

		public EntidadJuridica(){

		}

	}//end Entidad Juridica

}//end namespace TPANUAL