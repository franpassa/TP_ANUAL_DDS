
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class MedioDePago {

		private string IDpais;
		private string numero;
		private string tipoPago;

        public MedioDePago(string IDpais, string numero, string tipoPago)
        {
            this.IDpais = IDpais;
            this.numero = numero;
            this.tipoPago = tipoPago;
        }

    }//end Medio de Pago

}//end namespace TPANUAL