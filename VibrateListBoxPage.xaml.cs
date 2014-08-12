using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Microsoft.Devices;

namespace PhoneApp6
{
    public partial class VibrateListBoxPage : PhoneApplicationPage
    {
        VibrateController MainVibrateController;
        AppSettings mainSettings;

        public VibrateListBoxPage()
        {
            InitializeComponent();

            mainSettings = new AppSettings();

            // Vibrate Device
            MainVibrateController = VibrateController.Default;

            // Events
            TrillVibrate.Tap += TrillVibrate_Tap;
            TrillVibrateButton.Tap += TrillVibrateButton_Tap;
            SpicatoVibrate.Tap += SpicatoVibrate_Tap;
            SpicatoVibrateButton.Tap += SpicatoVibrateButton_Tap;
            PizzicatoVibrate.Tap += PizzicatoVibrate_Tap;
            PizzicatoVibrateButton.Tap += PizzicatoVibrateButton_Tap;
            StaccatoVibrate.Tap += StaccatoVibrate_Tap;
            StaccatoVibrateButton.Tap += StaccatoVibrateButton_Tap;
            TenutoVibrate.Tap += TenutoVibrate_Tap;
            TenutoVibrateButton.Tap += TenutoVibrateButton_Tap;
            FermataVibrate.Tap += FermataVibrate_Tap;
            FermataVibrateButton.Tap += FermataVibrateButton_Tap;
            SnakeVibrate.Tap += SnakeVibrate_Tap;
            SnakeVibrateButton.Tap += SnakeVibrateButton_Tap;
            ZigZagVibrate.Tap += ZigZagVibrate_Tap;
            ZigZagVibrateButton.Tap += ZigZagVibrateButton_Tap;
            RandomVibrate.Tap += RandomVibrate_Tap;
            RandomVibrateButton.Tap += RandomVibrateButton_Tap;
        }

        void RandomVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Random gen = new Random();
            
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(gen.NextDouble() * 0.3));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(gen.NextDouble() * 0.3));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(gen.NextDouble() * 0.3));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(gen.NextDouble() * 0.3));
        }

        void RandomVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 8);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void ZigZagVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
        }

        void ZigZagVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 7);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void SnakeVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
        }

        void SnakeVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 6);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void FermataVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
            System.Threading.Thread.Sleep(400);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
            System.Threading.Thread.Sleep(400);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
            System.Threading.Thread.Sleep(400);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
        }

        void FermataVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 5);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void TenutoVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
        }

        void TenutoVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 4);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void StaccatoVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
        }

        void StaccatoVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 3);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void PizzicatoVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(300);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
        }

        void PizzicatoVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 2);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void SpicatoVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */

            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(250);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(250);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(250);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
        }

        void SpicatoVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 1);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        private void TrillVibrateButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // user interaction
            /*
            TrillVibrateButton.Margin = new Thickness(20,0,0,0);
            System.Threading.Thread.Sleep(200);
            TrillVibrateButton.Margin = new Thickness(15, 0, 0, 0);
            */
             
            // Present one pattern loop
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(200);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(200);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
            System.Threading.Thread.Sleep(200);
            MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
        }

        private void TrillVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 0);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        private void SelectVibrate_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings Dynamically...In Progress
            //int i;
            mainSettings.AddOrUpdateValue("VibrateListBoxSetting", 0); // change to i

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                SystemTray.Background = new SolidColorBrush(Color.FromArgb(255, 25, 25, 25));
                LayoutRoot.Background = new SolidColorBrush(Color.FromArgb(255, 25, 25, 25));
                Microsoft.Phone.Shell.SystemTray.BackgroundColor = Color.FromArgb(255, 25, 25, 25);
            }
            else
            {
                SystemTray.Background = new SolidColorBrush(Color.FromArgb(255, 209, 209, 209));
                LayoutRoot.Background = new SolidColorBrush(Color.FromArgb(255, 209, 209, 209));
                Microsoft.Phone.Shell.SystemTray.BackgroundColor = Color.FromArgb(255, 209, 209, 209);
            }
            
            // not working
            //TrillVibrateButton.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(new Uri(@"C:/Users/Joseph/Downloads/GitHub/PhoneApp6/PhoneApp6/Media/editedPlay.png"));
        }
    }
}