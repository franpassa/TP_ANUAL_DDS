
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;



using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private int cantidadDePresupuestosRequeridos;
		private List<string> bandejaDeMensajes;
		private Criterio criterio;
		private Presupuesto presupuestoElegido;
		private List<Presupuesto> presupuestos;
		private List<Producto> productosRequeridos;
		private List<Usuario> revisores;
		private Proveedor proveedor;
		private bool esConPresupuesto;

        public Compra()
        {
			this.bandejaDeMensajes = new List<string>();
			this.criterio = null;
			this.Revisores = new List<Usuario>();
        }

        public List<string> BandejaDeMensajes     { get => bandejaDeMensajes;   set => bandejaDeMensajes = value; }
        public Criterio Criterio                  { get => criterio;            set => criterio = value; }
        public List<Presupuesto> Presupuestos     { get => presupuestos;        set => presupuestos = value; }
        public Presupuesto PresupuestoElegido     { get => presupuestoElegido;  set => presupuestoElegido = value; }
        public List<Usuario> Revisores			  { get => revisores;           set => revisores = value; }
        public List<Producto> ProductosRequeridos { get => productosRequeridos; set => productosRequeridos = value; }
        public Proveedor Proveedor                { get => proveedor;           set => proveedor = value; }
        public bool EsConPresupuesto              { get => esConPresupuesto;    set => esConPresupuesto = value; }
        public int CantidadDePresupuestosRequeridos { get => cantidadDePresupuestosRequeridos; set => cantidadDePresupuestosRequeridos = value; }

        public void agregarRevisor(Usuario usuario){
			Revisores.Add(usuario);
		}

		public bool validarCompra(){

			return false;
		}

		public override float valorTotal(){

			float temporal = 0;

			if (esConPresupuesto)
			{
				temporal = presupuestoElegido.valorTotal();
			}
			else
			{
				foreach(Producto producto in ProductosRequeridos)
                {
					temporal += proveedor.damePrecio(producto.IdProducto);
                }
			}

			return temporal;
		}

		public bool presupuestoRequeridoEstaEnPresupuestos()
		{ 
			foreach(Presupuesto presupuesto in Presupuestos)
            {
				if(Equals(presupuestoElegido, presupuesto)){
					return true;
                }
            }

			return false;
        }

		public void agregarMensaje(string mensaje)
        {
			bandejaDeMensajes.Add(mensaje);
        }

	}//end Compra

}//end namespace TPANUAL