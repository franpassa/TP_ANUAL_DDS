
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private List<string> bandejaDeMensajes;
		private Criterio criterio;
		private Presupuesto presupuestoElegido;
		private List<Presupuesto> presupuestos;
		private List<Producto> productosRequeridos;
		private List<Usuario> revisores;
		private Proveedor proveedor;

        public Compra()
        {
			this.bandejaDeMensajes = new List<string>();
			this.criterio = null;
			this.Revisores = new List<Usuario>();
        }

        public List<string> BandejaDeMensajes { get => bandejaDeMensajes; set => bandejaDeMensajes = value; }
        public Criterio Criterio { get => criterio; set => criterio = value; }
        public List<Presupuesto> Presupuestos { get => presupuestos; set => presupuestos = value; }
        public Presupuesto PresupuestoElegido { get => presupuestoElegido; set => presupuestoElegido = value; }
        public List<Usuario> Revisores { get => revisores; set => revisores = value; }
        public List<Producto> ProductosRequeridos { get => productosRequeridos; set => productosRequeridos = value; }

        public void agregarRevisor(Usuario usuario){
			Revisores.Add(usuario);
		}

		public bool validarCompra(){

			return false;
		}

		public float valorTotal(){
			if(presupuestoElegido == null)
            {

            }
		}

	}//end Compra

}//end namespace TPANUAL