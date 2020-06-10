
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class OSC : Organizacion{
        public OSC(Actividad actividad, int cantidadPersonal, string nombreFicticio, float promedioVentasAnuales, TipoEntidad tipoEntidad, List<Usuario> usuarios)
        {
            Actividad = actividad;
            CantidadPersonal = cantidadPersonal;
            EsActividadComisionistaoAgenciaDeViaje = false;
            NombreFicticio = nombreFicticio;
            OperacionesDeEgreso = new List<OperacionDeEgreso>();
            PromedioVentasAnuales = promedioVentasAnuales;
            TipoEntidad = tipoEntidad;
            Usuarios = usuarios;
        }

    }//end OSC

}//end namespace TPANUAL