
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class DocumentoComercial {

		private string IDdocumento;
		private TipoDocumento tipoDocumento;

        public DocumentoComercial(string iDdocumento, TipoDocumento tipoDocumento)
        {
            IDdocumento = iDdocumento;
            this.tipoDocumento = tipoDocumento;
        }
    }//end Documento Comercial

}//end namespace TPANUAL