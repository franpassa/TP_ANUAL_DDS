
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class Actividad {

        private float[] promedioVentasMax;
        private int[] cantidadPersonalMax;

        public int[] CantidadPersonalMax { get => cantidadPersonalMax; set => cantidadPersonalMax = value; }
        public float[] PromedioVentasMax { get => promedioVentasMax; set => promedioVentasMax = value; }

        public Actividad(){

		}

	}//end Actividad

}//end namespace TPANUAL