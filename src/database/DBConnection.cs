using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBicicletas.src.database {
    internal class DBConnection {

        // Esto no se debería insertar aquí, sino usando un fichero de configuración.
        private static readonly MySqlConnectionStringBuilder builder =
            new() {
                Server = "10.192.34.34",
                Port = 3306,
                Database = "tiendabicicletas",
                UserID = "admin",
                Password = "admin"
            };

        private static MySqlConnection? connection = null;

        private DBConnection() { }

        public static MySqlConnection GetConnection() {
            if (connection == null) {
                connection = new MySqlConnection(builder.ToString());
                connection.Open();
            }

            return connection;
        }
    }
}
