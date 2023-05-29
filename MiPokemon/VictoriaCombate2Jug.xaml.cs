using System;
using System.Collections.Generic;
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
    public sealed partial class VictoriaCombate2Jug : Page
    {
        String pokemon1;
        String pokemon2;
        String ganador;
        Combate2Jug padre;

        public VictoriaCombate2Jug()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            padre = (Combate2Jug)e.Parameter;
            pokemon1 = padre.pokemon1;
            pokemon2 = padre.pokemon2;
            ganador = padre.ganador;
            this.mostrarGanadorCombate(pokemon1, pokemon2, ganador);
        }

        public void mostrarGanadorCombate(string pokemon1, string pokemon2, String ganador)
        {
            if (ganador == "Pokemon1")
            {
                VictoriaJug1.Visibility = Visibility.Visible;
                if (pokemon1 == "Charmander")
                {
                    VicPokemonCharmander.Visibility = Visibility.Visible;
                }
                else
                {
                    VicPokemonPorygon.Visibility = Visibility.Visible;
                }
            }
            else
            {
                VictoriaJug2.Visibility = Visibility.Visible;
                if (pokemon2 == "Charmander")
                {
                    VicPokemonCharmander.Visibility = Visibility.Visible;
                }
                else
                {
                    VicPokemonPorygon.Visibility = Visibility.Visible;
                }
            }
        }
    }
}