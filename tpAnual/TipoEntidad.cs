
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {
	public abstract class TipoEntidad {

		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int ID_Entidad { get; set; }

	}//end TipoEntidad

}//end namespace TPANUAL