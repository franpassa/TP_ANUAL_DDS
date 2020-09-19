﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPANUAL
{
    [Table("documentocomercial")]
    public class DocumentoComercial
    {
        [Key]
        [Column("ID_DocumentoComercial")]
        public string ID_DocumentoComercial { get; set; }

        [Column("TipoDocumento")]
        public string TipoDocumento { get; set; }

        public DocumentoComercial(string idDocumento, string tipoDocumento)
        {
            ID_DocumentoComercial = idDocumento;
            TipoDocumento = tipoDocumento;
        }

        public DocumentoComercial() { }
    }
}