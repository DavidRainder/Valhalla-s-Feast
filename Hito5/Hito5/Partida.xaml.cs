using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Hito5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Partida : Page, INotifyPropertyChanged
    {
        Visibility ajustesVisibility;
        public event PropertyChangedEventHandler PropertyChanged;
        VMDeck deck;
        List<VMCard> manoActual = new List<VMCard>();

        public Partida()
        {
            this.InitializeComponent();
            ajustesVisibility = Visibility.Collapsed;
        }

        public void ActualizaIU()
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            deck = e.Parameter as VMDeck;
            Random r = new Random();
            for(int i = 0; i < 7; i++)
            {
                manoActual.Add(new VMCard(deck.Cartas[r.Next(deck.Cartas.Count)]));
            }
        }
        private void Ajustes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Show_Ajustes_Menu(object sender, RoutedEventArgs e)
        {
            ajustesVisibility = Visibility.Visible;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ajustesVisibility)));
        }
        private void Quit_Ajustes_Menu(object sender, RoutedEventArgs e)
        {
            ajustesVisibility = Visibility.Collapsed;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ajustesVisibility)));
        }

    }
}
