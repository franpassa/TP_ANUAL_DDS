
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TPANUAL {
    [Table("entidadjuridicaproveedora")]
	public class EntidadJuridicaProveedora : Proveedor {

        [Column("CodigoInscripcion")]
        public string CodigoInscripcion { get; set; }

        [Column("CUIT")]
        public string CUIT { get; set; }

        [Column("RazonSocial")]
        public string RazonSocial { get; set; }

        [Column("ID_Direccion")]
        public int ID_Direccion { get; set; }
        public Direccion DireccionPostal { get; set; }
        public List<Presupuesto> Presupuestos { get; set; }
        public List<Compra> Compras { get; set; }

        public EntidadJuridicaProveedora(Direccion direccionPostal, string codigoInscripcion, string CUIT, string razonSocial)
        {
            DireccionPostal = direccionPostal;
            CodigoInscripcion = codigoInscripcion;
            this.CUIT = CUIT;
            RazonSocial = razonSocial;
            ID_Direccion = direccionPostal.ID_Direccion;
        }

        public EntidadJuridicaProveedora() { }

    }//end EntidadJuridicaProveedora

}//end namespace TPANUAL