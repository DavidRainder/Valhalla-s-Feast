using Hito5.Assets;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Hito5
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Banquete : Page, INotifyPropertyChanged
    {
        int dinero = Model.Dinero;
        Visibility ajustesVisibility;
        public event PropertyChangedEventHandler PropertyChanged;

        List<VMDeck> mazos = new List<VMDeck>();
        VMDeck deckSelected = null;
        public Banquete()
        {
            this.InitializeComponent();
            ajustesVisibility = Visibility.Collapsed;
            int i = 0;
            foreach (Deck deck_ in Model.Mazos)
            {
                deck_.Index = i;
                mazos.Add(new VMDeck(deck_));
                ++i;
            }
        }
        public void ActualizaIU()
        {

        }
        private void Inicio_Page(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Jugar_Page(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Jugar), null, new SuppressNavigationTransitionInfo());
        }

        private void Banquete_Page(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Banquete), null, new SuppressNavigationTransitionInfo());
        }

        private void Tienda_Page(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Tienda), null, new SuppressNavigationTransitionInfo());
        }

        private void EditarMazo_Page(object sender, RoutedEventArgs e)
        {
            if(deckSelected != null)
                Frame.Navigate(typeof(EditarMazo), deckSelected, new SuppressNavigationTransitionInfo());
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

        private void Exit_Game(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        
        private void DeckSelected(object sender, ItemClickEventArgs e)
        {
            deckSelected = e.ClickedItem as VMDeck;
        }
    }
}