
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Item {

		private string descripcion;
        private float valorTotal;

        public Item(string descripcion, float valorTotal) {
            Descripcion = descripcion;
            ValorTotal = valorTotal;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float ValorTotal { get => valorTotal; set => valorTotal = value; }

    }//end Producto

}//end namespace TPANUAL