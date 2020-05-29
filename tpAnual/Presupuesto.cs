
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Presupuesto {

		private string detalle;
		private DocumentoComercial documentosComerciales;
		private Producto productos;
		private Proveedor proveedor;
		public TPANUAL.Proveedor m_Proveedor;
		public TPANUAL.Producto m_Producto;
		public DocumentoComercial m_DocumentoComercial;

		public Presupuesto(){

		}

		public float valorTotal(){

			return 0;
		}

	}//end Presupuesto

}//end namespace TPANUAL