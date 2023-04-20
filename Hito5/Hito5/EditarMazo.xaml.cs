using Hito5.Assets;
using System;
using System.Collections.Generic;
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
    public sealed partial class EditarMazo : Page
    {
        List<VMCard> cartas = new List<VMCard>();
        // Dictionary<int, Dictionary<VMCard, int>> decks = new Dictionary<int, Dictionary<VMCard, int>>();
        Dictionary<VMCard, int> currentDeck = new Dictionary<VMCard, int>();
        int currentDeckIndex = 0;
        public EditarMazo()
        {

            foreach (Card card_ in Model.Cartas)
            {
                cartas.Add(new VMCard(card_));
            }
            this.InitializeComponent();
        }

        private void OnNavigatedTo(NavigationEventArgs e)
        {
            // currentDeck = decks[int.Parse(e.ToString())];
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
            if (!currentDeck.ContainsKey(card_)) {
                card_.Quantity = 1;
                currentDeck.Add(card_, card_.Quantity); 
            }
            else {
                card_.Quantity++;
                currentDeck[card_]++;
            }
            Dictionary<VMCard, int> newMap = new Dictionary<VMCard, int>();
            List<VMCard> newList = new List<VMCard>();
            foreach(KeyValuePair<VMCard, int> card in currentDeck) {
                newList.Add(card.Key);
            }
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
            List<VMCard> newList = new List<VMCard>();
            foreach (KeyValuePair<VMCard, int> card in currentDeck)
            {
                newList.Add(card.Key);
            }
            CurrentDeck.ItemsSource = newList;
        }
    }
}
