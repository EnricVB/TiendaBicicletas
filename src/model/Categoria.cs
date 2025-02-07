using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Categoria(string nombre, string descripcion)
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = nombre;
        public string Descripcion { get; set; } = descripcion;

        public override string ToString()
        {
            return $"Categoria [Id={Id}, Nombre={Nombre}, Descripcion={Descripcion}]";
        }
    }
}
