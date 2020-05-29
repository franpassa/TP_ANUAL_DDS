
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Organizacion {

		private Actividad actividad;
		private int cantidadDePersonal;
		private string nombreFicticio;
		private OperacionDeEgreso operacionesDeEgreso;
		private float promedioVentasAnuales;
		private TipoEntidad tipoEntidad;
		private TipoOrganizacion tipoOrganizacion;
		private Usuario usuarios;
		public OperacionDeEgreso m_OperacionDeEgreso;
		public TPANUAL.Usuario m_Usuario;
		public TPANUAL.TipoEntidad m_TipoEntidad;
		public TPANUAL.TipoOrganizacion m_TipoOrganizacion;
		public TPANUAL.Actividad m_Actividad;

		public Organizacion(){

		}

	}//end Organizacion

}//end namespace TPANUAL