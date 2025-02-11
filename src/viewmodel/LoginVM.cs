using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TiendaBicicletas.src.database.dao;
using TiendaBicicletas.src.model;

namespace TiendaBicicletas.src.viewmodel {
    class LoginVM(Login loginView, Cliente cliente) {

        public void OnLogin() {
            ClienteDAO dao = new();

            if (IsCorrectUsername()) {
                if (!dao.Exists(cliente)) {
                    dao.Insert(cliente);
                }

                loginView.Close();
            } else {
                MessageBox.Show($"El nombre de usuario {cliente.Nombre} es incorrecto");
            }
        }

        private void ShowNewWindow() {

        }

        private bool IsCorrectUsername() {
            if (cliente == null) return false;
            if (cliente.Nombre.Length == 0) return false;

            return true;
        }
    }
}
