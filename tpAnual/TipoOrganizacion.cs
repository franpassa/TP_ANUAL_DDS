
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
				for (int j=0; j <= 4; j++)
				{
					if (organizacionAsociada.CantidadPersonal <= organizacionAsociada.Actividad.CantidadPersonalMax[i])
					{
						i++;
					}
				}
				estructura = definirTamaño(i);
			}
			else
			{
				int i = 0;
				for (int j = 0; j <= 4; j++)
				{
					if (organizacionAsociada.CantidadPersonal <= organizacionAsociada.Actividad.CantidadPersonalMax[i] ||
					    organizacionAsociada.PromedioVentas   <= organizacionAsociada.Actividad.PromedioVentasMax[i])
					{
						i++;
					}
				}
				estructura = definirTamaño(i);
			}
		}

		public Estructura definirTamaño(int i)
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
					return new Pequeña();
				default:
					return new Pequeña();
			}
		}
	}

}//end TipoOrganizacion

//end namespace TPANUAL
