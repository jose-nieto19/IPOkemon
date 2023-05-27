using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using Windows.UI.Core;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace MiPokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CombatePage : Page
    {
        public CombatePage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += Comb2Jug_VisibleBoundsChanged;

        }

        private void Comb2Jug_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            var Width = ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if(Width >= 900)
            {
                imLogo.Visibility = Visibility.Collapsed;
                btn1jug.Visibility = Visibility.Visible;
                btn2jug.Visibility = Visibility.Visible;
                txtComb.Visibility = Visibility.Visible;
                RelativePanel.SetAlignRightWithPanel(btn2jug, true);
                RelativePanel.SetAlignTopWithPanel(btn1jug, false);
                RelativePanel.SetAlignBottomWithPanel(btn2jug, false);
            }
            else if(Width >= 360)
            {
                imLogo.Visibility = Visibility.Collapsed;
                btn1jug.Visibility = Visibility.Visible;
                btn2jug.Visibility = Visibility.Visible;
                txtComb.Visibility = Visibility.Visible;
                RelativePanel.SetAlignTopWithPanel(btn1jug, true);
                RelativePanel.SetAlignBottomWithPanel(btn2jug, true);
                RelativePanel.SetAlignRightWithPanel(btn2jug, false);
            }
            else
            {
                imLogo.Visibility = Visibility.Visible;
                btn1jug.Visibility = Visibility.Collapsed;
                btn2jug.Visibility = Visibility.Collapsed;
                txtComb.Visibility = Visibility.Collapsed;
            }

        }

        private void btn2jug_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ElegirPokemon2Jug));
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
    }
}
