
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Proveedor {

		private string direccionPostal;
		private List<Producto> productosDisponibles;

        public Proveedor(string direccionPostal, List<Producto> productosDisponibles)
        {
            this.direccionPostal = direccionPostal;
            this.productosDisponibles = productosDisponibles;
        }

        public List<Producto> ProductosDisponibles { get => productosDisponibles; set => productosDisponibles = value; }

		public float damePrecio(string id)
        {
			return productosDisponibles.Find(unProducto => unProducto.IdProducto == id).Valor;
        }

		public Presupuesto crearPresupuesto(Compra compra)
        {
			List<Producto> productos = compra.ProductosRequeridos;

			foreach(Producto producto in productos)
            {
				producto.Valor = damePrecio(producto.IdProducto);
            }

			return new Presupuesto(this, productos);
        }

	}//end Proveedor

}//end namespace TPANUAL