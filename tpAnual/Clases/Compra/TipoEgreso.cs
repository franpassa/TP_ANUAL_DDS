using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {
	public abstract class TipoEgreso {

		[Key]
		[Column("ID_TipoEgreso")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID_TipoEgreso { get; set; }

		public abstract float valorTotal();

		public abstract Task validar();
      
	}//end TipoEgreso

}//end namespace TPANUAL