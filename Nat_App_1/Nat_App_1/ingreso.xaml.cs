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
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;
using Nat_App_1.Classes;

namespace Nat_App_1
{
    /// <summary>
    /// Lógica de interacción para ingreso.xaml
    /// </summary>
    public partial class ingreso : Window
    {
        public ingreso()
        {
            InitializeComponent();
        }

        private void ingreso_back(object sender, RoutedEventArgs e)
        {
            MainW mw = new MainW();
            mw.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           
            DBClass.openConnection();
            DBClass.sql = "SELECT [cantidad], [Descripcion] FROM DineroS;";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;
            //
            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);
            myDataGridIngresos.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
            // mostrar total de dinero
            DBClass.GetConnectionStrings();
            DBClass.openConnection();
            string sqlSelectQuery = "SELECT Disponible FROM DineroNT";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, DBClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtTotal.Text = (dr["Disponible"].ToString());
            }
            DBClass.closeConnection();
        }

        private void TxtCantidad_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtCantidad.Text.Length >= 5)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtCantidad.Text!="" && txtTotal.Text!="" && txtDescripcion.Text != "")
            {
                natacadEntities dbe = new natacadEntities();
                DineroS nt = new DineroS();
                nt.codigo = int.Parse("234");
                nt.cantidad = int.Parse(txtCantidad.Text);
                nt.Descripcion = txtDescripcion.Text;
                dbe.DineroS.Add(nt);
                dbe.SaveChanges();
                MessageBox.Show("Operación realizada con éxito");
                // actualizar
                DBClass.openConnection();
                DBClass.sql = "SELECT [cantidad], [Descripcion] FROM DineroS;";
                DBClass.cmd.CommandType = CommandType.Text;
                DBClass.cmd.CommandText = DBClass.sql;
                //
                DBClass.da = new SqlDataAdapter(DBClass.cmd);
                DBClass.dt = new DataTable();
                DBClass.da.Fill(DBClass.dt);
                myDataGridIngresos.ItemsSource = DBClass.dt.DefaultView;
                DBClass.closeConnection();
                // mostrar total de dinero
                DBClass.GetConnectionStrings();
                DBClass.openConnection();
                string sqlSelectQuery = "SELECT Disponible FROM DineroNT";
                SqlCommand cmd = new SqlCommand(sqlSelectQuery, DBClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtTotal.Text = (dr["Disponible"].ToString());
                }
                DBClass.closeConnection();               
                txtCantidad.Text = "";
                txtDescripcion.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor llenar todos los campos");
            }
        }

        private void TxtTotal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = true;                
            }
            else
            {
                e.Handled = true;
            }
        }
    }

}
