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
        private List<List<TextBox>> Lista = new List<List<TextBox>>();
        private List<String> wordList = new List<String>();
        private List<string>Intentos= new List<string>();
        public MainWindow()

        {
           
            contador = -1;
            InitializeComponent();
            boton.Content = "Prueba";

            List<TextBox> primera = new List<TextBox> { fila1_letra1, fila1_letra2, fila1_letra3, fila1_letra4, fila1_letra5 };
            List<TextBox> segunda = new List<TextBox> { fila2_letra1, fila2_letra2, fila2_letra3, fila2_letra4, fila2_letra5 };
            List<TextBox> tercera = new List<TextBox> { fila3_letra1, fila3_letra2, fila3_letra3, fila3_letra4, fila3_letra5 };
            List<TextBox> cuarta = new List<TextBox> { fila4_letra1, fila4_letra2, fila4_letra3, fila4_letra4, fila4_letra5 };
            List<TextBox> quinta = new List<TextBox> { fila5_letra1, fila5_letra2, fila5_letra3, fila5_letra4, fila5_letra5 };

            Lista.Add(primera);
            Lista.Add(segunda);
            Lista.Add(tercera);
            Lista.Add(cuarta);
            Lista.Add(quinta);

           
            using (StreamReader reader = new StreamReader(@"..\..\..\WpfProyecto\Words\palabras.txt"))
            {
                String text = reader.ReadToEnd();
                String[] words = text.Split('\n');
                foreach (String word in words)
                {
                    wordList.Add(word);
                }
            }
            
            Random generador = new Random();
            int numeroAleatorio = generador.Next(1, 6);
            SecretWord = wordList[numeroAleatorio];
            char[] SecretWordArray = SecretWord.ToCharArray();

            //debug.Content = SecretWord; //DESCOMENTAR PARA VER SIEMPRE LA RESPUESTA



        }


        private void SendGuess(object sender, RoutedEventArgs e)
        {

            if (contador == 3)
            {
                string filePath = @"..\..\..\WpfProyecto\Words\registro.txt";
                string tries = "";
                for (int y = 0; y < Intentos.Count; y++)
                {
                    tries += Intentos[y].ToString() + " ";
                }
                System.IO.File.AppendAllText(filePath, SecretWord + "{Intentos: " + tries + " : xxx FALLIDA xxx}" + Environment.NewLine);
                ShowLossMessage();
                
               
               
            }
            else
            {
                contador++;

                if (cajaTexto.Text.Length == 5) //Comprobamos que tenga el mismo lenght que la palabra a adivinar.
                {
                    cajaTexto.Text = cajaTexto.Text.ToUpper();


                    CheckRow(contador);

                }
                else
                {
                    
                    contador--;
                  
                }
            }




        }

        private void CheckRow(int NumRow)
        {
            List<TextBox> lista = Lista[NumRow];
            char[] Guess = cajaTexto.Text.ToCharArray();
            String intento = cajaTexto.Text.ToString();
            cajaTexto.Text = "";
            Intentos.Add(intento);
            for (int i = 0; i < 5; i++)
            {
                bool isWin = false;
                for (int j = 0; j < 5; j++)
                {
                    if (!Guess[j].Equals(SecretWord[j]))
                    {
                        isWin = true;
                    }
                }

                if (!isWin)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        lista[x].Background = new SolidColorBrush(Colors.Green);
                        lista[x].Text = Guess[x] + "";
                    }
                    string filePath = @"..\..\..\WpfProyecto\Words\registro.txt";
                    string tries = "";
                    for (int y = 0;y < Intentos.Count; y++)
                    {
                        tries+= Intentos[y].ToString()+" ";
                    }
                    System.IO.File.AppendAllText(filePath, SecretWord+"{Intentos: "+tries+" : +++ ACERTADA +++}" + Environment.NewLine);
                    ShowWinMessage();
                    break;
                }

                int count = 0;
                bool found = false;
                for (int j = 0; j < 5; j++)
                {
                    if (Guess[i].Equals(SecretWord[j]))
                    {
                        count++;
                        if (!found)
                        {
                            found = true;
                            if (i == j)
                            {
                                lista[i].Background = new SolidColorBrush(Colors.Green);
                                lista[i].Text = Guess[i] + "";
                            }
                            else
                            {
                                lista[i].Background = new SolidColorBrush(Colors.Yellow);
                                lista[i].Text = Guess[i] + "";
                            }
                        }
                    }
                }
                if (count == 0)
                {
                    lista[i].Background = new SolidColorBrush(Colors.Gray);
                    lista[i].Text = Guess[i] + "";
                }

            }
        }

        //Metodo para volver a jugar
        private void PlayAgain(object sender, RoutedEventArgs e)
        {
          
            contador = -1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //Seteamos de nuevo los TextBox a blanco y vacios
                    Lista[i][j].Background = new SolidColorBrush(Colors.White);
                    Lista[i][j].Text = "";
                }
            }
            //Asignamos las variables nuevamente.
            cajaTexto.Text = "";
            Random generador = new Random();
            int numeroAleatorio = generador.Next(1, wordList.Count()-1);
            SecretWord = wordList[numeroAleatorio];
            //debug.Content = SecretWord; DESCOMENTAR PARA VER SIEMPRE LA RESPUESTA
        }

        private void ShowWinMessage()
        {
            MessageBoxResult result = MessageBox.Show("Felicidades! Has ganado!\n ¿Quieres jugar de nuevo?", "Victoria", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                PlayAgain(null, null);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void ShowLossMessage()
        {
           
            MessageBoxResult result = MessageBox.Show("Lo siento has Perdido! La palabra era: "+SecretWord+"\n ¿Quieres jugar de nuevo?", "Derrota", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                PlayAgain(null, null);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void cajaTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Do nothing.
        }

        //METODO PARA HACER QUE CUANDO DAS A ENTER DESPUES DE INTRODUCIR LA PALABRA LLAME AL METODO SEND GUESS.
        private void cajaTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                SendGuess(sender,e);
            }
        }
    }


}
