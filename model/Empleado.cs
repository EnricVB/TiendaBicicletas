using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.model {
    internal class Empleado(string dni, string nombre, Tienda tienda, float sueldo, string banco, string direccion, bool esJefe) {
        public int Id { get; set; }
        public string DNI { get; set; } = dni;
        public string Nombre { get; set; } = nombre;
        public float Sueldo { get; set; } = sueldo;
        public string Banco { get; set; } = banco;
        public string Direccion { get; set; } = direccion;
        public bool esJefe { get; set; } = esJefe;
        public Tienda? Tienda { get; set; } = tienda;
    }
}
