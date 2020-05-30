
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

		public Producto(){

		}

		public float valorTotal(){

			return cantidad*valor;
		}

	}//end Producto

}//end namespace TPANUAL