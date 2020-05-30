
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Organizacion {

		private Actividad actividad;
		private int cantidadPersonal;
		private int promedioVentas;
		private string nombreFicticio;
		private OperacionDeEgreso operacionesDeEgreso;
		private float promedioVentasAnuales;
		private bool esActividadComisionistaoAgenciaDeViaje;
		private TipoEntidad tipoEntidad;
		private TipoOrganizacion tipoOrganizacion;
		private List<Usuario> usuarios;
		private OperacionDeEgreso operacionDeEgreso;

		public TPANUAL.Usuario m_Usuario;
		public TPANUAL.TipoEntidad m_TipoEntidad;
		public TPANUAL.TipoOrganizacion m_TipoOrganizacion;
		public TPANUAL.Actividad m_Actividad;

		public Actividad Actividad { get => actividad; set => actividad = value; }
		public string NombreFicticio { get => nombreFicticio; set => nombreFicticio = value; }
		public OperacionDeEgreso OperacionesDeEgreso { get => operacionesDeEgreso; set => operacionesDeEgreso = value; }
		public float PromedioVentasAnuales { get => promedioVentasAnuales; set => promedioVentasAnuales = value; }
		public bool EsActividadComisionistaoAgenciaDeViaje { get => esActividadComisionistaoAgenciaDeViaje; set => esActividadComisionistaoAgenciaDeViaje = value; }
		public TipoEntidad TipoEntidad { get => tipoEntidad; set => tipoEntidad = value; }
		public TipoOrganizacion TipoOrganizacion { get => tipoOrganizacion; set => tipoOrganizacion = value; }
		public List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
		public OperacionDeEgreso OperacionDeEgreso { get => operacionDeEgreso; set => operacionDeEgreso = value; }
		public int CantidadPersonal { get => cantidadPersonal; set => cantidadPersonal = value; }
		public int PromedioVentas { get => promedioVentas; set => promedioVentas = value; }

		public Organizacion(){

		}

	}//end Organizacion

}//end namespace TPANUAL