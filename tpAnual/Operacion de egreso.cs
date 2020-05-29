
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class OperacionDeEgreso {

		private DocumentoComercial documentosComerciales;
		private DateTime fechaOperacion;
		private MedioDePago medioDePago;
		private TipoEgreso tipoEgreso;
		public MedioDePago m_MedioDePago;
		public DocumentoComercial m_DocumentoComercial;
		public TipoEgreso m_TipoEgreso;

		public OperacionDeEgreso(){

		}

		public float valorTotal(){

			return 0;
		}

	}//end OperacionDeEgreso

}//end namespace TPANUAL