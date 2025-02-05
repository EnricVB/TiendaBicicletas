using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.model {
    internal class Categoria(string nombre, string descripcion) {
        public int Id { get; set; }
        public string Nombre { get; set; } = nombre;
        public string Descripcion { get; set; } = descripcion;
    }
}
