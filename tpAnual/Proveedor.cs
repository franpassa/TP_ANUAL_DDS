
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {
	public abstract class Proveedor {
		
		public Direccion DireccionPostal { get; set; }

	}//end Proveedor

}//end namespace TPANUAL