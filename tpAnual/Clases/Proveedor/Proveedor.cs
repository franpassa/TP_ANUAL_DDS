
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
	public abstract class Proveedor {
		[Key]
		[Column("ID_Proveedor")]
		public int ID_Proveedor { get; set; }

	}//end Proveedor

}//end namespace TPANUAL