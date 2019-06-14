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
    /// Lógica de interacción para MainW.xaml
    /// </summary>
    public partial class MainW : Window
    {
        public MainW()
        {
            InitializeComponent();
            Alumnos alumnos = new Alumnos();
            DataContext = new AlumnosViewModel(alumnos);
        }
        private void power_one_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void alumno_click(object sender, RoutedEventArgs e)
        {
            alumno al = new alumno();
            al.Show();
            this.Close();
        }

        private void formulario_click(object sender, RoutedEventArgs e)
        {
            formulario fo = new formulario();
            fo.Show();
            this.Close();
        }

        private void ingreso_click(object sender, RoutedEventArgs e)
        {
            ingreso ingre = new ingreso();
            ingre.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBClass.GetConnectionStrings();
            DBClass.openConnection();
            string sqlSelectQuery = "SELECT disponible FROM DineroNT";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, DBClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtIngresoMain.Text = ("$ ")+(dr["disponible"].ToString());
            }
            DBClass.closeConnection();
        }
    }

    internal class AlumnosViewModel
    {
        public List<Alumnos> Alumnos { get; private set; }

        public AlumnosViewModel(Alumnos alumnos)
        {
            Alumnos = new List<Alumnos>();
            Alumnos.Add(alumnos);
        }
    }

    internal class Alumnos
    {
        public string Titulo { get; private set; }
        public int Porcentaje { get; private set; }

        public Alumnos()
        {
            DBClass.GetConnectionStrings();
            DBClass.openConnection();
            string sqlSelectQuery = "SELECT disponible FROM DineroNT";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, DBClass.con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Titulo = "Ingresos totales: Periodo 2018-2019";
                Porcentaje = int.Parse((dr["disponible"].ToString()))/1000; //CalcularPorcentaje();
            }
            DBClass.closeConnection();
            //Titulo = "Ingresos totales: Periodo 2018-2019";
            //Porcentaje = CalcularPorcentaje();
        }

        private int CalcularPorcentaje()
        {
            return 75;
        }
    }
}
