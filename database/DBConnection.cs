using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.database {
    internal class DBConnection {

        // Esto no se debería insertar aquí, sino usando un fichero de configuración.
        private static readonly MySqlConnectionStringBuilder builder =
            new () {
                Server = "localhost",
                Port = 3306,
                Database = "tiendabicicletas",
                UserID = "admin",
                Password = "admin"
        };

        private DBConnection() { }

        public static MySqlConnection GetConnection() {
            return new MySqlConnection(builder.ToString());
        }
    }
}
