using MySqlConnector;

using System.Windows;
using TiendaBicicletas.src.model;
using TiendaBicicletas.src.viewmodel;

namespace TiendaBicicletas {
    public partial class Login : Window {
        private Cliente cliente = new("📧 Username");

        public Login() {
            InitializeComponent();
            this.DataContext = cliente;
        }

        private void OnButtonLogin(object sender, RoutedEventArgs e) {
            new LoginVM(this, cliente).OnLogin();
        }
    }
}