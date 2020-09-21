
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("personaproveedora")]
	public class PersonaProveedora : Proveedor {

        [Column("DNI")]
        public string DNI { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        public PersonaProveedora(Direccion direccionPostal, string DNI, string nombre)
        {
            DireccionPostal = direccionPostal;
            this.DNI = DNI;
            Nombre = nombre;
            ID_Direccion = direccionPostal.ID_Direccion;
        }

        public PersonaProveedora() { }

    }//end Persona

}//end namespace TPANUAL