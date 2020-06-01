
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class PersonaProveedora : Proveedor {

		private string DNI;
		private string nombre;

        public PersonaProveedora(string direccionPostal, List<Producto> productosDisponibles, string DNI, string nombre)
        {
            this.DireccionPostal = direccionPostal;
            this.ProductosDisponibles = productosDisponibles;
            this.DNI = DNI;
            this.nombre = nombre;
        }

    }//end Persona

}//end namespace TPANUAL