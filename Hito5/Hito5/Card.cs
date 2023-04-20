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

namespace Hito5
{
    public class Card
    {
        public enum tipo { Guerrero, Hechizos };
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Skills { get; set; }
        public int Vida { get; set; }
        public int Damage { get; set; }
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
                Skills = "funciona pls",
                Descripcion = @"Cuando 'Pedro Antonio' 
                                entra el campo de batalla hace AAAAAAAA",
                Tipo = Card.tipo.Guerrero,
                Vida = 1,
                Damage = 1,
                Mana = 2
            }
        };
    }

    internal class VMCard : Card
    {
        public Image Img;
        public VMCard(Card card)
        {
            Id = card.Id;
            Nombre = card.Nombre;
            Imagen = card.Imagen;
            Descripcion = card.Descripcion;
            Tipo = card.Tipo;
            Damage = card.Damage;
            Vida = card.Vida;
            Skills = card.Skills;
            Img = new Image();
            Mana = card.Mana;
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + card.Imagen;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            Img.Width = 120;
            Img.Height = 200;
        }
    }
}
