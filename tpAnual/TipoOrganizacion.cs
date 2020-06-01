
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL
{
	public abstract class TipoOrganizacion
	{

		private Estructura estructura;

        public Estructura Estructura { get => estructura; set => estructura = value; }

        public abstract void definirEstructura(Organizacion organizacion);

	}

}//end TipoOrganizacion

//end namespace TPANUAL
