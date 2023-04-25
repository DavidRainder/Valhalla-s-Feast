using Hito5.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.PlayTo;
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
    public sealed partial class EditarMazo : Page, INotifyPropertyChanged
    {
        Visibility ajustesVisibility;
        public event PropertyChangedEventHandler PropertyChanged;

        List<VMCard> cartas = new List<VMCard>();
        Dictionary<VMCard, int> currentDeck = new Dictionary<VMCard, int>();
        VMDeck deckSelected = null;
        public EditarMazo()
        {
            this.InitializeComponent();
            ajustesVisibility = Visibility.Collapsed;
            foreach (Card card_ in Model.Cartas)
            {
                cartas.Add(new VMCard(card_));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            deckSelected = e.Parameter as VMDeck;
            foreach (Card card__ in deckSelected.Cartas)
            {
                currentDeck.Add(new VMCard(card__), card__.Quantity);
            }
            List<VMCard> newList = new List<VMCard>();
            foreach (KeyValuePair<VMCard, int> card in currentDeck)
            {
                newList.Add(card.Key);
            }
            CurrentDeck.ItemsSource = newList;
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

        public void AddToDeckList(object sender, ItemClickEventArgs e)
        {
            VMCard card_ = e.ClickedItem as VMCard;
            int i = 0;
            foreach (KeyValuePair<VMCard, int> carta in currentDeck)
            {
                if(carta.Key.Nombre == card_.Nombre)
                {
                    carta.Key.Quantity++;
                    currentDeck[carta.Key]++;
                    break;
                }
                ++i;
            }
            if(i == currentDeck.Count)
            {
                card_.Quantity = 1;
                currentDeck.Add(card_, card_.Quantity);
            }
            List<Card> newList = new List<Card>();
            foreach(KeyValuePair<VMCard, int> card in currentDeck) {
                newList.Add(card.Key);
            }
            deckSelected.Cartas = newList;
            CurrentDeck.ItemsSource = newList;
        }

        private void RemoveCardFromList(object sender, ItemClickEventArgs e)
        {
            VMCard card_ = e.ClickedItem as VMCard;
            card_.Quantity--;
            if (card_.Quantity <= 0)
            {
                currentDeck.Remove(card_);
            }
            else currentDeck[card_]--;
            List<Card> newList = new List<Card>();
            foreach (KeyValuePair<VMCard, int> card in currentDeck)
            {
                newList.Add(card.Key);
            }
            deckSelected.Cartas = newList;
            CurrentDeck.ItemsSource = newList;
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

        private void Save_Deck_Data(object sender, RoutedEventArgs e)
        {
            foreach (Deck deck in Model.Mazos)
            {
                if(deck.Index == deckSelected.Index)
                {
                    Model.Mazos[deck.Index].Cartas = deckSelected.Cartas;
                    break;
                }
            }
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
