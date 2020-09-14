
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("presupuesto")]
	public class Presupuesto {

        [Key]
        [Column("ID_Presupuesto")]
        public int ID_Presupuesto { get; set; }

        [Column("Detalle")]
        public string Detalle { get; set; }

        [Column("ID_Compra")]
        public int ID_Compra { get; set; }
        public Compra Compra { get; set; }

        public List<Item> Items { get; set ; }
        public Proveedor Proveedor { get; set; }
        internal List<DocumentoComercial> DocumentosComerciales { get; set; }

        public Presupuesto(Proveedor proveedor, List<Item> items, Compra compra, string detalle)
        {
            Proveedor = proveedor;
            Items = items;
            Detalle = detalle;
            DocumentosComerciales = null;
            Compra = compra;
        }

        public Presupuesto() { }



        public float valorTotal(){

			float valor = 0;

			foreach(Item item in Items)
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