
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
namespace TPANUAL {
	public class EntidadBase : TipoEntidad {

		private string descripcion;
		private EntidadJuridica juridicaAsociada;

        public EntidadBase(string descripcion, EntidadJuridica juridicaAsociada)
        {
            this.descripcion = descripcion;
            this.juridicaAsociada = juridicaAsociada;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public EntidadJuridica JuridicaAsociada { get => juridicaAsociada; set => juridicaAsociada = value; }
    }//end Entidad base

}//end namespace TPANUAL