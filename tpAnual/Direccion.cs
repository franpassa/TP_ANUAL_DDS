using API_MercadoLibre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPANUAL
{ 
    [Table("direccion")]
    public class Direccion
    {
        [Key]
        [Column("ID_Direccion")]
        public int ID_Direccion { get; set; }

        [Column("calle")]
        public string Calle { get; set; }

        [Column("depto")]
        public string Depto { get; set; }

        [Column("piso")]
        public int Piso { get; set; }

        [Column("ID_Ciudad")]
        public string ID_Ciudad { get; set; }

        //al momento de crear la direccion, no se el id de la ciudad (choclo de letras y numeros)
        //entonces le paso la ciudad directamente y se guarda su id en el atributo
        public Direccion(string calle, string depto, int piso, Ciudad ciudad)
        {
            Calle = calle;
            Depto = depto;
            Piso = piso;
            ID_Ciudad = ciudad.ID_Ciudad;
        }

        public Direccion() { }
    }
}
