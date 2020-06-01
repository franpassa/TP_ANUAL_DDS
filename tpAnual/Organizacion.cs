
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Organizacion {

		private Actividad actividad;
		private int cantidadPersonal;
		private string nombreFicticio;
		private List<OperacionDeEgreso> operacionesDeEgreso;
		private float promedioVentasAnuales;
		private bool esActividadComisionistaoAgenciaDeViaje;
		private TipoEntidad tipoEntidad;
		private TipoOrganizacion tipoOrganizacion;
		private List<Usuario> usuarios;


        public Organizacion(string nombreFicticio, Actividad actividad, int cantidadPersonal, float promedioVentasAnuales, bool esActividadComisionistaoAgenciaDeViaje, TipoEntidad tipoEntidad, TipoOrganizacion tipoOrganizacion, List<Usuario> usuarios)
        {
            this.actividad = actividad;
            this.cantidadPersonal = cantidadPersonal;
            this.nombreFicticio = nombreFicticio;
            this.OperacionesDeEgreso = new List<OperacionDeEgreso>();
            this.promedioVentasAnuales = promedioVentasAnuales;
            this.esActividadComisionistaoAgenciaDeViaje = esActividadComisionistaoAgenciaDeViaje;
            this.tipoEntidad = tipoEntidad;
            this.tipoOrganizacion = tipoOrganizacion;
            tipoOrganizacion.definirEstructura(this);
            this.usuarios = usuarios;
        }


		public Actividad Actividad { get => actividad; set => actividad = value; }
		public string NombreFicticio { get => nombreFicticio; set => nombreFicticio = value; }
		public float PromedioVentasAnuales { get => promedioVentasAnuales; set => promedioVentasAnuales = value; }
		public bool EsActividadComisionistaoAgenciaDeViaje { get => esActividadComisionistaoAgenciaDeViaje; set => esActividadComisionistaoAgenciaDeViaje = value; }
		public TipoEntidad TipoEntidad { get => tipoEntidad; set => tipoEntidad = value; }
		public TipoOrganizacion TipoOrganizacion { get => tipoOrganizacion; set => tipoOrganizacion = value; }
		public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
		public int CantidadPersonal { get => cantidadPersonal; set => cantidadPersonal = value; }
        public List<OperacionDeEgreso> OperacionesDeEgreso { get => operacionesDeEgreso; set => operacionesDeEgreso = value; }


    }//end Organizacion

}//end namespace TPANUAL