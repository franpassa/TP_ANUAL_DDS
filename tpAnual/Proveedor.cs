
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Proveedor {

		private string direccionPostal;
		private List<Producto> productosDisponibles;

		public Proveedor(){

		}

        public List<Producto> ProductosDisponibles { get => productosDisponibles; set => productosDisponibles = value; }

		public float damePrecio(string id)
        {
			return productosDisponibles.Find(unProducto => unProducto.IdProducto == id).Valor;
        }

	}//end Proveedor

}//end namespace TPANUAL