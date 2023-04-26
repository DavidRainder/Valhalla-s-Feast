using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<VMCard> manoActual = new ObservableCollection<VMCard>();
        ObservableCollection<VMCard> mesaActual1 = new ObservableCollection<VMCard>();
        ObservableCollection<VMCard> mesaActual2 = new ObservableCollection<VMCard>();

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

        private void DragOverMesaPartida(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }

        private async void DropMesaPartida(object sender, DragEventArgs e)
        {
            var id = await e.DataView.GetTextAsync();
            var number = int.Parse(id);

            VMCard card = manoActual[number];

            if(sender == GridViewTable1 && mesaActual1.Count < 3)
            {
                manoActual.Remove(card);
                mesaActual1.Add(card);

            }
            else if (sender == GridViewTable2 && mesaActual2.Count < 3)
            {
                manoActual.Remove(card);
                mesaActual2.Add(card);
            }

        }

        private void DragManoUsuarioStarting(object sender, DragItemsStartingEventArgs e)
        {
            VMCard Item = e.Items[0] as VMCard;
            string id = Item.Id.ToString();
            e.Data.SetText(id);
            e.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }
    }
}
