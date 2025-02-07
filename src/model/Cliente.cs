using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Cliente(string nombre)
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = nombre;
    }
}
