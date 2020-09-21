
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {
	public abstract class TipoEntidad {

		[Key]
		[Column("ID_Entidad")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_Entidad { get; set; }

		[Column("ID_Direccion")]
		public int? ID_Direccion { get; set; }
		public Direccion DireccionPostal { get; set; }

	}//end TipoEntidad

}//end namespace TPANUAL