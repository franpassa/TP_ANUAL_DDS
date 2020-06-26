
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class Item {

        private List<Categoria> categorias;
        private string nombre;
		private string descripcion;
        private float valorTotal;

        public Item(string nombre, string descripcion, float valorTotal, List<Categoria> categorias)
        {
            Descripcion = descripcion;
            ValorTotal = valorTotal;
            Nombre = nombre;
            Categorias = categorias;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Categoria> Categorias { get => categorias; set => categorias = value; }

        void insertarCategoria(Categoria categoria)
        {
            bool estaEnLaLista = false;
            foreach (Categoria unaCategoria in categorias)
            {
                if (Equals(unaCategoria.Criterio,categoria.Criterio))
                {
                    estaEnLaLista = true;
                }
            }

            if (!estaEnLaLista) { categorias.Add(categoria); }
        }

    }//end Producto

}//end namespace TPANUAL