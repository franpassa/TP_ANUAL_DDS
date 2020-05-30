
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

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Valor { get => valor; set => valor = value; }

        public float valorTotal(){

			return Cantidad*Valor;
		}

	}//end Producto

}//end namespace TPANUAL