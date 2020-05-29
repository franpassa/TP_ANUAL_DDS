///////////////////////////////////////////////////////////
//  Organizacion.cs
//  Implementation of the Class Organizacion
//  Generated by Enterprise Architect
//  Created on:      29-may.-2020 19:05:53
//  Original author: Franco
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TP-ANUAL;
namespace TP-ANUAL {
	public class Organizacion {

		private Actividad actividad;
		private int cantidadDePersonal;
		private string nombreFicticio;
		private Operacion de egreso operacionesDeEgreso;
		private float promedioVentasAnuales;
		private TipoEntidad tipoEntidad;
		private TipoOrganizacion tipoOrganizacion;
		private Usuario usuarios;
		public Operacion de egreso m_Operacion de egreso;
		public TP-ANUAL.Usuario m_Usuario;
		public TP-ANUAL.TipoEntidad m_TipoEntidad;
		public TP-ANUAL.TipoOrganizacion m_TipoOrganizacion;
		public TP-ANUAL.Actividad m_Actividad;

		public Organizacion(){

		}

		~Organizacion(){

		}

	}//end Organizacion

}//end namespace TP-ANUAL