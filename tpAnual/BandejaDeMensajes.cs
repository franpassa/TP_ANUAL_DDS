using System;
using System.Collections.Generic;
using System.Text;

using TPANUAL;
namespace TPANUAL
{
    public class BandejaDeMensajes
    {
        private List<string> listaDeMensajes;

        public List<string> ListaDeMensajes { get => listaDeMensajes; set => listaDeMensajes = value; }

        public void agregarMensaje(string mensaje)
        {
            ListaDeMensajes.Add(mensaje);
        }

        public void imprimirMensajes()
        {
            foreach(string mensaje in ListaDeMensajes)
            {
                Console.WriteLine(mensaje);
            }
        }

    }
}
