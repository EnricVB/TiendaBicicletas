﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.model
{
    internal class Producto(string nombre, string descripcion, decimal precio, Categoria? categoria)
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = nombre;
        public string? Descripcion { get; set; } = descripcion;
        public decimal Precio { get; set; } = precio;
        public Categoria? Categoria { get; set; } = categoria;
    }
}
