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
    internal class VentaDAO
    {

        public List<Venta> ListByShop(int tiendaID)
        {
            List<Venta> ventas = [];
            ProductoDAO productoDAO = new();
            ClienteDAO clienteDAO = new();
            TiendaDAO tiendaDAO = new();

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT * FROM Venta WHERE tienda=@tiendaID";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", tiendaID);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tienda tienda = tiendaDAO.Get(reader.GetInt32(0));
                        Cliente cliente = clienteDAO.Get(reader.GetInt32(1));
                        Producto producto = productoDAO.Get(reader.GetInt32(2));
                        int cantidad = reader.GetInt32(3);
                        DateTime fecha = reader.GetDateTime(4);

                        if (tienda != null && producto != null)
                        {
                            ventas.Add(new(tienda, cliente, producto, cantidad, fecha));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas por tienda: {ex.Message}");
            }

            return ventas;
        }

        public List<Venta> ListByClient(int clienteID)
        {
            List<Venta> ventas = [];
            ProductoDAO productoDAO = new();
            ClienteDAO clienteDAO = new();
            TiendaDAO tiendaDAO = new();

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT * FROM Venta WHERE cliente=@clienteID";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@clienteID", clienteID);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tienda tienda = tiendaDAO.Get(reader.GetInt32(0));
                        Cliente cliente = clienteDAO.Get(reader.GetInt32(1));
                        Producto producto = productoDAO.Get(reader.GetInt32(2));
                        int cantidad = reader.GetInt32(3);
                        DateTime fecha = reader.GetDateTime(4);

                        if (tienda != null && producto != null)
                        {
                            ventas.Add(new(tienda, cliente, producto, cantidad, fecha));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas por cliente: {ex.Message}");
            }

            return ventas;
        }

        public List<Venta> ListByProduct(int productID)
        {
            List<Venta> ventas = [];
            ProductoDAO productoDAO = new();
            ClienteDAO clienteDAO = new();
            TiendaDAO tiendaDAO = new();

            try
            {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "SELECT * FROM Venta WHERE producto=@productID";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@productID", productID);
                command.Prepare();

                // Lectura de datos de la consulta
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tienda tienda = tiendaDAO.Get(reader.GetInt32(0));
                        Cliente cliente = clienteDAO.Get(reader.GetInt32(1));
                        Producto producto = productoDAO.Get(reader.GetInt32(2));
                        int cantidad = reader.GetInt32(3);
                        DateTime fecha = reader.GetDateTime(4);

                        if (tienda != null && producto != null)
                        {
                            ventas.Add(new(tienda, cliente, producto, cantidad, fecha));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas por cliente: {ex.Message}");
            }

            return ventas;
        }

        public void Insert(Venta value)
        {
            try
            {
                // Creación de la conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();
                connection.Open();

                // Consulta a BBDD
                string consulta = "INSERT INTO Venta VALUES (@tiendaID, @clienteID, @productoID, @cantidad, @fecha);";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@tiendaID", value.Tienda.Id);
                command.Parameters.AddWithValue("@productoID", value.Producto.Id);
                command.Parameters.AddWithValue("@cantidad", value.Cantidad);
                command.Parameters.AddWithValue("@fecha", value.fecha);
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