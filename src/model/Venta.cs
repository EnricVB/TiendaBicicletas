using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Venta(Tienda tienda, Cliente? cliente, Producto producto, int cantidad, DateTime fecha)
    {
        public Tienda Tienda { get; set; } = tienda;
        public Cliente? Cliente { get; set; } = cliente;
        public Producto Producto { get; set; } = producto;
        public int Cantidad { get; set; } = cantidad;
        public DateTime fecha { get; set; } = fecha;
    }
}
