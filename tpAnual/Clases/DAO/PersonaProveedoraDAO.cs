﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace TPANUAL.Clases.DAO
{
    public class PersonaProveedoraDAO
    {
        private PersonaProveedoraDAO() { }

        public static PersonaProveedora obtenerPersonaProveedora(int _ID)
        {
            using var contexto = new DB_Context();
            var personaProveedora = (PersonaProveedora)contexto.proveedor.Find(_ID);

            return personaProveedora;
        }
    }
}
