
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
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("compra")]
	public class Compra : TipoEgreso {
        [Key]
        [Column("ID_Compra")]
        public int ID_Compra { get; set; }

        [Column("CantidadDePresupuestosRequeridos")]
        public int CantidadDePresupuestosRequeridos { get; set; }

        [Column("ID_Egreso")]
        public int ID_Egreso { get; set; }

        [NotMapped]
        public CriterioCompra Criterio { get; set; }
        public List<Presupuesto> Presupuestos{ get; set; }
        
        //many to many
        public List<Usuario> Revisores { get; set; }
        public List<Item> Items { get; set; }
        public Proveedor Proveedor{ get; set; }
        public BandejaDeMensajes Bandeja { get; set; }

        /*
        Al momento de crear la compra, ya le paso la lista de items con el valor total de cada uno, osea lo que salieron cuando compre. 
        Lo mismo pasa con el proveedor (ya compre, ya se el valor de los items, ya se a quien le compre)
        La compra que necesita presupuestos, NO necesariamente tiene que hacerse en base a uno de esos presupuestos. Basicamente puedo comprar donde quiera
        (y despues se validara la compra, pero no me importa)
         */
        public Compra( int cantidadDePresupuestosRequeridos, CriterioCompra criterio, List<Item> items, Proveedor proveedor, List<Usuario> revisores)
        {
            CantidadDePresupuestosRequeridos = cantidadDePresupuestosRequeridos;
            Bandeja = new BandejaDeMensajes();
            Criterio = criterio;
            Presupuestos = new List<Presupuesto>();
            Items = items;
            Proveedor = proveedor;
            Revisores = revisores;
        }

        public Compra() { }

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
                Presupuestos.Add(presupuesto);
        }

        public override async Task validar()
        {
            await ValidadorDeCompra.getInstanceValidadorCompra.ValidarCompra(this);
        }

        public override float valorTotal(){

			float temporal = 0;

				foreach(Item item in Items)
                {
					temporal += item.ValorTotal;
                }
		
			return temporal;
		}
    
	   	public bool itemsElegidosEstanEnPresupuestos()
		{
			foreach(Presupuesto presupuesto in Presupuestos)
            {
                if(sonIguales(presupuesto.Items, Items)) {

                    return true;
                }
            }
			return false;
        }

        private bool sonIguales(List<Item> lista1, List<Item> lista2) {
           
            bool flag = true;

            foreach(Item item in lista1)
            {
                flag = flag && (lista2.Any(x => x.Nombre.Equals(item.Nombre)));
            }

            return flag;
        }

        public void mostrarMensajes(Usuario usuario)
        {
            if (esRevisor(usuario))
            {
                Bandeja.imprimirMensajes();
            }
        }

        private bool esRevisor(Usuario unUsuario)
        {
            foreach (Usuario usuario in Revisores)
            {
                if (Equals(unUsuario, usuario))
                {
                    return true;
                }
            }

            return false;
        }


    }//end Compra

}//end namespace TPANUAL