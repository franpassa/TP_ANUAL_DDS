
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("organizacion")]
    public abstract class Organizacion
    {
        [Key]

        [Column("ID_Organizacion")]
        public int ID_Organizacion { get; set; }

        [NotMapped]
        public Actividad Actividad { get; set; }

        [Column("NombreFicticio")]
        public string NombreFicticio { get; set; }

        [Column("PromedioVentasAnuales")]
        public float PromedioVentasAnuales { get; set; }

        [Column("actComisionistaoAgenciaDeViaje")]
        public bool EsActividadComisionistaoAgenciaDeViaje { get; set; }

        [NotMapped]
        public TipoEntidad TipoEntidad { get; set; }

        [NotMapped]
        public List<Usuario> Usuarios { get; set; }

        [Column("CantidadPersonal")]
        public int CantidadPersonal { get; set; }

        [NotMapped]
        public List<OperacionDeEgreso> OperacionesDeEgreso { get; set; }
        
        [NotMapped]
        public List<OperacionDeIngreso> OperacionesDeIngreso { get; set; }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            OperacionesDeEgreso.Add(operacion);
        }

        public void agregarOperacionDeIngreso(OperacionDeIngreso operacion)
        {
            OperacionesDeIngreso.Add(operacion);
        }

    }//end Organizacion

}//end namespace TPANUAL