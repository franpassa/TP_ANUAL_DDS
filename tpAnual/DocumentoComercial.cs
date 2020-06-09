using System;
using System.Collections.Generic;
using System.Text;

namespace TPANUAL
{
    public class DocumentoComercial
    {
        private string idDocumento;
        private string tipoDocumento;

        public DocumentoComercial(string idDocumento, string tipoDocumento)
        {
            this.IdDocumento = idDocumento;
            this.tipoDocumento = tipoDocumento;
        }

        public string IdDocumento { get => idDocumento; set => idDocumento = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
    }
}
