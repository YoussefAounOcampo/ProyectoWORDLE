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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProyecto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String SecretWord = "";
        private static int contador; //Contador que nos servirá para saber en que intento estamos.
        private bool Win;


        
        public MainWindow()

        {
            Win = false;
            contador = -1;
            InitializeComponent();
            boton.Content = "Prueba";


            List<String> wordList = new List<String>();
            using (StreamReader reader = new StreamReader(@"..\..\..\WpfProyecto\Words\palabras.txt"))
            {
                String text = reader.ReadToEnd();
                String[] words = text.Split('\n');
                foreach (String word in words)
                {
                    wordList.Add(word);
                }
            }
            //Por defecto cargara la lista de 5 letras
            Random generador = new Random();
            int numeroAleatorio = generador.Next(1, 6);
            SecretWord = wordList[numeroAleatorio];
            char[] SecretWordArray = SecretWord.ToCharArray();

             debug.Content = SecretWord;



        }
        private void SendGuess(object sender, RoutedEventArgs e)
        {
            contador++;
            if (cajaTexto.Text.Length == 5) //Comprobamos que tenga el mismo lenght que la palabra a adivinar.
            {
                cajaTexto.Text = cajaTexto.Text.ToUpper();
                switch (contador)
                {
                    case 0:
                        CheckFirstRow();
                        break;

                    case 1:
                        CheckRow2();
                        break;

                    case 2:
                        CheckRow3();
                        break;

                    case 3:
                        CheckRow4();
                        break;

                    case 4:
                        CheckRow5();
                        break;

                    case 5:
                        //TODO FIN DE LA PARTIDA
                        break;
                }



            }

        }
        private void CheckRow5()
        {

            char[] Guess = cajaTexto.Text.ToCharArray();
            cajaTexto.Text = "";

            //TODO: Conprobar letras

            //COMPROBACION PRIMERA LETRA
            if (Guess[0].Equals(SecretWord[0]))
            {
                fila5_letra1.Background = new SolidColorBrush(Colors.Green);
                fila5_letra1.Text = Guess[0] + "";
            }
            else if (Guess[0].Equals(SecretWord[1]) || Guess[0].Equals(SecretWord[2]) || Guess[0].Equals(SecretWord[3]) || Guess[0].Equals(SecretWord[4]))
            {
                fila5_letra1.Background = new SolidColorBrush(Colors.Yellow);
                fila5_letra1.Text = Guess[0] + "";

            }
            else
            {
                fila5_letra1.Background = new SolidColorBrush(Colors.Gray);
                fila5_letra1.Text = Guess[0] + "";
            }


            //COMPROBACION SEGUNDA LETRA

            if (Guess[1].Equals(SecretWord[1]))
            {
                fila5_letra2.Background = new SolidColorBrush(Colors.Green);
                fila5_letra2.Text = Guess[1] + "";
            }
            else if (Guess[1].Equals(SecretWord[0]) || Guess[1].Equals(SecretWord[2]) || Guess[1].Equals(SecretWord[3]) || Guess[1].Equals(SecretWord[4]))
            {
                fila5_letra2.Background = new SolidColorBrush(Colors.Yellow);
                fila5_letra2.Text = Guess[1] + "";

            }
            else
            {
                fila5_letra2.Background = new SolidColorBrush(Colors.Gray);
                fila5_letra2.Text = Guess[1] + "";
            }


            //COMPROBACION TERCERA LETRA
            if (Guess[2].Equals(SecretWord[2]))
            {
                fila5_letra3.Background = new SolidColorBrush(Colors.Green);
                fila5_letra3.Text = Guess[2] + "";
            }
            else if (Guess[2].Equals(SecretWord[0]) || Guess[2].Equals(SecretWord[1]) || Guess[2].Equals(SecretWord[3]) || Guess[2].Equals(SecretWord[4]))
            {
                fila5_letra3.Background = new SolidColorBrush(Colors.Yellow);
                fila5_letra3.Text = Guess[2] + "";

            }
            else
            {
                fila5_letra3.Background = new SolidColorBrush(Colors.Gray);
                fila5_letra3.Text = Guess[2] + "";
            }


            //COMPROBACION CUARTA LETRA
            if (Guess[3].Equals(SecretWord[3]))
            {
                fila5_letra4.Background = new SolidColorBrush(Colors.Green);
                fila5_letra4.Text = Guess[3] + "";
            }
            else if (Guess[3].Equals(SecretWord[0]) || Guess[3].Equals(SecretWord[1]) || Guess[3].Equals(SecretWord[2]) || Guess[3].Equals(SecretWord[4]))
            {
                fila5_letra4.Background = new SolidColorBrush(Colors.Yellow);
                fila5_letra4.Text = Guess[3] + "";

            }
            else
            {
                fila5_letra4.Background = new SolidColorBrush(Colors.Gray);
                fila5_letra4.Text = Guess[3] + "";
            }

            //COMPROBACION QUINTA LETRA

            if (Guess[4].Equals(SecretWord[4]))
            {
                fila5_letra5.Background = new SolidColorBrush(Colors.Green);
                fila5_letra5.Text = Guess[4] + "";
            }
            else if (Guess[4].Equals(SecretWord[0]) || Guess[4].Equals(SecretWord[1]) || Guess[4].Equals(SecretWord[2]) || Guess[4].Equals(SecretWord[3]))
            {
                fila5_letra5.Background = new SolidColorBrush(Colors.Yellow);
                fila5_letra5.Text = Guess[4] + "";

            }
            else
            {
                fila5_letra5.Background = new SolidColorBrush(Colors.Gray);
                fila5_letra5.Text = Guess[4] + "";
            }

        }

        private void CheckRow4()
        {

            char[] Guess = cajaTexto.Text.ToCharArray();
            cajaTexto.Text = "";


            //TODO: Conprobar letras

            //COMPROBACION PRIMERA LETRA
            if (Guess[0].Equals(SecretWord[0]))
            {
                fila4_letra1.Background = new SolidColorBrush(Colors.Green);
                fila4_letra1.Text = Guess[0] + "";
            }
            else if (Guess[0].Equals(SecretWord[1]) || Guess[0].Equals(SecretWord[2]) || Guess[0].Equals(SecretWord[3]) || Guess[0].Equals(SecretWord[4]))
            {
                fila4_letra1.Background = new SolidColorBrush(Colors.Yellow);
                fila4_letra1.Text = Guess[0] + "";

            }
            else
            {
                fila4_letra1.Background = new SolidColorBrush(Colors.Gray);
                fila4_letra1.Text = Guess[0] + "";
            }


            //COMPROBACION SEGUNDA LETRA

            if (Guess[1].Equals(SecretWord[1]))
            {
                fila4_letra2.Background = new SolidColorBrush(Colors.Green);
                fila4_letra2.Text = Guess[1] + "";
            }
            else if (Guess[1].Equals(SecretWord[0]) || Guess[1].Equals(SecretWord[2]) || Guess[1].Equals(SecretWord[3]) || Guess[1].Equals(SecretWord[4]))
            {
                fila4_letra2.Background = new SolidColorBrush(Colors.Yellow);
                fila4_letra2.Text = Guess[1] + "";

            }
            else
            {
                fila4_letra2.Background = new SolidColorBrush(Colors.Gray);
                fila4_letra2.Text = Guess[1] + "";
            }


            //COMPROBACION TERCERA LETRA
            if (Guess[2].Equals(SecretWord[2]))
            {
                fila4_letra3.Background = new SolidColorBrush(Colors.Green);
                fila4_letra3.Text = Guess[2] + "";
            }
            else if (Guess[2].Equals(SecretWord[0]) || Guess[2].Equals(SecretWord[1]) || Guess[2].Equals(SecretWord[3]) || Guess[2].Equals(SecretWord[4]))
            {
                fila4_letra3.Background = new SolidColorBrush(Colors.Yellow);
                fila4_letra3.Text = Guess[2] + "";

            }
            else
            {
                fila4_letra3.Background = new SolidColorBrush(Colors.Gray);
                fila4_letra3.Text = Guess[2] + "";
            }


            //COMPROBACION CUARTA LETRA
            if (Guess[3].Equals(SecretWord[3]))
            {
                fila4_letra4.Background = new SolidColorBrush(Colors.Green);
                fila4_letra4.Text = Guess[3] + "";
            }
            else if (Guess[3].Equals(SecretWord[0]) || Guess[3].Equals(SecretWord[1]) || Guess[3].Equals(SecretWord[2]) || Guess[3].Equals(SecretWord[4]))
            {
                fila4_letra4.Background = new SolidColorBrush(Colors.Yellow);
                fila4_letra4.Text = Guess[3] + "";

            }
            else
            {
                fila4_letra4.Background = new SolidColorBrush(Colors.Gray);
                fila4_letra4.Text = Guess[3] + "";
            }

            //COMPROBACION QUINTA LETRA

            if (Guess[4].Equals(SecretWord[4]))
            {
                fila4_letra5.Background = new SolidColorBrush(Colors.Green);
                fila4_letra5.Text = Guess[4] + "";
            }
            else if (Guess[4].Equals(SecretWord[0]) || Guess[4].Equals(SecretWord[1]) || Guess[4].Equals(SecretWord[2]) || Guess[4].Equals(SecretWord[3]))
            {
                fila4_letra5.Background = new SolidColorBrush(Colors.Yellow);
                fila4_letra5.Text = Guess[4] + "";

            }
            else
            {
                fila4_letra5.Background = new SolidColorBrush(Colors.Gray);
                fila4_letra5.Text = Guess[4] + "";
            }

        }

        private void CheckRow3()
        {

            char[] Guess = cajaTexto.Text.ToCharArray();
            cajaTexto.Text = "";


            //TODO: Conprobar letras

            //COMPROBACION PRIMERA LETRA
            if (Guess[0].Equals(SecretWord[0]))
            {
                fila3_letra1.Background = new SolidColorBrush(Colors.Green);
                fila3_letra1.Text = Guess[0] + "";
            }
            else if (Guess[0].Equals(SecretWord[1]) || Guess[0].Equals(SecretWord[2]) || Guess[0].Equals(SecretWord[3]) || Guess[0].Equals(SecretWord[4]))
            {
                fila3_letra1.Background = new SolidColorBrush(Colors.Yellow);
                fila3_letra1.Text = Guess[0] + "";

            }
            else
            {
                fila3_letra1.Background = new SolidColorBrush(Colors.Gray);
                fila3_letra1.Text = Guess[0] + "";
            }


            //COMPROBACION SEGUNDA LETRA

            if (Guess[1].Equals(SecretWord[1]))
            {
                fila3_letra2.Background = new SolidColorBrush(Colors.Green);
                fila3_letra2.Text = Guess[1] + "";
            }
            else if (Guess[1].Equals(SecretWord[0]) || Guess[1].Equals(SecretWord[2]) || Guess[1].Equals(SecretWord[3]) || Guess[1].Equals(SecretWord[4]))
            {
                fila3_letra2.Background = new SolidColorBrush(Colors.Yellow);
                fila3_letra2.Text = Guess[1] + "";

            }
            else
            {
                fila3_letra2.Background = new SolidColorBrush(Colors.Gray);
                fila3_letra2.Text = Guess[1] + "";
            }


            //COMPROBACION TERCERA LETRA
            if (Guess[2].Equals(SecretWord[2]))
            {
                fila3_letra3.Background = new SolidColorBrush(Colors.Green);
                fila3_letra3.Text = Guess[2] + "";
            }
            else if (Guess[2].Equals(SecretWord[0]) || Guess[2].Equals(SecretWord[1]) || Guess[2].Equals(SecretWord[3]) || Guess[2].Equals(SecretWord[4]))
            {
                fila3_letra3.Background = new SolidColorBrush(Colors.Yellow);
                fila3_letra3.Text = Guess[2] + "";

            }
            else
            {
                fila3_letra3.Background = new SolidColorBrush(Colors.Gray);
                fila3_letra3.Text = Guess[2] + "";
            }


            //COMPROBACION CUARTA LETRA
            if (Guess[3].Equals(SecretWord[3]))
            {
                fila3_letra4.Background = new SolidColorBrush(Colors.Green);
                fila3_letra4.Text = Guess[3] + "";
            }
            else if (Guess[3].Equals(SecretWord[0]) || Guess[3].Equals(SecretWord[1]) || Guess[3].Equals(SecretWord[2]) || Guess[3].Equals(SecretWord[4]))
            {
                fila3_letra4.Background = new SolidColorBrush(Colors.Yellow);
                fila3_letra4.Text = Guess[3] + "";

            }
            else
            {
                fila3_letra4.Background = new SolidColorBrush(Colors.Gray);
                fila3_letra4.Text = Guess[3] + "";
            }

            //COMPROBACION QUINTA LETRA

            if (Guess[4].Equals(SecretWord[4]))
            {
                fila3_letra5.Background = new SolidColorBrush(Colors.Green);
                fila3_letra5.Text = Guess[4] + "";
            }
            else if (Guess[4].Equals(SecretWord[0]) || Guess[4].Equals(SecretWord[1]) || Guess[4].Equals(SecretWord[2]) || Guess[4].Equals(SecretWord[3]))
            {
                fila3_letra5.Background = new SolidColorBrush(Colors.Yellow);
                fila3_letra5.Text = Guess[4] + "";

            }
            else
            {
                fila3_letra5.Background = new SolidColorBrush(Colors.Gray);
                fila3_letra5.Text = Guess[4] + "";
            }

        }

        private void CheckRow2()
        {

            char[] Guess = cajaTexto.Text.ToCharArray();
            cajaTexto.Text = "";


            //TODO: Conprobar letras

            //COMPROBACION PRIMERA LETRA
            if (Guess[0].Equals(SecretWord[0]))
            {
                fila2_letra1.Background = new SolidColorBrush(Colors.Green);
                fila2_letra1.Text = Guess[0] + "";
            }
            else if (Guess[0].Equals(SecretWord[1]) || Guess[0].Equals(SecretWord[2]) || Guess[0].Equals(SecretWord[3]) || Guess[0].Equals(SecretWord[4]))
            {
                fila2_letra1.Background = new SolidColorBrush(Colors.Yellow);
                fila2_letra1.Text = Guess[0] + "";

            }
            else
            {
                fila2_letra1.Background = new SolidColorBrush(Colors.Gray);
                fila2_letra1.Text = Guess[0] + "";
            }


            //COMPROBACION SEGUNDA LETRA

            if (Guess[1].Equals(SecretWord[1]))
            {
                fila2_letra2.Background = new SolidColorBrush(Colors.Green);
                fila2_letra2.Text = Guess[1] + "";
            }
            else if (Guess[1].Equals(SecretWord[0]) || Guess[1].Equals(SecretWord[2]) || Guess[1].Equals(SecretWord[3]) || Guess[1].Equals(SecretWord[4]))
            {
                fila2_letra2.Background = new SolidColorBrush(Colors.Yellow);
                fila2_letra2.Text = Guess[1] + "";

            }
            else
            {
                fila2_letra2.Background = new SolidColorBrush(Colors.Gray);
                fila2_letra2.Text = Guess[1] + "";
            }


            //COMPROBACION TERCERA LETRA
            if (Guess[2].Equals(SecretWord[2]))
            {
                fila2_letra3.Background = new SolidColorBrush(Colors.Green);
                fila2_letra3.Text = Guess[2] + "";
            }
            else if (Guess[2].Equals(SecretWord[0]) || Guess[2].Equals(SecretWord[1]) || Guess[2].Equals(SecretWord[3]) || Guess[2].Equals(SecretWord[4]))
            {
                fila2_letra3.Background = new SolidColorBrush(Colors.Yellow);
                fila2_letra3.Text = Guess[2] + "";

            }
            else
            {
                fila2_letra3.Background = new SolidColorBrush(Colors.Gray);
                fila2_letra3.Text = Guess[2] + "";
            }


            //COMPROBACION CUARTA LETRA
            if (Guess[3].Equals(SecretWord[3]))
            {
                fila2_letra4.Background = new SolidColorBrush(Colors.Green);
                fila2_letra4.Text = Guess[3] + "";
            }
            else if (Guess[3].Equals(SecretWord[0]) || Guess[3].Equals(SecretWord[1]) || Guess[3].Equals(SecretWord[2]) || Guess[3].Equals(SecretWord[4]))
            {
                fila2_letra4.Background = new SolidColorBrush(Colors.Yellow);
                fila2_letra4.Text = Guess[3] + "";

            }
            else
            {
                fila2_letra4.Background = new SolidColorBrush(Colors.Gray);
                fila2_letra4.Text = Guess[3] + "";
            }

            //COMPROBACION QUINTA LETRA

            if (Guess[4].Equals(SecretWord[4]))
            {
                fila2_letra5.Background = new SolidColorBrush(Colors.Green);
                fila2_letra5.Text = Guess[4] + "";
            }
            else if (Guess[4].Equals(SecretWord[0]) || Guess[4].Equals(SecretWord[1]) || Guess[4].Equals(SecretWord[2]) || Guess[4].Equals(SecretWord[3]))
            {
                fila2_letra5.Background = new SolidColorBrush(Colors.Yellow);
                fila2_letra5.Text = Guess[4] + "";

            }
            else
            {
                fila2_letra5.Background = new SolidColorBrush(Colors.Gray);
                fila2_letra5.Text = Guess[4] + "";
            }



        }

        private void CheckFirstRow()
        {

            char[] Guess = cajaTexto.Text.ToCharArray();
            String intento = cajaTexto.Text.ToString();
            cajaTexto.Text = "";
           

            if (Guess[0].Equals(SecretWord[0])&& Guess[1].Equals(SecretWord[1]) && Guess[2].Equals(SecretWord[2]) && Guess[3].Equals(SecretWord[3])&& Guess[4].Equals(SecretWord[4]))
            {
                debug.Content = "MICHAEL";
                Win = true;
                System.Windows.MessageBox.Show("¡Felicidades, has ganado el juego!", "Victoria",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                debug.Content = "MICHAEL ELSE";
            }


            //TODO: Conprobar letras

            //COMPROBACION PRIMERA LETRA
            if (Guess[0].Equals(SecretWord[0]))
            {
                fila1_letra1.Background = new SolidColorBrush(Colors.Green);
                fila1_letra1.Text = Guess[0] + "";
            }
            else if (Guess[0].Equals(SecretWord[1]) || Guess[0].Equals(SecretWord[2]) || Guess[0].Equals(SecretWord[3]) || Guess[0].Equals(SecretWord[4]))
            {
                fila1_letra1.Background = new SolidColorBrush(Colors.Yellow);
                fila1_letra1.Text = Guess[0] + "";

            }
            else
            {
                fila1_letra1.Background = new SolidColorBrush(Colors.Gray);
                fila1_letra1.Text = Guess[0] + "";
            }


            //COMPROBACION SEGUNDA LETRA

            if (Guess[1].Equals(SecretWord[1]))
            {
                fila1_letra2.Background = new SolidColorBrush(Colors.Green);
                fila1_letra2.Text = Guess[1] + "";
            }
            else if (Guess[1].Equals(SecretWord[0]) || Guess[1].Equals(SecretWord[2]) || Guess[1].Equals(SecretWord[3]) || Guess[1].Equals(SecretWord[4]))
            {
                fila1_letra2.Background = new SolidColorBrush(Colors.Yellow);
                fila1_letra2.Text = Guess[1] + "";

            }
            else
            {
                fila1_letra2.Background = new SolidColorBrush(Colors.Gray);
                fila1_letra2.Text = Guess[1] + "";
            }


            //COMPROBACION TERCERA LETRA
            if (Guess[2].Equals(SecretWord[2]))
            {
                fila1_letra3.Background = new SolidColorBrush(Colors.Green);
                fila1_letra3.Text = Guess[2] + "";
            }
            else if (Guess[2].Equals(SecretWord[0]) || Guess[2].Equals(SecretWord[1]) || Guess[2].Equals(SecretWord[3]) || Guess[2].Equals(SecretWord[4]))
            {
                fila1_letra3.Background = new SolidColorBrush(Colors.Yellow);
                fila1_letra3.Text = Guess[2] + "";

            }
            else
            {
                fila1_letra3.Background = new SolidColorBrush(Colors.Gray);
                fila1_letra3.Text = Guess[2] + "";
            }


            //COMPROBACION CUARTA LETRA
            if (Guess[3].Equals(SecretWord[3]))

            {
              
                fila1_letra4.Background = new SolidColorBrush(Colors.Green);
                fila1_letra4.Text = Guess[3] + "";
            }
            else if (Guess[3].Equals(SecretWord[0]) || Guess[3].Equals(SecretWord[1]) || Guess[3].Equals(SecretWord[2]) || Guess[3].Equals(SecretWord[4]))
            {
                fila1_letra4.Background = new SolidColorBrush(Colors.Yellow);
                fila1_letra4.Text = Guess[3] + "";

            }
            else
            {
                fila1_letra4.Background = new SolidColorBrush(Colors.Gray);
                fila1_letra4.Text = Guess[3] + "";
            }

            //COMPROBACION QUINTA LETRA

            if (Guess[4].Equals(SecretWord[4]))

            {
              
                fila1_letra5.Background = new SolidColorBrush(Colors.Green);
                fila1_letra5.Text = Guess[4] + "";
             
            }
            else if (Guess[4].Equals(SecretWord[0]) || Guess[4].Equals(SecretWord[1]) || Guess[4].Equals(SecretWord[2]) || Guess[4].Equals(SecretWord[3]))
            {
                fila1_letra5.Background = new SolidColorBrush(Colors.Yellow);
                fila1_letra5.Text = Guess[4] + "";

              
            }
            else
            {
                fila1_letra5.Background = new SolidColorBrush(Colors.Gray);
                fila1_letra5.Text = Guess[4] + "";
            }
        }

        private void cajaTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Do nothing.
        }

       
    }
}
