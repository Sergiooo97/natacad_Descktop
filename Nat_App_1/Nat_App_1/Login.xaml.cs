using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nat_App_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void entrar_click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPass.Password;
            if (user == "Macarena" && password == "cacalchen2000")
            {
                MainW mw = new MainW();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("¡Por favor introduzca los datos correctos!");
                txtUser.Text = "";
                txtPass.Password = "";
            }
        }

        private void salir_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
