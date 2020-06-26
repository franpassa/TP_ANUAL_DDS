using System;
using System.Collections.Generic;
using System.Text;

namespace TPANUAL
{
    public class OperacionDeIngreso
    {
        private string descripcion;
        private List<OperacionDeEgreso> egresosAsociados;
        private float monto;

        public OperacionDeIngreso(string descripcion, List<OperacionDeEgreso> egresosAsociados, float monto)
        {
            this.descripcion = descripcion;
            this.egresosAsociados = egresosAsociados;
            this.monto = monto;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public List<OperacionDeEgreso> EgresosAsociados { get => egresosAsociados; set => egresosAsociados = value; }
        public float Monto { get => monto; set => monto = value; }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            egresosAsociados.Add(operacion);
        }
    }
}
