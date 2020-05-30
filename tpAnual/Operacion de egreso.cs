
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

		public OperacionDeEgreso(TipoEgreso egreso, MedioDePago medio){
			documentosComerciales = new List<DocumentoComercial>();
			fechaOperacion = DateTime.Now;
			medioDePago = medio;
			tipoEgreso = egreso;
		}

		public float valorTotal(){
			return tipoEgreso.valorTotal();
		}

	}//end OperacionDeEgreso

}//end namespace TPANUAL