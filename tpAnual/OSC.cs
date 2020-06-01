
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class OSC : TipoOrganizacion{

        public OSC(Organizacion organizacionAsociada)
        {
            this.Estructura = null;
        }

        public override void definirEstructura(Organizacion organizacion) { }

    }//end OSC

}//end namespace TPANUAL