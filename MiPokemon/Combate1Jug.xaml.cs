using porygon2UC;
using Proyecto1_Charmander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Threading;
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
    public sealed partial class Combate1Jug : Page
    {
        ElegirPokemon1Jug padre;

        private UserControl pokemonIzq = null;
        private UserControl pokemonDer = null;

        public String pokemon1;
        public String pokemon2;
        public String ganador;

        int turno = 1;

        Pokemon_Charmander charmander = new Pokemon_Charmander();
        ucPorygon2 porygon = new ucPorygon2();

        Pokemon_Charmander charmander2 = new Pokemon_Charmander();
        ucPorygon2 porygon2 = new ucPorygon2();

        bool PocionVidaPokemon1 = false;
        bool PocionVidaPokemon2 = false;
        public Combate1Jug()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            padre = (ElegirPokemon1Jug)e.Parameter;
            pokemon1 = padre.pokemonJ1;
            pokemon2 = padre.pokemonJ2;
            this.CargarPokemons(pokemon1, pokemon2);
        }

        public void CargarPokemons(String pokemon1, String pokemon2)
        {
            if (pokemonIzq != null)
            {
                venPokemon1.Children.Clear();
            }
            if (pokemon1 == "Porygon2")
            {
                porygon.verBotones(false);
                porygon.verFondo(false);
                porygon.verNombre(false);
                pokemonIzq = porygon;
                venPokemon1.Children.Add(pokemonIzq);
            }
            else
            {
                charmander.Fondo = false;
                charmander.Nombre = false;
                charmander.MostrarBotones = false;
                pokemonIzq = charmander;
                venPokemon1.Children.Add(pokemonIzq);
            }

            if (pokemonDer != null)
            {
                venPokemon2.Children.Clear();
            }
            if (pokemon2 == "Porygon2")
            {
                porygon2.verBotones(false);
                porygon2.verFondo(false);
                porygon2.verNombre(false);
                pokemonIzq = porygon2;
                pokemonDer = porygon2;
                venPokemon2.Children.Add(pokemonDer);
            }
            else
            {
                charmander2.Fondo = false;
                charmander2.Nombre = false;
                charmander2.MostrarBotones = false;
                pokemonDer = charmander2;
                venPokemon2.Children.Add(pokemonDer);
            }

        }

        private async void AtaquePokemonAsync(object sender, RoutedEventArgs e)
        {
            if (turno == 1)
            {
                if (pokemon1 == "Charmander")
                {
                    charmander.Ataque1_Click(null, new RoutedEventArgs());
                    if (pokemon2 == "Charmander")
                    {
                        charmander2.Defensa_Click(null, new RoutedEventArgs());
                    }
                    else
                    {
                        porygon2.recibirAtaque(null, new RoutedEventArgs());
                    }
                }
                else
                {
                    porygon.psicoataque(null, new RoutedEventArgs());
                    if (pokemon2 == "Charmander")
                    {
                        charmander2.Defensa_Click(null, new RoutedEventArgs());
                    }
                    else
                    {
                        porygon2.recibirAtaque(null, new RoutedEventArgs());
                    }
                }
                comprobarVidaPokemon2();
                turno = 2;
                
                Jugador1.Visibility = Visibility.Collapsed;
                Maquina.Visibility = Visibility.Visible;
                await Task.Delay(5000); // Retraso de 5 segundos
                MovimientoMaquina();
             
            }
            else
            {
                if (pokemon2 == "Charmander")
                {
                    charmander2.Ataque1_Click(null, new RoutedEventArgs());
                    if (pokemon1 == "Charmander")
                    {
                        charmander.Defensa_Click(null, new RoutedEventArgs());
                    }
                    else
                    {
                        porygon.recibirAtaque(null, new RoutedEventArgs());
                    }
                }
                else
                {
                    porygon2.psicoataque(null, new RoutedEventArgs());
                    if (pokemon1 == "Charmander")
                    {
                        charmander.Defensa_Click(null, new RoutedEventArgs());
                    }
                    else
                    {
                        porygon.recibirAtaque(null, new RoutedEventArgs());
                    }
                }
                comprobarVidaPokemon1();
                turno = 1;
                Maquina.Visibility = Visibility.Collapsed;
                Jugador1.Visibility = Visibility.Visible;
            }
        }

        public void MovimientoMaquina()
        {
            if (pokemon2 == "Charmander")
            {
                if (charmander2.Vida >= 0 && charmander2.Vida <= 25 && !PocionVidaPokemon2)
                {
                    PocionVidaPokemon2 = true;
                    CurarPokemon(null, new RoutedEventArgs());
                }
                else if (charmander2.Energy < 25)
                {
                    DarEnergiaPokemon(null, new RoutedEventArgs());
                }
                else
                {
                    AtaquePokemonAsync(null, new RoutedEventArgs());
                }
            }
        }

        public async void comprobarVidaPokemon1()
        {

            if (pokemon1 == "Charmander")
            {
                if (charmander.Vida <= 0)
                {
                    await Task.Delay(2000);
                    ganador = "Pokemon2";
                    Frame.Navigate(typeof(VictoriaCombate), this);
                }
            }
            else
            {
                if (porygon.Vida <= 0)
                {
                    await Task.Delay(2000);
                    ganador = "Pokemon2";
                    Frame.Navigate(typeof(VictoriaCombate), this);
                }
            }

        }

        public async void comprobarVidaPokemon2()
        {

            if (pokemon2 == "Charmander")
            {
                if (charmander2.Vida <= 0)
                {
                    ganador = "Pokemon1";
                    Frame.Navigate(typeof(VictoriaCombate), this);
                }
            }
            else
            {
                if (porygon2.Vida <= 0)
                {
                    ganador = "Pokemon1";
                    Frame.Navigate(typeof(VictoriaCombate), this);
                }
            }

        }

        private async void CurarPokemon(object sender, RoutedEventArgs e)
        {

            if (!PocionVidaPokemon1)
            {
                if (turno == 1)
                {
                    if (pokemon1 == "Charmander")
                    {
                        charmander.CurarPokemon();
                    }
                    else
                    {
                        porygon.CurarPokemon();
                    }
                    PocionVidaPokemon1 = true;
                    turno = 2;
                    Jugador1.Visibility = Visibility.Collapsed;
                    Maquina.Visibility = Visibility.Visible;
                }
                else if (!PocionVidaPokemon2)
                {
                    if (pokemon2 == "Charmander")
                    {
                        charmander2.CurarPokemon();
                    }
                    else
                    {
                        porygon2.CurarPokemon();
                    }
                    PocionVidaPokemon2 = true;
                    turno = 1;
                    Maquina.Visibility = Visibility.Collapsed;
                    Jugador1.Visibility = Visibility.Visible;
                }
                await Task.Delay(5000); // Retraso de 5 segundos
                MovimientoMaquina();
            }

        }

        private async void DarEnergiaPokemon(object sender, RoutedEventArgs e)
        {
            if (turno == 1)
            {
                if (pokemon1 == "Charmander")
                {
                    charmander.DarEnergia();
                }
                else
                {
                    porygon.DarEnergia();
                }
                turno = 2;
                Jugador1.Visibility = Visibility.Collapsed;
                Maquina.Visibility = Visibility.Visible;
            }
            else
            {
                if (pokemon2 == "Charmander")
                {
                    charmander2.DarEnergia();
                }
                else
                {
                    porygon2.DarEnergia();
                }
                turno = 1;
                Maquina.Visibility = Visibility.Collapsed;
                Jugador1.Visibility = Visibility.Visible;
            }
            await Task.Delay(5000); // Retraso de 5 segundos
            MovimientoMaquina();
        }

        
    }
}
