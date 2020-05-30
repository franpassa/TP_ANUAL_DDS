
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Presupuesto {

		private string detalle;
		private List<DocumentoComercial> documentosComerciales;
		private List<Producto> productos;
		private Proveedor proveedor;

		public Presupuesto(Proveedor proveedor,List<Producto> productos){
			this.proveedor = proveedor;
			this.productos = productos;
			this.detalle = null;
			this.documentosComerciales = null;
		}


        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public List<DocumentoComercial> DocumentosComerciales { get => documentosComerciales; set => documentosComerciales = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }

        public float valorTotal(){

			float valor = 0;

			foreach(Producto producto in productos)
            {
				valor += producto.valorTotal();
            }

			return valor;
		}

	}//end Presupuesto

}//end namespace TPANUAL