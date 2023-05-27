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
    public sealed partial class InitialPage : Page
    {
        public InitialPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            porygon.verBarraEnergia(false);
            porygon.verBarraVida(false);
            porygon.verBotones(false);
            porygon.verFondo(false);
            porygon.verIconos(false);
            porygon.verNombre(false);
        }

        private void MainPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var Width = ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                porygon.Visibility = Visibility.Visible;
                charmander.Visibility = Visibility.Visible;
                imLogo.Visibility = Visibility.Collapsed;
                txtInicio.Visibility = Visibility.Visible;
            }
            else if (Width >= 360)
            {
                porygon.Visibility = Visibility.Collapsed;
                charmander.Visibility = Visibility.Visible;
                imLogo.Visibility = Visibility.Collapsed;
                txtInicio.Visibility = Visibility.Visible;
            }
            else
            {
                porygon.Visibility = Visibility.Collapsed;
                charmander.Visibility = Visibility.Collapsed;
                imLogo.Visibility = Visibility.Visible;
                txtInicio.Visibility = Visibility.Collapsed;

            }
        }
    }
}
