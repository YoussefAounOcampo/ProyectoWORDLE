using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
           

            using (StreamReader reader = new StreamReader(@"..\..\..\WpfProyecto\Words\registro.txt"))
            {
                String text = reader.ReadToEnd();
                String[] words = text.Split('\n');
                foreach (String word in words)
                {
                    Caja.Text += word;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Inicio restart= new Inicio();
            this.Close();
            restart.Show();
        }
    }
}
