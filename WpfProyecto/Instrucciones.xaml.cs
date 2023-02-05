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

namespace WpfProyecto
{
    /// <summary>
    /// Interaction logic for Instrucciones.xaml
    /// </summary>
    public partial class Instrucciones : Window
    {
        public Instrucciones()
        {
            InitializeComponent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Inicio inicio= new Inicio();
            this.Close();
            inicio.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 100;
            this.Top = 100;
            this.Width = 800;
            this.Height = 450;
        }

    }
}
