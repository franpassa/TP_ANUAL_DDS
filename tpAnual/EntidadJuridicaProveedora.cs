
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class EntidadJuridicaProveedora : Proveedor {

		private string codigoInscripcion;
		private string CUIT;
		private string razonSocial;

        public EntidadJuridicaProveedora(string direccionPostal, string codigoInscripcion, string CUIT, string razonSocial)
        {
            this.DireccionPostal = direccionPostal;
            this.codigoInscripcion = codigoInscripcion;
            this.CUIT = CUIT;
            this.razonSocial = razonSocial;
        }

    }//end EntidadJuridicaProveedora

}//end namespace TPANUAL