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
    internal class InventarioDAO
    {
        public void Delete(int tiendaID, int productoID)
        {
            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "DELETE FROM inventario WHERE tienda=@tiendaID AND producto=@productoID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@productoID", productoID);
                command.Parameters.AddWithValue("@tiendaID", tiendaID);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el inventario del producto {productoID} en la tienda {tiendaID}: {ex.Message}");
            }
        }

        public Inventario? Get(int tiendaID)
        {
            ProductoDAO productoDAO = new();
            TiendaDAO tiendaDAO = new();

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT producto, stock FROM tienda WHERE id = @tiendaID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", tiendaID);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Tienda tienda = tiendaDAO.Get(tiendaID);
                    Producto producto = productoDAO.Get(reader.GetInt32(0));
                    int stock = reader.GetInt32(1);

                    if (tienda != null && producto != null)
                    {
                        return new(tienda, producto, stock);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la tienda con id {tiendaID}: {ex.Message}");
            }

            return null;
        }

        public List<Inventario> List()
        {
            List<Inventario> inventarios = [];
            ProductoDAO productoDAO = new();
            TiendaDAO tiendaDAO = new();

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT * FROM Inventario";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tienda tienda = tiendaDAO.Get(reader.GetInt32(0));
                        Producto producto = productoDAO.Get(reader.GetInt32(1));
                        int stock = reader.GetInt32(2);

                        if (tienda != null && producto != null)
                        {
                            inventarios.Add(new(tienda, producto, stock));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener todas las tiendas: {ex.Message}");
            }

            return inventarios;
        }

        public void Insert(Inventario value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "INSERT INTO Inventario (tienda, producto, stock) VALUES (@tiendaID, @productoID, @stock);";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", value.Tienda.Id);
                command.Parameters.AddWithValue("@productoID", value.Producto.Id);
                command.Parameters.AddWithValue("@stock", value.Stock);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar: {ex.Message}");
            }
        }


        public void Update(int stock, Inventario value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "UPDATE Inventario SET stock=@stock WHERE tienda=@tiendaID AND producto=@productID;";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@stock", stock);
                command.Parameters.AddWithValue("@tiendaID", value.Tienda.Id);
                command.Parameters.AddWithValue("@productID", value.Producto.Id);
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