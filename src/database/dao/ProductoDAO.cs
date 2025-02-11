using MySqlConnector;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TiendaBicicletas.src.database;
using TiendaBicicletas.src.model;

namespace TiendaBicicletas.src.database.dao {
    internal class ProductoDAO : IDAO<Producto> {
        public void Delete(int id) {
            try {
                // Creación de la conexión a BBDD
                using MySqlConnection connection = DBConnection.GetConnection();

                // Consulta a BBDD
                string consulta = "DELETE FROM producto WHERE id=@prodID";

                // Asignación de variables a la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@prodID", id);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show($"Error al eliminar el producto con id {id}: {ex.Message}");
            }
        }

        public Producto? Get(int id) {
            CategoriaDAO categoriaDAO = new();

            try {
                // Creación de conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();

                // Consulta a BBDD
                string consulta = "SELECT nombre, descripcion, precio, categoria FROM productos WHERE id=@prodID";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@prodID", id);
                command.Prepare();

                // Lectura de datos
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    string nombre = reader.GetString(0);
                    string descripcion = reader.GetString(1);
                    decimal precio = reader.GetDecimal(2);
                    int categoriaID = reader.GetInt32(3);

                    return new(nombre, descripcion, precio, categoriaDAO.Get(categoriaID)) {
                        Id = id
                    };
                }
            } catch (Exception e) {
                MessageBox.Show($"Error al obtener el producto con id {id}: {e.Message}");
            }

            return null;
        }

        public List<Producto> List() {
            CategoriaDAO categoriaDAO = new();
            List<Producto> productos = [];

            try {
                // Creación de conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();

                // Consulta a BBDD
                string consulta = "SELECT id, nombre, descripcion, precio, categoria FROM productos";

                // Preparación de la consulta
                MySqlCommand command = new(consulta, connection);
                command.Prepare();

                // Lectura de datos
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string descripcion = reader.GetString(2);
                    decimal precio = reader.GetDecimal(3);
                    int categoriaID = reader.GetInt32(4);

                    productos.Add(new(nombre, descripcion, precio, categoriaDAO.Get(categoriaID)) {
                        Id = id
                    });
                }
            } catch (Exception e) {
                MessageBox.Show($"Error al obtener todos los productos: {e.Message}");
            }

            return productos;
        }

        public void Insert(Producto value) {
            try {
                // Creación de conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();

                // Consulta a BBDD
                string consulta = "INSERT INTO productos(nombre, descripcion, precio, categoria) VALUES(@prodName, @prodDesc, @prodPrecio, @prodCat)";

                // Preparación de la consula
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@prodName", value.Nombre);
                command.Parameters.AddWithValue("@prodDesc", value.Descripcion);
                command.Parameters.AddWithValue("@prodPrecio", value.Precio);
                command.Parameters.AddWithValue("@prodCat", value.Categoria?.Id ?? null);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show($"Error al insertar un producto: {e.Message}");
            }
        }

        public void Update(int id, Producto value) {
            try {
                // Creación de conexión a BBDD
                MySqlConnection connection = DBConnection.GetConnection();

                // Consulta a BBDD
                string consulta = "UPDATE productos SET nombre=@prodName, descripcion=@prodDesc, precio=@prodPrecio, categoria=@prodCat WHERE id=@prodID)";

                // Preparación de la consula
                MySqlCommand command = new(consulta, connection);
                command.Parameters.AddWithValue("@prodID", id);
                command.Parameters.AddWithValue("@prodName", value.Nombre);
                command.Parameters.AddWithValue("@prodDesc", value.Descripcion);
                command.Parameters.AddWithValue("@prodPrecio", value.Precio);
                command.Parameters.AddWithValue("@prodCat", value.Categoria?.Id ?? null);
                command.Prepare();

                // Ejecución de la consulta
                command.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show($"Error al insertar un producto: {e.Message}");
            }
        }
    }
}
