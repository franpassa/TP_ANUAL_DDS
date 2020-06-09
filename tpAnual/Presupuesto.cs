
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Presupuesto {

		private string detalle;
		private List<DocumentoComercial> documentosComerciales;
		private List<Item> items;
		private Proveedor proveedor;

		public Presupuesto(Proveedor proveedor,List<Item> items){
			this.proveedor = proveedor;
			this.items = items;
			this.detalle = null;
			this.documentosComerciales = null;
		}


        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public List<Item> Items { get => items; set => items = value; }
        internal List<DocumentoComercial> DocumentosComerciales { get => documentosComerciales; set => documentosComerciales = value; }

        public float valorTotal(){

			float valor = 0;

			foreach(Item item in items)
            {
				valor += item.ValorTotal;
            }

			return valor;
		}

        public void agregarDocumentosComerciales(DocumentoComercial documento)
        {
            DocumentosComerciales.Add(documento);
        }

	}//end Presupuesto

}//end namespace TPANUAL