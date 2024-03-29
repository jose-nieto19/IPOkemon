﻿using System;
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
    public sealed partial class ElegirPokemon1Jug : Page
    {
        public string pokemonJ1;
        public string pokemonJ2;
        public ElegirPokemon1Jug()
        {
            this.InitializeComponent();
        }
        private void btnPorygon_Click(object sender, RoutedEventArgs e)
        {
            pokemonJ1 = "Porygon2";
            pokemonJ2 = "Charmander";
            Frame.Navigate(typeof(Combate1Jug), this);
        }

       
        private void btnCharmander_Click(object sender, RoutedEventArgs e)
        {
            
            pokemonJ1 = "Charmander";
            pokemonJ2 = "Porygon2";
            Frame.Navigate(typeof(Combate1Jug), this);
        }
    }
    
}