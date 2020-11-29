
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


        [Column("Nombre")]
        public string Nombre { get; set; }
        public List<Compra> compras { get; set; }
        public List<Presupuesto> presupuestos { get; set; }

        public PersonaProveedora(Direccion direccionPostal, string DNI, string nombre)
        {
            DireccionPostal = direccionPostal;
            Numero_identificatorio = DNI;
            Nombre = nombre;
            ID_Direccion = direccionPostal.ID_Direccion;
        }

        public PersonaProveedora() { }

    }//end Persona

}//end namespace TPANUAL