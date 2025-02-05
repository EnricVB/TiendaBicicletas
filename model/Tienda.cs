using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.model {
    internal class Tienda(string direccion) {
        public string Direccion { get; set; } = direccion;
    }
}
