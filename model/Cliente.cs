﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.model {
    internal class Cliente(string nombre) {
        public string Nombre { get; set; } = nombre;
    }
}
