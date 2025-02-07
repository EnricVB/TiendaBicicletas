using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Inventario(Tienda tienda, Producto producto, int stock)
    {
        public Tienda Tienda { get; set; } = tienda;
        public Producto Producto { get; set; } = producto;
        public int Stock { get; set; } = stock;
    }
}
