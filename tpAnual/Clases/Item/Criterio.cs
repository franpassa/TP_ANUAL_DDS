using System;
using System.Collections.Generic;
using System.Text;

namespace TPANUAL
{
    public class Criterio
    {
        private string nombre;
        private Criterio criterioPadre;

        public Criterio(string nombre, Criterio criterioPadre)
        {
            this.nombre = nombre;
            this.criterioPadre = criterioPadre;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public Criterio CriterioPadre { get => criterioPadre; set => criterioPadre = value; }
    }
}
