
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL
{
	public class TipoOrganizacion
	{

		private Estructura estructura;
		private Organizacion organizacionAsociada;
		public TPANUAL.Estructura m_Estructura;

		public TipoOrganizacion()
		{

		}

		public void definirEstructura(Actividad actividad)
		{
			if (organizacionAsociada.EsActividadComisionistaoAgenciaDeViaje)
			{
				int i = 0;
				foreach (organizacionAsociada.Actividad.CantidadPersonalMax)
				{
					if (organizacionAsociada.CantidadPersonal <= organizacionAsociada.Actividad.CantidadPersonalMax[i])
					{
						i++;
					}
				}
				estructura = definirTama�o(i);
			}
			else
			{
				int i = 0;
				foreach (organizacionAsociada.Actividad.CantidadPersonalMax)
				{
					if (organizacionAsociada.CantidadPersonal <= organizacionAsociada.Actividad.CantidadPersonalMax[i] ||
					    organizacionAsociada.PromedioVentas   <= organizacionAsociada.Actividad.PromedioVentasMax[i])
					{
						i++;
					}
				}
				estructura = definirTama�o(i);
			}
		}

		public Estructura definirTama�o(int i)
		{
			switch (i)
			{
				case 0:
					return new Micro();
				case 1:
					return new MedianaTramo1();
				case 2:
					return new MedianaTramo2();
				case 3:
					return new Peque�a();
			}
		}
	}

}//end TipoOrganizacion

}//end namespace TPANUAL