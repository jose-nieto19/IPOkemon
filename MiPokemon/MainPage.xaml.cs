﻿using System;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace MiPokemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;

            ApplicationView.GetForCurrentView().SetPreferredMinSize (new Size(320, 320));
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
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView.IsPaneOpen = true;
                porygon.Visibility = Visibility.Visible;
            }
            else if (Width >= 360)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView.IsPaneOpen = false;
                porygon.Visibility = Visibility.Collapsed;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
                sView.IsPaneOpen = false;
            }

        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (fmMain.BackStack.Any())
            {
                fmMain.GoBack();
                if(fmMain.BackStack.Any() is false) SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
           fmMain.Navigate(typeof(InitialPage));
           if(fmMain.BackStack.Any()) SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {
           fmMain.Navigate(typeof(PokedexPage));
           if (fmMain.BackStack.Any()) SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void btnCombatePokemon_Click(object sender, RoutedEventArgs e)
        {
          fmMain.Navigate(typeof(CombatePage));
          if (fmMain.BackStack.Any()) SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            sView.IsPaneOpen = !sView.IsPaneOpen;
        }
    }
}
