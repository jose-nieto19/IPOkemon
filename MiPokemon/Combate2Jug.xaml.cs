using porygon2UC;
using Proyecto1_Charmander;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

namespace MiPokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Combate2Jug : Page
    {
        private UserControl pokemonIzq = null;
        private UserControl pokemonDer = null;

        String pokemon1;
        String pokemon2;
        int botonAtaque=1;

        Pokemon_Charmander charmander = new Pokemon_Charmander();
        ucPorygon2 porygon=new ucPorygon2();    

        private bool victoriaJugador1=false;
        private bool victoriaJugador2=false;

        public Combate2Jug()
        {
            this.InitializeComponent();
            CargarPokemons("Charmander","Porygon");
           
        }

        public void CargarPokemons(String pokemon1, String pokemon2)
        {
            if (pokemonIzq != null)
            {
                ventanaIzq.Children.Clear();
            }
            if (pokemon1 == "Porygon")
            {
                porygon.verBotones(false);
                porygon.verFondo(false);
                porygon.verNombre(false);
                pokemonIzq = porygon;
                ventanaIzq.Children.Add(pokemonIzq);
            }
            else
            {
                charmander.Fondo = false;
                charmander.Nombre = false;
                charmander.MostrarBotones = false;
                pokemonIzq = charmander;
                ventanaIzq.Children.Add(pokemonIzq);
            }

            if (pokemonDer != null)
            {
                VentanaDer.Children.Clear();
            }
            if (pokemon2 == "Porygon")
            {
                porygon.verBotones(false);
                porygon.verFondo(false);
                porygon.verNombre(false);
                pokemonIzq = porygon;
                pokemonDer = porygon;
                VentanaDer.Children.Add(pokemonDer);
            }
            else
            {
                charmander.Fondo = false;
                charmander.Nombre = false;
                charmander.MostrarBotones = false;
                pokemonDer = charmander;
                VentanaDer.Children.Add(pokemonDer);
            }

        }

        private void AtaquePokemon(object sender, RoutedEventArgs e)
        {
            if (botonAtaque == 1)
            {
                if (pokemon1 == "Charmander")
                {
                    charmander.Ataque1_Click(null, new RoutedEventArgs());

                }
                else
                {
                    porygon.psicoataque(null, new RoutedEventArgs());
                }
                comprobarVidaPokemon2();
                botonAtaque = 2;
                Jugador1.Visibility= Visibility.Collapsed;
                Jugador2.Visibility = Visibility.Visible;
            }
            else
            {
                if (pokemon2 == "Charmander")
                {
                    charmander.Ataque1_Click(null, new RoutedEventArgs());

                }
                else
                {
                    porygon.psicoataque(null, new RoutedEventArgs());
                }
                comprobarVidaPokemon1();
                botonAtaque = 1;
                Jugador2.Visibility = Visibility.Collapsed;
                Jugador1.Visibility = Visibility.Visible;
            }
        }

        public bool comprobarVidaPokemon1()
        {
            bool vida = true;
            if (pokemon1 == "Charmander")
            {
                if (charmander.Vida <= 0)
                {
                    vida = false;
                }
            }
            else
            {
                if (porygon.Vida <= 0)
                {
                    vida = false;
                }
            }
            return vida;
            }

        public bool comprobarVidaPokemon2()
        {
            bool vida = true;
            if (pokemon2 == "Charmander")
            {
                if (charmander.Vida <= 0)
                {
                    vida = false;
                }
            }
            else
            {
                if (porygon.Vida <= 0)
                {
                    vida = false;
                }
            }
            return vida;
        }

    }
}
