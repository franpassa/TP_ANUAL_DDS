
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;



using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private BandejaDeMensajes bandeja;
		private int cantidadDePresupuestosRequeridos;
		private Criterio criterio;
		private bool esConPresupuesto;
		private Presupuesto presupuestoElegido;
		private List<Presupuesto> presupuestos;
		private List<Item> items;
		private Proveedor proveedor;
		private List<Usuario> revisores;

        public Compra(Criterio criterio, List<Usuario> revisores, int cantidadDePresupuestosRequeridos) {

            Criterio = criterio;
            Presupuestos = new List<Presupuesto>();
            PresupuestoElegido = null;
            Revisores = revisores;
            EsConPresupuesto = true;
            CantidadDePresupuestosRequeridos = cantidadDePresupuestosRequeridos;
            Bandeja = new BandejaDeMensajes();
        }

        public Compra(List<Item> items, Proveedor proveedor) {

            Items = items;
            Proveedor = proveedor;
            EsConPresupuesto = false;
        }

        public Criterio Criterio                  { get => criterio;            set => criterio = value; }
        public List<Presupuesto> Presupuestos     { get => presupuestos;        set => presupuestos = value; }
        public Presupuesto PresupuestoElegido     { get => presupuestoElegido;  set => presupuestoElegido = value; }
        public List<Usuario> Revisores			  { get => revisores;           set => revisores = value; }
        public List<Item> Items { get => items; set => items = value; }
        public Proveedor Proveedor                { get => proveedor;           set => proveedor = value; }
        public bool EsConPresupuesto              { get => esConPresupuesto;    set => esConPresupuesto = value; }
        public int CantidadDePresupuestosRequeridos { get => cantidadDePresupuestosRequeridos; set => cantidadDePresupuestosRequeridos = value; }
        public BandejaDeMensajes Bandeja { get => bandeja; set => bandeja = value; }

        public void agregarRevisor(Usuario usuario){
			Revisores.Add(usuario);
		}

        public void agregarPresupuesto(Presupuesto presupuesto)
        {
            if(EsConPresupuesto)
                presupuestos.Add(presupuesto);
        }

		public bool validarCompra(){

            return ValidadorDeCompra.getInstanceValidadorCompra.validarCompra(this);
		}

		public override float valorTotal(){

			float temporal = 0;

			if (esConPresupuesto)
			{
				temporal = presupuestoElegido.valorTotal();
			}
			else
			{
				foreach(Item item in items)
                {
					temporal += item.ValorTotal;
                }
			}

			return temporal;
		}

		public bool presupuestoElegidoEstaEnPresupuestos()
		{ 
			foreach(Presupuesto presupuesto in Presupuestos)
            {
				if(Equals(presupuestoElegido, presupuesto)){
					return true;
                }
            }

			return false;
        }

        public void mostrarMensajes(Usuario usuario)
        {
            if (usuario.esRevisor(this))
            {
                bandeja.imprimirMensajes();
            }
        }

    }//end Compra

}//end namespace TPANUAL