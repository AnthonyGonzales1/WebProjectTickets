﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public int Deuda { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Telefono = string.Empty;
            Deuda = 0;
        }

        public override string ToString()
        {
            return Nombres;
        }
    }
}
