using System;
using TPANUAL;

namespace Vinculador_Ingresos_Egresos
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new DB_Context())
            {
                Console.WriteLine("Hello Wordl!");
                Console.ReadLine();

                contexto.Database.ExecuteSqlCommand("set foreign_key_checks=0; insert into operaciondeingreso values (9, 1, 'Ingreso prestamo', 5314);");
                contexto.SaveChanges();
            }
        }
    }
}
