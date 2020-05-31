
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
		private Organizacion organizacionAsociada;

        /*public TipoOrganizacion(Estructura estructura, Organizacion organizacionAsociada)
        {
            this.Estructura = estructura;
            this.OrganizacionAsociada = organizacionAsociada;
        }*/
        

        public Estructura Estructura { get => estructura; set => estructura = value; }
        public Organizacion OrganizacionAsociada { get => organizacionAsociada; set => organizacionAsociada = value; }

        public abstract void definirEstructura(Actividad actividad);

	}

}//end TipoOrganizacion

//end namespace TPANUAL
