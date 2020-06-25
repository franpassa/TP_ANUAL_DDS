using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TPANUAL {
	public abstract class TipoEgreso {

		public abstract float valorTotal();

		public abstract Task ValidarCompra();
      
	}//end TipoEgreso

}//end namespace TPANUAL