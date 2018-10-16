using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04___Ejercicios_iniciales_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            createButton();
        }

        /// <summary>
        /// Crea el botón en tiempo de ejecución, añadiéndole sus propiedades, etc.
        /// </summary>
        private void createButton()
        {
            //Aquí vamos a crear el botón en tiempo de ejecución
            Button b1 = new Button();

            //Ahora le damos sus propiedades
            b1.Content = "Boton generado por codigo";
            b1.Width = 200;
            b1.Height = 70;
            b1.VerticalAlignment = VerticalAlignment.Center;
            b1.HorizontalAlignment = HorizontalAlignment.Center;
            b1.FontFamily = new FontFamily("Verdana");
            b1.FontSize = 16;
            b1.FontWeight = Windows.UI.Text.FontWeights.Bold;
            b1.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            b1.HorizontalAlignment = HorizontalAlignment.Center;

            //Esto añade un evento al botón
            b1.Click += b1_Click;
            sp_1.Children.Add(b1);
        }
        
        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("Hola Mundo").ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
