
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public abstract class Proveedor {

		private string direccionPostal;

        public string DireccionPostal { get => direccionPostal; set => direccionPostal = value; }

	}//end Proveedor

}//end namespace TPANUAL