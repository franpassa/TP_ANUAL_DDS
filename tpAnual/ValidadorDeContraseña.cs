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

        public void mostrarMsjValidador(string contraseña)
        {
            bool[] lista = listaDeValidaciones(contraseña);

            for (int i = 0; i<lista.Length; i++)
            {
                if (!lista[i])
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine(" (X) La contraseña no debe estar vacia. \n");
                            break;
                        case 1:
                            Console.WriteLine(" (X) La contraseña no debe contener caracteres unicode. \n");
                            break;
                        case 2:
                            Console.WriteLine(" (X) La contraseña no debe estar incluida en el top 10.000 de contrasenias mas frecuentes. \n");
                            break;
                        case 3:
                            Console.WriteLine(" (X) La contraseña debe contener al menos una letra minuscula. \n");
                            break;
                        case 4:
                            Console.WriteLine(" (X) La contraseña debe contener al menos una letra mayuscula. \n");
                            break;
                        case 5:
                            Console.WriteLine(" (X) La contraseña debe contener al menos un numero. \n");
                            break;
                        case 6:
                            Console.WriteLine(" (X) La contraseña debe contener de 8 a 64 caracteres. \n");
                            break;
                        case 7:
                            Console.WriteLine(" (X) La contraseña no debe tener numeros consecutivos \n");
                            break;
                        case 8:
                            Console.WriteLine(" (X) La contraseña no debe tener caracteres seguidos repetidos \n");
                            break;
                    }
                }

            }

        }

        public bool validarContraseña(string contraseña)
        {
            bool[] lista = listaDeValidaciones(contraseña);

            foreach(bool booleano in lista)
            {
                if (!booleano)
                {
                    return false;
                }
            }
            return true;
        }

        public bool[] listaDeValidaciones(string contrasenia)
        {
            bool[] listaBool = new bool[10];

            listaBool[0] = !string.IsNullOrWhiteSpace(contrasenia);

            listaBool[1] = !EsUnicode(contrasenia);

            listaBool[2] = !EstaEnLaBaseDeDatos(contrasenia);

            var tieneMinusculas = new Regex(@"[a-z]+");
            var tieneMayusculas = new Regex(@"[A-Z]+");
            var tieneNumeros = new Regex(@"[0-9]+");
            var tieneCantidad = new Regex(@".{8,64}");

            listaBool[3] = tieneMinusculas.IsMatch(contrasenia);

            listaBool[4] = tieneMayusculas.IsMatch(contrasenia);

            listaBool[5] = tieneNumeros.IsMatch(contrasenia);

            listaBool[6] = tieneCantidad.IsMatch(contrasenia);

            listaBool[7] = !NumerosConsecutivos(contrasenia);

            listaBool[8] = !CaracteresRepetidos(contrasenia);

            return listaBool;
        }

        //FUNCIONES AUXILIARES PARA EL VALIDADOR

        private static bool EstaEnLaBaseDeDatos(string UnString)
        {
            string[] archivoDeContasenias = System.IO.File.ReadAllLines(@"..\..\..\10000Contrasenas.txt");

            foreach (string linea in archivoDeContasenias)
            {
                if (linea == UnString)
                {
                    return true;
                }
            }
            return false;
        }

        static private bool NumerosConsecutivos(string OtroString)
        {
            List<string> listaConsecutivos = new List<string> { "012", "123", "234", "345", "456", "567", "678", "789" };

            foreach(string consecutivo in listaConsecutivos)
            {
                if (OtroString.Contains(consecutivo))
                {
                    return true;
                }
            }
            return false;

        }

        static private bool CaracteresRepetidos(string OtroString)
        {
            char[] UnString = OtroString.ToCharArray();

            for (int i = 0; i < UnString.Length -2; i++)
            {
                if (((int)UnString[i] == (int)UnString[i + 1]) && ((int)UnString[i + 1] == (int)UnString[i + 2]))
                {
                    return true;
                } 
            }

            return false;

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
