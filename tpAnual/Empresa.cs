
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Empresa : TipoOrganizacion {

        public Empresa() {
            this.Estructura = null;
        }

        public override void definirEstructura(Organizacion organizacion){

            if (organizacion.EsActividadComisionistaoAgenciaDeViaje){
              
                int i = 0;

                for (int j  =  0; j  < 4; j++) {

                    if (organizacion.CantidadPersonal <= organizacion.Actividad.CantidadPersonalMax[i]){
                        
                        i++;
                    }
                }
                
                Estructura = definirTamaño(i);
            }
            else {
                int i = 0;
                for (int j = 0; j  < 4; j++) {

                    if (organizacion.CantidadPersonal <= organizacion.Actividad.CantidadPersonalMax[i] ||
                        organizacion.PromedioVentasAnuales <= organizacion.Actividad.PromedioVentasMax[i]){
                       
                        i++;
                    }
                }
                
                Estructura = definirTamaño(i);
            }
		}

        public Estructura definirTamaño(int i){
            switch (i) {
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

    }//end Empresa

}//end namespace TPANUAL