using MySqlConnector;

using System.Windows;
using TiendaBicicletas.src.database;
using TiendaBicicletas.src.model;

namespace TiendaBicicletas.src.database.dao
{
    internal class CategoriaDAO : IDAO<Categoria>
    {
        public void Delete(int id)
        {
            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "DELETE FROM categoria WHERE id=@catID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@catID", id);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la categoría con id {id}: {ex.Message}");
            }
        }

        public Categoria? Get(int id)
        {
            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT nombre, descripcion FROM Categoria WHERE id = @catID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@catID", id);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string c_nombre = reader.GetString(0);
                    string c_descripcion = reader.GetString(1);

                    return new(c_nombre, c_descripcion)
                    {
                        Id = id
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la categoría con id {id}: {ex.Message}");
            }

            return null;
        }

        public List<Categoria> List()
        {
            List<Categoria> categorias = [];

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECt * FROM Categoria";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int c_id = reader.GetInt32(0);
                        string c_nombre = reader.GetString(1);
                        string c_descripcion = reader.GetString(2);

                        categorias.Add(new(c_nombre, c_descripcion)
                        {
                            Id = c_id
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todas las categorías: {ex.Message}");
            }

            return categorias;
        }

        public void Insert(Categoria value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "INSERT INTO categoria (nombre, descripcion) VALUES (@catName, @catDesc);";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@catName", value.Nombre);
                command.Parameters.AddWithValue("@catDesc", value.Descripcion);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar: {ex.Message}");
            }
        }


        public void Update(int id, Categoria value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "UPDATE categoria SET nombre=@catName, descripcion=@catDesc WHERE id=@catID;";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@catID", id);
                command.Parameters.AddWithValue("@catName", value.Nombre);
                command.Parameters.AddWithValue("@catDesc", value.Descripcion);
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