using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace TPANUAL
{
    class ValidadorDeContraseña
    {
        private static ValidadorDeContraseña instanceContra = null;

        protected ValidadorDeContraseña() { }

        public static ValidadorDeContraseña getInstanceValidadorContra
        {

            get
            {
                if (instanceContra == null)
                {

                    instanceContra = new ValidadorDeContraseña();
                }

                return instanceContra;
            }

        }

        //VALIDADOR DE CONTRASEÑAS

        public void mostrarMsjValidador(string a)
        {
            Console.WriteLine(a);
        }

        public bool validarContraseña(string contrasenia, out string mensajeDeError)
        {
            var validezContrasenia = false;
            mensajeDeError = string.Empty;

            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                mensajeDeError = " (X) La contrasenia no debe estar vacia. \n";
                return validezContrasenia;
            }

            if (EsUnicode(contrasenia))
            {
                mensajeDeError = " (X) La contrasenia no debe contener caracteres unicode. \n";
                return validezContrasenia;
            }

            if (!EstaEnLaBaseDeDatos(contrasenia))
            {
                mensajeDeError = " (X) La contrasenia no debe estar incluida en el top 10.000 de contrasenias mas frecuentes. \n";
                return validezContrasenia;
            }

            var tieneMinusculas = new Regex(@"[a-z]+");
            var tieneMayusculas = new Regex(@"[A-Z]+");
            var tieneNumeros = new Regex(@"[0-9]+");
            var tieneRepetidos = new Regex(@"[a-zA-z]{3,64}");
            var tieneCantidad = new Regex(@".{8,64}");

            validezContrasenia = true;

            if (!tieneMinusculas.IsMatch(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia debe contener al menos una letra minuscula. \n");
                validezContrasenia = false;
            }
            if (!tieneMayusculas.IsMatch(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia debe contener al menos una letra mayuscula. \n");
                validezContrasenia = false;
            }
            if (!tieneNumeros.IsMatch(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia debe contener al menos un numero. \n");
                validezContrasenia = false;
            }
            if (!tieneCantidad.IsMatch(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia debe contener de 8 a 64 caracteres. \n");
                validezContrasenia = false;
            }
            if (NumerosConsecutivos(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia no debe tener caracteres consecutivos \n");
                validezContrasenia = false;
            }
            if (CaracteresConsecutivosIguales(contrasenia))
            {
                mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia no debe tener caracteres consecutivos iguales \n");
                validezContrasenia = false;
            }
            return validezContrasenia;
        }

        //FUNCIONES AUXILIARES PARA EL VALIDADOR

        private static bool EstaEnLaBaseDeDatos(string UnString)
        {
            string[] archivoDeContasenias = System.IO.File.ReadAllLines(@"..\..\..\10000Contrasenas.txt");
            int contador = 1;
            foreach (string linea in archivoDeContasenias)
            {
                if (linea == UnString)
                {
                    return false;
                }
                contador++;
            }
            return true;
        }

        static private bool NumerosConsecutivos(string OtroString)
        {
            char[] UnString = OtroString.ToCharArray();
            bool retorno = false;
            for (int i = 0; i < (UnString.Length - 2); i++)
            {
                bool laPos3esPos2Mas1 = (int)UnString[i + 2] == ((int)UnString[i + 1]) + 1;
                bool laPos2esPos1Mas1 = (int)UnString[i + 1] == ((int)UnString[i]) + 1;
                retorno = retorno || (laPos3esPos2Mas1 && laPos3esPos2Mas1);
            }
            return retorno;
        }

        static private bool CaracteresConsecutivosIguales(string OtroString)
        {
            char[] UnString = OtroString.ToCharArray();
            bool retorno = false;
            for (int i = 0; i < (UnString.Length - 1); i++)
            {
                retorno = retorno || (int)UnString[i] == (int)UnString[i + 1];
            }
            return retorno;
        }

        public static bool EsUnicode(string input)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(input);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(input);
            return asciiBytesCount != unicodBytesCount;
        }

        //END VALIDADOR CONTRASEÑA

    }
}
