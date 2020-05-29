
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private string bandejaDeMensajes;
		private Criterio criterio;
		private Presupuesto presupuestoElegido;
		private Presupuesto presupuestos;
		private Producto productosRequeridos;
		private Usuario revisores;
		public TPANUAL.Presupuesto m_Presupuesto;
		public TPANUAL.Producto m_Producto;
		public TPANUAL.Usuario m_Usuario;
		public TPANUAL.Criterio m_Criterio;

        public Compra()
        {

        }

		public void agregarRevisor(Usuario usuario){

		}

		public bool validarCompra(){

			return false;
		}

		public float valorTotal(){

			return 0;
		}

	}//end Compra

}//end namespace TPANUAL