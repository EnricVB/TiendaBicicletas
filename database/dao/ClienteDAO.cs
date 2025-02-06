using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using TiendaBicicletas.model;

namespace TiendaBicicletas.database.dao {
    internal class ClienteDAO : IDAO<Cliente> {
        public void Delete(int id) {
            try {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "DELETE FROM clientes WHERE id=@cliID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@cliID", id);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show($"Error al eliminar el cliente con id {id}: {ex.Message}");
            }
        }

        public Cliente Get(int id) {
            try {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Creación de la consulta
                string consulta = "SELECT nombre FROM clientes WHERE id=@cliID";

                // Preparación del comando
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@cliID", id);
                command.Prepare();

                // Lectura de datos
                using MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read()) {
                    return new(reader.GetString(0));
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al obtener el cliente con id {id}: {ex.Message}");
            }

            return null;
        }

        public List<Cliente> List() {
            List<Cliente> clientes = [];

            try {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Creación de la consulta
                string consulta = "SELECT id, nombre FROM Clientes";

                // Preparación del comando
                MySqlCommand command = new(consulta, connection);
                command.Prepare();

                // Lectura de datos
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    
                    clientes.Add(new(nombre) {
                        Id = id
                    });
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al obtener el cliente con id {id}: {ex.Message}");
            }

            return clientes;
        }

        public void Insert(Cliente value) {
            try {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "INSERT INTO clientes (nombre) VALUES (@cliName);";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@cliName", value.Nombre);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show($"Error al insertar: {ex.Message}");
            }
        }

        public void Update(int id, Cliente value) {
            try {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "UPDATE clientes SET nombre=@cliName WHERE id=@cliID;";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@cliID", id);
                command.Parameters.AddWithValue("@cliName", value.Nombre);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show($"Error al actualizar: {ex.Message}");
            }
        }
    }
}
