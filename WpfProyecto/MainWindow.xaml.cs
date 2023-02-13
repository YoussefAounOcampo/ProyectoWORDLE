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
    /// Wordle Clone Youssef Aoun Ocampo
    /// </summary>
    public partial class MainWindow : Window
    {
        private int contadorPista = 0;
        private String SecretWord = "";
        private static int contador; //Contador que nos servirá para saber en que intento estamos.
        private List<List<TextBox>> Lista = new List<List<TextBox>>();
        private List<String> wordList = new List<String>();
        private List<string> Intentos = new List<string>();
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
            int numeroAleatorio = generador.Next(1, wordList.Count() - 1);
            SecretWord =wordList[numeroAleatorio];
            char[] SecretWordArray = SecretWord.ToCharArray();



        }

        /// <summary>
        /// Este metodo se encarga de enviar el string introducido en la caja de texto.
        /// Cada vez que se llame se consume un intento. Si se te acaban pierdes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                System.IO.File.AppendAllText(filePath, SecretWord + "{Intentos: " + tries + " }: xxx FALLIDA xxx}" + Environment.NewLine);
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
                    MessageBox.Show("Debes introducir una palabra de 5 letras", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cajaTexto.Text = "";
                    contador--;

                }
            }




        }
        /// <summary>
        /// Se va comprobando por cada List de TextBox cada letra, si coincide en la misma posición se pone en verde
        /// Si coincide pero en otra posicion se pone en amarillo siempre que no se haya excedido los amarillos posibles
        /// dictados por el numero de veces que se repite dicha letra, en caso contrario se pone de color gris
        /// Por ultimo si no coincide la letra con ninguna de la palabra secreta se pone en gris.
        /// Si se adivina la palabra se gana el juego.
        /// </summary>
        /// <param name="NumRow"></param>
        private void CheckRow(int NumRow)
        {
            List<TextBox> lista = Lista[NumRow];
            char[] Guess = cajaTexto.Text.ToCharArray();
            String intento = cajaTexto.Text.ToString();
            cajaTexto.Text = "";
            Intentos.Add(intento);
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                // Verifica si la letra en la posición `i` de la palabra adivinada (`Guess`)
                // es igual a la letra en la misma posición de la palabra secreta (`SecretWord`)
                if (Guess[i].Equals(SecretWord[i]))
                {

                    // Si son iguales, aumenta el contador
                    count++;

                    // Cambia el color del fondo y el texto de la caja de texto correspondiente
                    // a verde para indicar una coincidencia exacta
                    lista[i].Background = new SolidColorBrush(Colors.Green);
                    lista[i].Text = Guess[i] + "";
                }
                else
                {
                    // Si no son iguales, se verifica si la letra adivinada está en la palabra secreta

                    int countInSecretWord = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (Guess[i].Equals(SecretWord[j]))
                        {
                            countInSecretWord++;
                        }
                    }

                    // También se verifica cuántas veces aparece la letra adivinada en la palabra adivinada

                    int countInGuess = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (Guess[j].Equals(Guess[i]))
                        {
                            countInGuess++;
                        }
                    }
                    // Si la letra adivinada aparece más veces en la palabra adivinada que en la palabra secreta,
                    // cambia el color del fondo y el texto de la caja de texto correspondiente a gris
                    // para indicar una falta de coincidencia
                    if (countInGuess <= countInSecretWord)
                    {
                        lista[i].Background = new SolidColorBrush(Colors.Yellow);
                        lista[i].Text = Guess[i] + "";
                    }
                    else
                    {
                        lista[i].Background = new SolidColorBrush(Colors.Gray);
                        lista[i].Text = Guess[i] + "";
                    }
                }
            }
            // Si el contador de coincidencias es igual a 5, es decir, la palabra adivinada es igual a la palabra secreta,
            // guarda los intentos en un archivo de texto y muestra un mensaje de victoria
            if (count == 5)
            {
                string filePath = @"..\..\..\WpfProyecto\Words\registro.txt";
                string tries = "";
                for (int y = 0; y < Intentos.Count; y++)
                {
                    tries += Intentos[y].ToString() + " ";
                }
                System.IO.File.AppendAllText(filePath, SecretWord + "{Intentos: " + tries + " }: +++ ACERTADA +++}" + Environment.NewLine);
                ShowWinMessage();
            }
        }




        /// <summary>
        /// Metodo para volver a jugar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            int numeroAleatorio = generador.Next(1, wordList.Count() - 1);
            SecretWord = wordList[numeroAleatorio];
            debug.Content = "Introduce tu intento";
            contadorPista = 0;
            
        }

        /// <summary>
        /// Metodo para enseñar el mensaje de victoria
        /// </summary>
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

        /// <summary>
        /// Metodo para enseñar el mensaje de derrota.
        /// </summary>
        private void ShowLossMessage()
        {

            MessageBoxResult result = MessageBox.Show("Lo siento has Perdido! La palabra era: " + SecretWord + "\n ¿Quieres jugar de nuevo?", "Derrota", MessageBoxButton.YesNo, MessageBoxImage.Information);
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

        /// <summary>
        /// Metodo que permite llamar al metodo sendGuess al apretar la tecla Enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cajaTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendGuess(sender, e);
            }
        }

        /// <summary>
        /// Metodo que te va ayudando a revelar la palabra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pista(object sender, RoutedEventArgs e)
        {
            contadorPista++;

            if (contadorPista == 15)
            {
                debug.Content = SecretWord[0] + " █ █ █ █";
            }
            if (contadorPista==25)
            {
                debug.Content = SecretWord[0]+ " █ █ " + SecretWord[2] + " █";
            }
            if (contadorPista == 35)
            {
                debug.Content = SecretWord[0] +" "+ SecretWord[1]+ " █ " + SecretWord[3] + " █";
            }
            if (contadorPista == 50)
            {
                debug.Content = SecretWord[0] + " " + SecretWord[1] + " █ " + SecretWord[3] + " "+SecretWord[4];
            }
            if (contadorPista == 65)
            {
                debug.Content = SecretWord;
            }
        }
    }


}
