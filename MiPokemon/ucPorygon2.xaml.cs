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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace porygon2UC
{
    public sealed partial class ucPorygon2 : UserControl
    {

        DispatcherTimer dtTimeHealth;
        DispatcherTimer dtTimeEnergy;

        public ucPorygon2()
        {
            this.InitializeComponent();
            Storyboard sb = (Storyboard)this.Resources["sbFlotar"];
            sb.Begin();
        }

        public double Vida
        {
            get { return this.pbHealth.Value; }
            set { this.pbHealth.Value = value; }
        }

        public double Energia
        {
            get { return this.pbEnergy.Value; }
            set { this.pbEnergy.Value = value; }
        }

        public string Nombre
        {
            get { return this.tbName.Text; }
            set { tbName.Text = value; }
        }

        public void verFondo(bool verfondo)
        {
            if (!verfondo) this.imBackground.Source = null;
        }

        public void verBarraVida(bool vervida)
        {
            if (!vervida) this.pbHealth.Visibility = Visibility.Collapsed;
            else this.pbHealth.Visibility = Visibility.Visible;
        }

        public void verBarraEnergia(bool vervida)
        {
            if (!vervida) this.pbEnergy.Visibility = Visibility.Collapsed;
            else this.pbEnergy.Visibility = Visibility.Visible;
        }

        public void verBotones(bool verbotones)
        {
            if (!verbotones)
            {
                this.btnPsicoataque.Visibility = Visibility.Collapsed;
                this.btnRecibirAtaque.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.btnPsicoataque.Visibility = Visibility.Visible;
                this.btnRecibirAtaque.Visibility = Visibility.Visible;
            }
        }

        public void verIconos(bool vericonos)
        {
            if (!vericonos)
            {
                this.imHealth.Visibility = Visibility.Collapsed;
                this.imEnergy.Visibility = Visibility.Collapsed;
                this.imRPotion.Visibility = Visibility.Collapsed;
                this.imYPotion.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.imHealth.Visibility = Visibility.Visible;
                this.imEnergy.Visibility = Visibility.Visible;
                this.imRPotion.Visibility = Visibility.Visible;
                this.imYPotion.Visibility = Visibility.Visible;
            }
        }

        public void verNombre(bool vernombre)
        {
            if (!vernombre) this.tbName.Visibility = Visibility.Collapsed;
            else this.tbName.Visibility = Visibility.Visible;
        }

        public void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            if (pbHealth.Value != 100)
            {
                dtTimeHealth = new DispatcherTimer();
                dtTimeHealth.Interval = TimeSpan.FromMilliseconds(100);
                dtTimeHealth.Tick += increaseHealth;
                if (this.imRPotion.Opacity != 0.5)
                {
                    dtTimeHealth.Start();
                    this.imRPotion.Opacity = 0.5;
                    this.imYPotion.Opacity = 0.5;
                    this.btnPsicoataque.IsEnabled = false;
                    this.btnRecibirAtaque.IsEnabled = false;
                }
            }
        }

        public void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            if (pbEnergy.Value != 100)
            {
                dtTimeEnergy = new DispatcherTimer();
                dtTimeEnergy.Interval = TimeSpan.FromMilliseconds(100);
                dtTimeEnergy.Tick += increaseEnergy;
                if (this.imYPotion.Opacity != 0.5)
                {
                    dtTimeEnergy.Start();
                    this.imRPotion.Opacity = 0.5;
                    this.imYPotion.Opacity = 0.5;
                    this.btnPsicoataque.IsEnabled = false;
                    this.btnRecibirAtaque.IsEnabled = false;
                }
            }
        }

        public void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.5;
            if (pbHealth.Value >= 100)
            {
                cvTiritasPecho.Visibility = Visibility.Collapsed;
                cvVendaCola.Visibility = Visibility.Collapsed;
                cvVendaCuello.Visibility = Visibility.Collapsed;
                imgTiritaCabeza.Visibility = Visibility.Collapsed;
                this.dtTimeHealth.Stop();
                this.imRPotion.Opacity = 1;
                this.imYPotion.Opacity = 1;
                this.btnPsicoataque.IsEnabled = true;
                this.btnRecibirAtaque.IsEnabled = true;
            }
        }

        public void increaseEnergy(object sender, object e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbFlotar"];
            this.pbEnergy.Value += 0.5;
            if (pbEnergy.Value >= 100)
            {
                sudor.Visibility = Visibility.Collapsed;
                this.dtTimeEnergy.Stop();
                this.imRPotion.Opacity = 1;
                this.imYPotion.Opacity = 1;
                this.btnPsicoataque.IsEnabled = true;
                this.btnRecibirAtaque.IsEnabled = true;
                sb.Resume();

            }
        }

        public void hacerCosquillas(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbGuinarOjo"];
            sb.Begin();

        }

        public void psicoataque(object sender, RoutedEventArgs e)
        {
            if (pbEnergy.Value >= 25)
            {
                Storyboard sb = (Storyboard)this.Resources["sbPsicoataque"];
                sb.Begin();
                pbEnergy.Value -= 25;
            }
            else
            {
                sudor.Visibility = Visibility.Visible;
                Storyboard sb2 = (Storyboard)this.Resources["sbCansado"];
                Storyboard sb3 = (Storyboard)this.Resources["sbFlotar"];
                sb2.Begin();
                sb3.Pause();
            }

        }

        public void recibirAtaque(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["sbGuinarOjo"];
            Storyboard sb2 = (Storyboard)this.Resources["sbRecibirAtaque"];
            Storyboard sb3 = (Storyboard)this.Resources["sbFlotar"];
            sb.Begin();
            sb2.Begin();
            if(pbEnergy.Value != 0) sb3.Resume();
            if (pbHealth.Value <= 25)
            {
                pbHealth.Value -= 25;
                this.imRPotion.Opacity = 0.5;
                this.imYPotion.Opacity = 0.5;
                this.btnPsicoataque.IsEnabled = false;
                this.btnRecibirAtaque.IsEnabled = false;
                this.ellipse1.Visibility = Visibility.Collapsed;
                this.ellipse.Visibility = Visibility.Collapsed;
                this.cvMuerto.Visibility = Visibility.Visible;
                sb3.Pause();
            }
            else if (pbHealth.Value <= 50)
            {
                pbHealth.Value -= 25;
                cvTiritasPecho.Visibility = Visibility.Visible;
                cvVendaCola.Visibility = Visibility.Visible;
                cvVendaCuello.Visibility = Visibility.Visible;
                imgTiritaCabeza.Visibility = Visibility.Visible;
            }
            else
            {
                pbHealth.Value -= 25;
            }
        }
    }
}
