using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Notifications;
using Windows.UI;
using System.Drawing;

namespace Hito5
{
    public class Card
    {
        public enum tipo { Guerrero, Hechizos };
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Icon { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Skills { get; set; }
        public string Vida { get; set; }
        public string Damage { get; set; }
        public int Mana { get; set; }
        public tipo Tipo { get; set; }

        public Card() { }
    }
    public class Model
    {
        public static List<Card> Cartas = new List<Card>()
        {
            new Card()
            {
                Id = 0,
                Nombre = "Pedro Antonio",
                Imagen = "Assets\\Card.png",
                Skills = "¡Fua!",
                Icon = "Assets\\Sword.png",
                Descripcion = @"Cuando 'Pedro Antonio' 
                                entra el campo de batalla hace AAAAAAAA",
                Tipo = Card.tipo.Guerrero,
                Vida = "1",
                Damage = "1",
                Mana = 2
            },
            new Card()
            {
                Id = 0,
                Nombre = "Juan Pedro",
                Imagen = "Assets\\Deck.png",
                Skills = "Volar",
                Icon = "Assets\\Sword.png",
                Descripcion = @"Cuando 'Juan Pedro' 
                                entra el campo de batalla hace 1 pto de daño al objetivo",
                Tipo = Card.tipo.Guerrero,
                Vida = "1",
                Damage = "1",
                Mana = 2
            },
            new Card()
            {
                Id = 0,
                Nombre = "Bola de Fuego",
                Imagen = "Assets\\Deck.png",
                Skills = "",
                Icon = "Assets\\Axe.png",
                Descripcion = @"Hace 1 pto de daño al objetivo",
                Tipo = Card.tipo.Hechizos,
                Vida = "",
                Damage = "",
                Mana = 1
            }
        };
    }

    internal class VMCard : Card
    {
        public Image Img;
        public SolidColorBrush firstRectColor;
        public SolidColorBrush secondRectColor;
        public int Quantity;
        public VMCard(Card card)
        {
            Quantity = 0;
            Id = card.Id;
            Nombre = card.Nombre;
            Imagen = card.Imagen;
            Descripcion = card.Descripcion;
            Tipo = card.Tipo;
            Damage = card.Damage;
            Vida = card.Vida;
            Skills = card.Skills;
            Icon = card.Icon;
            Img = new Image();
            Mana = card.Mana;
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + card.Imagen;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 120;
            Img.Height = 200;
            if(Tipo == Card.tipo.Guerrero)
            {
                firstRectColor = new SolidColorBrush(Windows.UI.Colors.Orange);
                secondRectColor = new SolidColorBrush(Windows.UI.Colors.OrangeRed);
            }
            else
            {
                firstRectColor = new SolidColorBrush(Windows.UI.Colors.SteelBlue);
                secondRectColor = firstRectColor;
            }
        }
    }
}
