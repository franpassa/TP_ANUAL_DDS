
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

        [Column("ActComisionistaoAgenciaDeViaje")]
        public bool EsActividadComisionistaoAgenciaDeViaje { get; set; }

        [Column("CantidadDePersonal")]
        public int CantidadPersonal { get; set; }

        public TipoEntidad TipoEntidad { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public List<OperacionDeEgreso> OperacionesDeEgreso { get; set; }

        public List<OperacionDeIngreso> OperacionesDeIngreso { get; set; }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            OperacionesDeEgreso.Add(operacion);
        }

        public void agregarOperacionDeIngreso(OperacionDeIngreso operacion)
        {
            OperacionesDeIngreso.Add(operacion);
        }

        public Organizacion() { }

    }//end Organizacion

}//end namespace TPANUAL