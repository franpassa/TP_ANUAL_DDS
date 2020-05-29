
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Producto {

		private int cantidad;
		private string descripcion;
		private string idProducto;
		private float valor;
		public TPANUAL.Compra m_Compra;
		public TPANUAL.Presupuesto m_Presupuesto;
		public TPANUAL.Proveedor m_Proveedor;

		public Producto(){

		}

		public float valorTotal(){

			return 0;
		}

	}//end Producto

}//end namespace TPANUAL