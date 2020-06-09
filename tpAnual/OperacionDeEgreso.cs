
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class OperacionDeEgreso {

		private List<DocumentoComercial> documentosComerciales;
		private DateTime fechaOperacion;
		private MedioDePago medioDePago;
		private TipoEgreso tipoEgreso;

		public OperacionDeEgreso(TipoEgreso egreso, MedioDePago medio, List<DocumentoComercial> documentos){
			DocumentosComerciales = documentos;
			FechaOperacion = DateTime.Now;
			MedioDePago = medio;
			TipoEgreso = egreso;
		}

        public DateTime FechaOperacion { get => fechaOperacion; set => fechaOperacion = value; }
        public MedioDePago MedioDePago { get => medioDePago; set => medioDePago = value; }
        public TipoEgreso TipoEgreso { get => tipoEgreso; set => tipoEgreso = value; }
        public List<DocumentoComercial> DocumentosComerciales { get => documentosComerciales; set => documentosComerciales = value; }

        public float valorTotal(){
			return TipoEgreso.valorTotal();
		}

		public void agregarDocumentoComercial(DocumentoComercial documento)
        {
			DocumentosComerciales.Add(documento);
        }

	}//end OperacionDeEgreso

}//end namespace TPANUAL