
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

        [Key]
        [Column("ID_PersonaProveedora")]
        public int ID_PersonaProveedora { get; set; }

        [Column("DNI")]
        public string DNI { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("ID_Compra")]
        public int ID_Compra { get; set; }

        [Column("ID_Direccion")]
        public int ID_Direccion { get; set; }


        [Column("ID_Presupuesto")]
        public int ID_Presupuesto { get; set; }


        public PersonaProveedora(Direccion direccionPostal, string DNI, string nombre)
        {
            DireccionPostal = direccionPostal;
            this.DNI = DNI;
            Nombre = nombre;
        }

        public PersonaProveedora() { }

    }//end Persona

}//end namespace TPANUAL