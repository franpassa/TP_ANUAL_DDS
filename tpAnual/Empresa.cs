
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("organizacion")]
	public class Empresa : Organizacion {
        public Estructura Estructura { get; set; }

        public Empresa(Actividad actividad, int cantidadPersonal, bool esActividadComisionistaoAgenciaDeViaje, string nombreFicticio, float promedioVentasAnuales, TipoEntidad tipoEntidad, List<Usuario> usuarios)
        {
            Actividad = actividad;
            CantidadPersonal = cantidadPersonal;
            EsActividadComisionistaoAgenciaDeViaje = esActividadComisionistaoAgenciaDeViaje;
            NombreFicticio = nombreFicticio;
            OperacionesDeEgreso = new List<OperacionDeEgreso>();
            PromedioVentasAnuales = promedioVentasAnuales;
            TipoEntidad = tipoEntidad;
            Usuarios = usuarios;
        }

        public Empresa() { }

        public void definirEstructura(){

            if (EsActividadComisionistaoAgenciaDeViaje){
              
                int i = 0;

                for (int j  =  0; j  < 4; j++) {

                    if (CantidadPersonal >= Actividad.CantidadPersonalMax[i]){
                        
                        i++;
                    }
                }
                
                Estructura = definirTamaño(i);
            }
            else {
                int i = 0;
                for (int j = 0; j  < 4; j++) {

                    if (CantidadPersonal >= Actividad.CantidadPersonalMax[i] ||
                        PromedioVentasAnuales >= Actividad.PromedioVentasMax[i]){
                       
                        i++;
                    }
                }
                
                Estructura = definirTamaño(i);
            }
		}

        private Estructura definirTamaño(int i){
            switch (i) {
                case 0:
                    return new Micro();
                case 1:
                    return new Pequeña();
                case 2:
                    return new MedianaTramo1();
                case 3:
                    return new MedianaTramo2();
                default:
                    return null;
            }
        }

    }//end Empresa

}//end namespace TPANUAL