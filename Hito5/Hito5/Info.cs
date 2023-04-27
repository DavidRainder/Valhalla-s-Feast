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
    public class Deck
    {
        public int Index { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public List<Card> Cartas = new List<Card>();
        public bool Ready { get; set; }

        public Deck() { }
    }

    internal class VMDeck : Deck
    {
        public int Quantity;
        public VMDeck(Deck deck)
        {
            Quantity = 0;
            Nombre = deck.Nombre;
            Imagen = deck.Imagen;
            Index = deck.Index;
            Cartas = deck.Cartas;
            Ready = deck.Ready;
        }
    }

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
        public int Quantity { get; set; }
        public tipo Tipo { get; set; }
        public int Precio { get; set; }

        public Card() { }
        public Card(Card card) {
            Id = card.Id;
            Nombre = card.Nombre;
            Imagen = card.Imagen;
            Descripcion = card.Descripcion;
            Tipo = card.Tipo;
            Damage = card.Damage;
            Vida = card.Vida;
            Skills = card.Skills;
            Icon = card.Icon;
            Quantity = card.Quantity;
            Precio = card.Precio;
        }
    }
    public class Model
    {
        public static int Dinero = 40000;
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
                Mana = 2,
                Quantity = 0
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
                Mana = 2,
                Quantity = 0
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
                Mana = 1,
                Quantity = 0
            }
        };
        public static List<Card> Cartas_Tienda = new List<Card>()
        {
            new Card()
            {
                Id = 0,
                Nombre = "Antonio José",
                Imagen = "Assets\\Card.png",
                Skills = "Indomable",
                Icon = "Assets\\Sword.png",
                Descripcion = @"Cuando 'Antonio José' 
                                entra el campo de batalla hace AAAAAAAA",
                Tipo = Card.tipo.Guerrero,
                Vida = "3",
                Damage = "1",
                Mana = 1,
                Quantity = 0,
                Precio = 3000
            },
            new Card()
            {
                Id = 0,
                Nombre = "Jose María",
                Imagen = "Assets\\Deck.png",
                Skills = "Doble daño",
                Icon = "Assets\\Sword.png",
                Descripcion = @"Cuando 'Jose María' 
                                entra el campo de batalla hace 1 pto de daño al objetivo",
                Tipo = Card.tipo.Guerrero,
                Vida = "3",
                Damage = "2",
                Mana = 3,
                Quantity = 0,
                Precio = 1500
            },
            new Card()
            {
                Id = 0,
                Nombre = "Escarcha",
                Imagen = "Assets\\Deck.png",
                Skills = "",
                Icon = "Assets\\Axe.png",
                Descripcion = @"Hace 3 pto de daño al objetivo",
                Tipo = Card.tipo.Hechizos,
                Vida = "",
                Damage = "",
                Mana = 2,
                Quantity = 0,
                Precio = 2000
            }
        };

        public static List<Deck> Mazos = new List<Deck>()
        {
            new Deck()
            {
                Nombre = "Mazo 1",
                Imagen = "Assets\\Deck.png",
                Ready = true,
                Cartas = new List<Card>()
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
                        Mana = 2,
                        Quantity = 20
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
                        Mana = 2,
                        Quantity = 20
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
                        Mana = 1,
                        Quantity = 20
                    }
                }
    },
            new Deck()
            {
                Nombre = "Mazo 2",
                Imagen = "Assets\\Card.png"
            },
        };
    }

    internal class VMCard : Card
    {
        public SolidColorBrush firstRectColor;
        public SolidColorBrush secondRectColor;
        public VMCard(Card card)
        {
            Quantity = card.Quantity;
            Id = card.Id;
            Nombre = card.Nombre;
            Imagen = card.Imagen;
            Descripcion = card.Descripcion;
            Tipo = card.Tipo;
            Damage = card.Damage;
            Vida = card.Vida;
            Skills = card.Skills;
            Icon = card.Icon;
            Precio = card.Precio;
            if (Tipo == Card.tipo.Guerrero)
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
