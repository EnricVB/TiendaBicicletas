using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TiendaBicicletas.src.database;
using TiendaBicicletas.src.model;

namespace TiendaBicicletas.src.database.dao
{
    internal class TiendaDAO : IDAO<Tienda>
    {
        public void Delete(int id)
        {
            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "DELETE FROM tienda WHERE id=@tiendaID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", id);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la tienda con id {id}: {ex.Message}");
            }
        }

        public Tienda? Get(int id)
        {
            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT direccion FROM tienda WHERE id = @tiendaID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", id);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string t_direccion = reader.GetString(0);

                    return new(t_direccion)
                    {
                        Id = id
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la tienda con id {id}: {ex.Message}");
            }

            return null;
        }

        public List<Tienda> List()
        {
            List<Tienda> tiendas = [];

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT * FROM Tienda";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int t_id = reader.GetInt32(0);
                        string t_direccion = reader.GetString(1);

                        tiendas.Add(new(t_direccion)
                        {
                            Id = t_id
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todas las tiendas: {ex.Message}");
            }

            return tiendas;
        }

        public void Insert(Tienda value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "INSERT INTO Tienda (direccion) VALUES (@tiendaDireccion);";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaDireccion", value.Direccion);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar: {ex.Message}");
            }
        }


        public void Update(int id, Tienda value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "UPDATE Tienda SET direccion=@tiendaDireccion WHERE id=@tiendaID;";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", id);
                command.Parameters.AddWithValue("@tiendaDireccion", value.Direccion);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}");
            }
        }
    }
}