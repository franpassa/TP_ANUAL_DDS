
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
using TPANUAL.Jobs;


using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private BandejaDeMensajes bandeja;
		private int cantidadDePresupuestosRequeridos;
		private CriterioCompra criterio;
		private List<Presupuesto> presupuestos;
		private List<Item> items;
		private Proveedor proveedor;
		private List<Usuario> revisores;

        public Compra( int cantidadDePresupuestosRequeridos, CriterioCompra criterio, List<Item> items, Proveedor proveedor, List<Usuario> revisores)
        {
            this.cantidadDePresupuestosRequeridos = cantidadDePresupuestosRequeridos;
            this.bandeja = new BandejaDeMensajes();
            this.criterio = criterio;
            this.presupuestos = new List<Presupuesto>();
            this.items = items;
            this.proveedor = proveedor;
            this.revisores = revisores;
        }

        public CriterioCompra Criterio                  { get => criterio;            set => criterio = value; }
        public List<Presupuesto> Presupuestos     { get => presupuestos;        set => presupuestos = value; }
        public List<Usuario> Revisores			  { get => revisores;           set => revisores = value; }
        public List<Item> Items { get => items; set => items = value; }
        public Proveedor Proveedor                { get => proveedor;           set => proveedor = value; }
        public int CantidadDePresupuestosRequeridos { get => cantidadDePresupuestosRequeridos; set => cantidadDePresupuestosRequeridos = value; }
        public BandejaDeMensajes Bandeja { get => bandeja; set => bandeja = value; }

        public void agregarRevisor(Usuario usuario){
			Revisores.Add(usuario);
		}

        public bool esConPresupuesto()
        {
            return (CantidadDePresupuestosRequeridos != 0);
        }

        public void agregarPresupuesto(Presupuesto presupuesto)
        {
            if(esConPresupuesto())
                presupuestos.Add(presupuesto);
        }

        public override async Task validar()
        {
            await ValidadorDeCompra.getInstanceValidadorCompra.ValidarCompra(this);
        }

        public override float valorTotal(){

			float temporal = 0;

				foreach(Item item in items)
                {
					temporal += item.ValorTotal;
                }
		
			return temporal;
		}
    
	   	public bool itemsElegidosEstanEnPresupuestos()
		{
			foreach(Presupuesto presupuesto in Presupuestos)
            {
                if(lasListasSonIguales(presupuesto.Items, Items)) {

                    return true;
                }
            }
			return false;
        }

        private bool lasListasSonIguales(List<Item> lista1, List<Item> lista2) {
           
            bool flag = true;

            foreach(Item item in lista1)
            {
                flag = flag && (lista2.Any(x => x.Nombre.Equals(item.Nombre)));
            }

            return flag;
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