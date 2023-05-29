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
using Windows.UI.ViewManagement;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace MiPokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PokedexPage : Page
    {
        public PokedexPage()
        {
            this.InitializeComponent();
            this.ucporygon.verBarraEnergia(false);
            this.ucporygon.verBarraVida(false);
            this.ucporygon.verBotones(false);
            this.ucporygon.verFondo(false);
            this.ucporygon.verIconos(false);
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += PokedexPage_VisibleBoundsChanged;
        }

        private void PokedexPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var Width = ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 1200)
            {
                imLogo.Visibility = Visibility.Collapsed;
                Charmander.Visibility = Visibility.Visible;
                ucporygon.Visibility = Visibility.Visible;
            }
            else
            {
                imLogo.Visibility = Visibility.Visible;
                Charmander.Visibility = Visibility.Collapsed;
                ucporygon.Visibility = Visibility.Collapsed;
            }

        }

        private void ucporygon_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(PorygonInfo));
        }

        private void Charmander_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(CharmanderInfo));
        }

    }
}
