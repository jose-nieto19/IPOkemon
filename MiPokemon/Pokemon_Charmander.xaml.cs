using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Proyecto1_Charmander
{
    public sealed partial class Pokemon_Charmander : UserControl
    {
        DispatcherTimer dtTime;
        public Pokemon_Charmander()
        {
            this.InitializeComponent();
            this.Fondo = false;
        }

        private bool verFondo = true;
        private bool verBarraVida = true;
        private bool verBarraEnergia = true;
        private bool verNombre = true;

        public bool BarraEnergia{
            get { return verBarraEnergia = true; }
            set
            {
                this.verBarraEnergia = value;
                if (!verBarraEnergia) this.Grid_Pokemon.RowDefinitions[1].Height = new GridLength(0);
                else this.Grid_Pokemon.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }

        public bool Nombre
        {
            get { return verNombre = true; }
            set
            {
                this.verNombre = value;
                if (!verNombre) this.NombrePokemon.Visibility = Visibility.Collapsed;
                        

            }
        }

        public bool BarraVida
        {
            get { return verBarraVida = true; }
            set
            {
                this.verBarraVida = value;
                if (!verBarraVida) this.Grid_Pokemon.RowDefinitions[0].Height = new GridLength(0);
                else this.Grid_Pokemon.RowDefinitions[0].Height = new GridLength(10,
               GridUnitType.Star);
            }
        }

        public double Vida
        {
            get { return this.pbHealth.Value;}
            set { this.pbHealth.Value= value;}
        }
        public double Energy
        {
            get { return this.pbEnergy.Value; }
            set { this.pbEnergy.Value = value; }
        }
        
        public bool Fondo{
            get { return verFondo = true; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.bosque.Visibility = Visibility.Collapsed;
                else this.bosque.Visibility = Visibility.Visible;
            }

        }
        private bool animacion_superAtaque=false;
        public bool AnimacionSuperAtaque
        {
            get { return animacion_superAtaque = true; }
            set
            {
                this.animacion_superAtaque = value;
                if (animacion_superAtaque) this.SuperAtaque.Begin();
            }
        }

        private bool mostrarBotones = false;
        public bool MostrarBotones
        {
            get { return mostrarBotones = true; }
            set
            {
                this.mostrarBotones = value;
                if (!mostrarBotones) this.Botones.Visibility=Visibility.Collapsed;
            }
        }


        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Opacity = 0.5;
        }
        public void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 2.5;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }

        public void Ataque1_Click(object sender, RoutedEventArgs e)
        {
            if (this.pbEnergy.Value > 0)
            {
                Storyboard ataque = (Storyboard)this.Resources["BolaFuego"];
                ataque.Begin();
                if (this.pbEnergy.Value - 20 >= 0)
                    this.pbEnergy.Value -= 20;
                else
                {
                    this.pbEnergy.Value = 0;
                    ataque.Stop();
                    Storyboard cansado = (Storyboard)this.Resources["Cansado"];
                    cansado.Begin();
                }
            }

        }

        public void usePotionEnergy(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEnergy;
            dtTime.Start();
            this.imP_energia.Opacity = 0.5;
        }
        public void increaseEnergy(object sender, object e)
        {
            this.pbEnergy.Value += 2.5;
            if (pbEnergy.Value >= 100)
            {
                this.dtTime.Stop();
                this.imP_energia.Opacity = 1;
                Storyboard energico = (Storyboard)this.Resources["Energia"];
                energico.Begin();
            }
        }

        public void Defensa_Click(object sender, RoutedEventArgs e)
        {
            Storyboard defensa = (Storyboard)this.Resources["Defensa1"];
            defensa.Begin();
        }

        public void SuperAtaqueCharmander(object sender, RoutedEventArgs e)
        {
            if (this.pbEnergy.Value > 50)
            {
                Storyboard superAtaque = (Storyboard)this.Resources["SuperAtaque"];
                superAtaque.Begin();
                this.pbEnergy.Value -= 50;
            }
        }

        public void Charmander_Herido(object sender, RoutedEventArgs e)
        {
            this.pbHealth.Value = 0;
            Storyboard herido = (Storyboard)this.Resources["Heridoo"];
            herido.Begin();
        }
    }
}
