
using System.Windows;


namespace WpfProyecto
{
    /// <summary>
    /// Interaction logic for Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            MainWindow m1 = new MainWindow();
            this.Close();
            m1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Instrucciones instrucciones = new Instrucciones();
            this.Close();
            instrucciones.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Registro register = new Registro();
            this.Close();
            register.Show();
        }
    }
}
