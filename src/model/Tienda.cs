﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Tienda(string direccion)
    {
        public int Id { get; set; }
        public string Direccion { get; set; } = direccion;
    }
}
