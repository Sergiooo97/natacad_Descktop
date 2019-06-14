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
using System.Configuration;

namespace Nat_App_1
{
    /// <summary>
    /// Lógica de interacción para alumno_edicion.xaml
    /// </summary>
    public partial class alumno_edicion : Window
    {
        public alumno_edicion()
        {
            InitializeComponent();
        }

        private void alumnosedicion_back(object sender, RoutedEventArgs e)
        {
            alumno alumnoback = new alumno();
            alumnoback.Show();
            this.Close();
        }

        private void alumno_editado_check(object sender, RoutedEventArgs e)
        {
            if (txtAlumnoId.Text != "")
            {
                DBClass.GetConnectionStrings();
                try
                {
                    DBClass.openConnection();
                    string query = "UPDATE natacadT set Nombre='" + this.txtNombreAlumnoED.Text + "',Apellidos='" + this.txtApellidoAlumnoED.Text + "',Edad='" + this.txtEdadED.Text + "',Grado='" + this.txtGradoED.Text + "',Municipio='" + this.txtMunicipiED.Text + "',Direccion='" + this.txtDireccioED.Text + "',Fecha_de_nacimiento='" + this.txtNacimientoED.Text + "',Nombre_Tutor='" + this.txtNombreTutorED.Text + "',Apellidos_Tutor='"+this.txtApellidoTutorED.Text+"',Celular_Tutor='"+this.txtNumeroED.Text+"' WHERE Id='" + this.txtAlumnoId.Text + "'";
                    SqlCommand createCom = new SqlCommand(query, DBClass.con);
                    createCom.ExecuteNonQuery();
                    MessageBox.Show("El alumno ha sido editado");
                    txtAlumnoId.Text = "";
                    txtNombreAlumnoED.Text = "";
                    txtApellidoAlumnoED.Text = "";
                    txtEdadED.Text = "";
                    txtGradoED.Text = "";
                    txtMunicipiED.Text = "";
                    txtDireccioED.Text = "";
                    txtNacimientoED.Text = "";
                    txtNombreTutorED.Text = "";
                    txtApellidoTutorED.Text = "";
                    txtNumeroED.Text = "";
                    DBClass.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Coloque el Id del alumno al que desee editar !");
            }
        }

        private void TxtNombreAlumnoED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo letras
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {              
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtApellidoAlumnoED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo letras
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtMunicipiED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo letras
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNombreTutorED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo letras
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtApellidoTutorED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo letras
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtEdadED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo numeros
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtEdadED.Text.Length >= 2)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNumeroED_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo numeros
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtNumeroED.Text.Length >= 10 && txtNumeroED.Text.Length <= 10)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtAlumnoId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtAlumnoId.Text.Length >= 5)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void alumno_editado_show(object sender, RoutedEventArgs e)
        {
            if (txtAlumnoId.Text != "")
            {
                DBClass.GetConnectionStrings();
                DBClass.openConnection();
                MessageBox.Show("Datos mostrados correctamente");
                string sqlSelectQuery = "SELECT * FROM natacadT WHERE Id=" + int.Parse(txtAlumnoId.Text);
                SqlCommand cmd = new SqlCommand(sqlSelectQuery, DBClass.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtNombreAlumnoED.Text = (dr["Nombre"].ToString());
                    txtApellidoAlumnoED.Text = (dr["Apellidos"].ToString());
                    txtEdadED.Text = (dr["Edad"].ToString());
                    txtGradoED.Text = (dr["Grado"].ToString());
                    txtMunicipiED.Text = (dr["Municipio"].ToString());
                    txtDireccioED.Text = (dr["Direccion"].ToString());
                    txtNacimientoED.Text = (dr["Fecha_de_nacimiento"].ToString());
                    txtNombreTutorED.Text = (dr["Nombre_Tutor"].ToString());
                    txtApellidoTutorED.Text = (dr["Apellidos_Tutor"].ToString());
                    txtNumeroED.Text = (dr["Celular_Tutor"].ToString());
                }
                DBClass.closeConnection();
            }
            else
            {
                MessageBox.Show("Por favor coloque el ID del alumno");
            }
        }
    }
}
