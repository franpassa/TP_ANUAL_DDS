using System.Text.RegularExpressions;
using System;
class ValidadorDeContrasenias
{
        static void Main()
        {
            System.Console.WriteLine("Ingrese su contrasenia. \nDebe tener al menos:\n - 8 caracteres. \n - 1 Mayuscula. \n - 1 Minuscula. \n - 1 Numero.\n");
            string contraseniaContrasenia = System.Console.ReadLine();
            string mensajeDeError = string.Empty;
            System.Console.WriteLine(Validar(contraseniaContrasenia, out mensajeDeError));
            System.Console.WriteLine(mensajeDeError);
            while(!Validar(contraseniaContrasenia, out mensajeDeError))
            {
                System.Console.WriteLine("Ingrese una contrasenia valida. \n");
                contraseniaContrasenia = System.Console.ReadLine();
                System.Console.WriteLine(Validar(contraseniaContrasenia, out mensajeDeError));
                System.Console.WriteLine(mensajeDeError);
            }
        }

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

        public static bool Validar(string contrasenia, out string mensajeDeError)
        {
            var validezContrasenia = false;
            mensajeDeError = string.Empty;

            if (string.IsNullOrWhiteSpace(contrasenia))
            {
                mensajeDeError = " (X) La contrasenia no puede estar vacia. \n";
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
        if (caracteresConsecutivosIguales(contrasenia))
        {
            mensajeDeError = String.Concat(mensajeDeError, " (X) La contrasenia no debe tener caracteres consecutivos iguales \n");
            validezContrasenia = false;
        }
        return validezContrasenia;
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
    static private bool caracteresConsecutivosIguales(string OtroString)
    {
        char[] UnString = OtroString.ToCharArray();
        bool retorno = false;
        for (int i = 0; i < (UnString.Length - 1); i++)
        {
            retorno = retorno || (int)UnString[i] == (int)UnString[i + 1];
        }
        return retorno;
    }

}
