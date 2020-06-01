
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class EntidadJuridica : TipoEntidad {

		private List<EntidadBase> basesAsociadas;
		private string codigoInscripcion;
		private string CUIT;
		private string direccionPostal;
		private string razonSocial;

        public EntidadJuridica(List<EntidadBase> basesAsociadas, string codigoInscripcion, string CUIT, string direccionPostal, string razonSocial)
        {
            this.basesAsociadas = basesAsociadas;
            this.codigoInscripcion = codigoInscripcion;
            this.CUIT = CUIT;
            this.direccionPostal = direccionPostal;
            this.razonSocial = razonSocial;
        }

    }//end Entidad Juridica

}//end namespace TPANUAL