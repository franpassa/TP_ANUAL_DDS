using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL
{
    [Table("proyecto")]
    public class Proyecto
    {
        [Key]
        [Column("ID_Proyecto")]
        public int ID_Proyecto { get; set; }

        [Column("ID_Director_Responsable")]
        public int? ID_Director_Responsable { get; set; }
        public Usuario Director_Responsable { get; set; }

        public List<OperacionDeIngreso> IngresosAsociados { get; set; }

        [Column("Monto")]
        public float Monto { get; set; }

        [Column("Monto_Maximo_Presupuestos")]
        public float Monto_Maximo_Presupuestos { get; set; }

        public Proyecto(List<OperacionDeIngreso> ingAs, Usuario director, float monto_max)
        {
            IngresosAsociados = ingAs;
            Director_Responsable = director;
            foreach(OperacionDeIngreso ingreso in ingAs)
            {
                this.Monto += ingreso.Monto;
            }
            Monto_Maximo_Presupuestos = monto_max;
        }

    }
}
