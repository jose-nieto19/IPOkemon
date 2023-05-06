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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace MiPokemon
{
    public sealed partial class ucGolbat : UserControl
    {

        DispatcherTimer dtTime;

        public ucGolbat()
        {
            this.InitializeComponent();
            Storyboard sb = (Storyboard)this.Resources["sbAleteo"];
            sb.Begin();
        }

        public double Vida
        {
            get { return this.pbHealth.Value; }
            set { this.pbHealth.Value = value; }
        }

        public void verBarraVida(bool ver) 
        {
            if (ver) pbHealth.Visibility = Visibility.Visible;
            else pbHealth.Visibility = Visibility.Collapsed;
        }


        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imRPotion.Opacity = 0.5;
        }
        private void increaseHealth(object sender, object e)
        {
            this.pbHealth.Value += 0.2;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.imRPotion.Opacity = 1;
            }
        }

        private void animarOjo(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.pupilaDer.Resources["sbPupilaRojaDKey"];
            sb.Begin();
        }

        private void hacerCosquillas(object sender, PointerRoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard sb = new Storyboard();
            sb.Duration = new Duration(TimeSpan.FromMilliseconds(300));
            sb.Children.Add(da);
            sb.BeginTime = TimeSpan.FromSeconds(0);
            cvBocaCompleta.RenderTransform = (Transform)new ScaleTransform();
            Storyboard.SetTarget(da, cvBocaCompleta.RenderTransform);
            Storyboard.SetTargetProperty(da, "ScaleY");
            da.From = 1;
            da.To = 0.8;
            sb.AutoReverse = true;
            sb.RepeatBehavior = new RepeatBehavior(3);
            sb.Begin();

        }
    }
}
