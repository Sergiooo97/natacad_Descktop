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

namespace Nat_App_1
{
    /// <summary>
    /// Lógica de interacción para formulario.xaml
    /// </summary>
    public partial class formulario : Window
    {
        public formulario()
        {
            InitializeComponent();
        }

        private void formulario_back(object sender, RoutedEventArgs e)
        {
            MainW mw = new MainW();
            mw.Show();
            this.Close();
        }

        private void entrar_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hola");
        }

        private void formulario_check(object sender, RoutedEventArgs e)
        {
            string nombreA = txtNombreAlumnoFO.Text;
            string apellidoA = txtApellidoAlumnoFO.Text;
            string edad = txtEdadFO.Text;
            string grado = txtGradoFO.Text;
            string municipio = txtMunicipiFO.Text;
            string direccion = txtDireccioFO.Text;
            string nacimiento = txtNacimientoFO.Text;
            string nombreT = txtNombreTutorFO.Text;
            string apellidoT = txtApellidoTutorFO.Text;
            string numero = txtNumeroFO.Text;
            if (nombreA !="" && apellidoA !="" && edad !="" && grado !="" && municipio !="" && direccion !="" && nacimiento !="" && nombreT !="" && apellidoT !="" && numero !="")
            {
                natacadEntities dbe = new natacadEntities();
                natacadT nt = new natacadT();
                nt.Nombre = txtNombreAlumnoFO.Text;
                nt.Apellidos = txtApellidoAlumnoFO.Text;
                nt.Edad = txtEdadFO.Text + " Años";
                nt.Grado = txtGradoFO.Text;
                nt.Municipio = txtMunicipiFO.Text;
                nt.Direccion = txtDireccioFO.Text;
                nt.Fecha_de_nacimiento = Convert.ToDateTime(txtNacimientoFO.Text);
                nt.Nombre_Tutor = txtNombreTutorFO.Text;
                nt.Apellidos_Tutor = txtApellidoTutorFO.Text;
                nt.Celular_Tutor = txtNumeroFO.Text;
                nt.codigo = int.Parse("234");
                nt.cantidad = int.Parse("1500");
                dbe.natacadT.Add(nt);
                dbe.SaveChanges();
                MessageBox.Show("El formulario ha sido completado");
                txtNombreAlumnoFO.Text = "";
                txtApellidoAlumnoFO.Text = "";
                txtEdadFO.Text = "";
                txtGradoFO.Text = "";
                txtMunicipiFO.Text = "";
                txtDireccioFO.Text = "";
                txtNacimientoFO.Text = "";
                txtNombreTutorFO.Text = "";
                txtApellidoTutorFO.Text = "";
                txtNumeroFO.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor complete el formulario");
            }
        }

        private void TxtNombreAlumnoFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TxtApellidoAlumnoFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TxtMunicipiFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TxtNombreTutorFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TxtApellidoTutorFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void TxtEdadFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo numeros
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if (txtEdadFO.Text.Length >= 2)
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNumeroFO_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // solo numeros
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
            {
                e.Handled = false;
                if(txtNumeroFO.Text.Length>=10 && txtNumeroFO.Text.Length <= 10)
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
