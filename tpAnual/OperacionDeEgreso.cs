
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {

	[Table("operaciondeegreso")]
	public class OperacionDeEgreso {
		[Key]

		[Column("ID_Egreso")]
		public int ID_Egreso { get; set; }

		[Column("ID_Ingreso")]
		public int ID_Ingreso { get; set; }

		[Column("ID_Organizacion")]
		public int ID_Organizacion { get; set; }

		[Column("Fecha")]
		public DateTime FechaOperacion { get; set; }
        public MedioDePago MedioDePago { get; set; }
        public TipoEgreso TipoEgreso { get; set; }
        public List<DocumentoComercial> DocumentosComerciales { get; set; }
        public OperacionDeIngreso IngresoAsociado { get; set; }

		public OperacionDeEgreso(TipoEgreso egreso, MedioDePago medio, List<DocumentoComercial> documentos)
		{
			DocumentosComerciales = documentos;
			FechaOperacion = DateTime.Now;
			MedioDePago = medio;
			TipoEgreso = egreso;
		}

		public OperacionDeEgreso() { }

		public float valorTotal(){
			return TipoEgreso.valorTotal();
		}

		public void agregarDocumentoComercial(DocumentoComercial documento)
        {
			DocumentosComerciales.Add(documento);
        }

    }//end OperacionDeEgreso

}//end namespace TPANUAL