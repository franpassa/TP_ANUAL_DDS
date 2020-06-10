
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public abstract class Organizacion {

		private Actividad actividad;
		private int cantidadPersonal;
		private bool esActividadComisionistaoAgenciaDeViaje;
		private string nombreFicticio;
		private List<OperacionDeEgreso> operacionesDeEgreso;
		private float promedioVentasAnuales;
		private TipoEntidad tipoEntidad;
		private List<Usuario> usuarios;


        public Actividad Actividad { get => actividad; set => actividad = value; }
		public string NombreFicticio { get => nombreFicticio; set => nombreFicticio = value; }
		public float PromedioVentasAnuales { get => promedioVentasAnuales; set => promedioVentasAnuales = value; }
		public bool EsActividadComisionistaoAgenciaDeViaje { get => esActividadComisionistaoAgenciaDeViaje; set => esActividadComisionistaoAgenciaDeViaje = value; }
		public TipoEntidad TipoEntidad { get => tipoEntidad; set => tipoEntidad = value; }
		public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
		public int CantidadPersonal { get => cantidadPersonal; set => cantidadPersonal = value; }
        public List<OperacionDeEgreso> OperacionesDeEgreso { get => operacionesDeEgreso; set => operacionesDeEgreso = value; }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            OperacionesDeEgreso.Add(operacion);
        }


    }//end Organizacion

}//end namespace TPANUAL