using System;
using System.Collections.Generic;
using System.Text;

namespace TPANUAL
{
    public class Categoria
    {
        private string nombre;
        private Criterio criterio;
        public Categoria(string nombre, Criterio criterio)
        {
            this.nombre = nombre;
            this.criterio = criterio;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public Criterio Criterio { get => criterio; set => criterio = value; }
    }
}
