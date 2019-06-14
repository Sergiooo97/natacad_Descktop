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
    /// Lógica de interacción para alumno.xaml
    /// </summary>
    public partial class alumno : Window
    {
        public alumno()
        {
            InitializeComponent();
        }

        private void alumnos_back(object sender, RoutedEventArgs e)
        {
            MainW mw = new MainW();
            mw.Show();
            this.Close();
        }

        private void alumno_add(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();
            //DBClass.sql = "SELECT[UserID], [FirstName], [LastName], [DateOfBirth], [CompanyID], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate] FROM Table1;";
            DBClass.sql = "SELECT [Id], [Nombre], [Apellidos], [Edad], [Grado], [Fecha_de_nacimiento], [Municipio], [Direccion], [Nombre_Tutor], [Apellidos_Tutor], [Celular_Tutor] FROM natacadT;";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;
            //
            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);
            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }

        private void alumno_edit(object sender, RoutedEventArgs e)
        {
            alumno_edicion aledicion = new alumno_edicion();
            aledicion.Show();
            this.Close();
        }

        private void alumno_delete(object sender, RoutedEventArgs e)
        {
            if (txtEliminarId.Text != "")
            {
                DBClass.GetConnectionStrings();
                try
                {
                    DBClass.openConnection();
                    string query = "DELETE FROM natacadT WHERE Id='" + this.txtEliminarId.Text + "'";
                    //string query = "DELETE FROM natacadT WHERE Id='" + this.txtID.Text + "'";
                    SqlCommand createCom = new SqlCommand(query, DBClass.con);
                    createCom.ExecuteNonQuery();
                    MessageBox.Show("Alumno eliminado");                  
                    DBClass.closeConnection();
                    // mostrar
                    DBClass.openConnection();
                    //DBClass.sql = "SELECT[UserID], [FirstName], [LastName], [DateOfBirth], [CompanyID], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate] FROM Table1;";
                    DBClass.sql = "SELECT [Id], [Nombre], [Apellidos], [Edad], [Grado], [Fecha_de_nacimiento], [Municipio], [Direccion], [Nombre_Tutor], [Apellidos_Tutor], [Celular_Tutor] FROM natacadT;";
                    DBClass.cmd.CommandType = CommandType.Text;
                    DBClass.cmd.CommandText = DBClass.sql;
                    //
                    DBClass.da = new SqlDataAdapter(DBClass.cmd);
                    DBClass.dt = new DataTable();
                    DBClass.da.Fill(DBClass.dt);
                    myDataGrid.ItemsSource = DBClass.dt.DefaultView;
                    DBClass.closeConnection();
                    txtEliminarId.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor coloque el ID del alumno");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBClass.openConnection();
            //DBClass.sql = "SELECT[UserID], [FirstName], [LastName], [DateOfBirth], [CompanyID], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate] FROM Table1;";
            DBClass.sql = "SELECT [Id], [Nombre], [Apellidos], [Edad], [Grado], [Fecha_de_nacimiento], [Municipio], [Direccion], [Nombre_Tutor], [Apellidos_Tutor], [Celular_Tutor] FROM natacadT;";
            DBClass.cmd.CommandType = CommandType.Text;
            DBClass.cmd.CommandText = DBClass.sql;
            //
            DBClass.da = new SqlDataAdapter(DBClass.cmd);
            DBClass.dt = new DataTable();
            DBClass.da.Fill(DBClass.dt);
            myDataGrid.ItemsSource = DBClass.dt.DefaultView;
            DBClass.closeConnection();
        }

        private void TxtEliminarId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtEliminarId.Text.Length >= 5)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
