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
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using System.Windows.Media.Imaging;

namespace PhoneApp6
{
    public partial class SoundsListBoxPage : PhoneApplicationPage
    {
        private AppSettings MainSettings;
        private bool isPlaying;
        private List<Image> PlayButtons;

        public SoundsListBoxPage()
        {
            InitializeComponent();

            MainSettings = new AppSettings();
            isPlaying = false;

            PlayButtons = new List<Image>();

            #region ImageList
            PlayButtons.Add(alarm1PlayButton);
            PlayButtons.Add(alarm2PlayButton);
            PlayButtons.Add(MilitaryPlayButton);
            PlayButtons.Add(CookooPlayButton);
            PlayButtons.Add(TowerChimePlayButton);
            PlayButtons.Add(ExlunaPlayButton);
            PlayButtons.Add(MenePlayButton);
            PlayButtons.Add(StringsPlayButton);
            PlayButtons.Add(SmoothPlayButton);
            PlayButtons.Add(Synth1PlayButton);
            PlayButtons.Add(Synth2PlayButton);
            PlayButtons.Add(VictoryPlayButton);
            PlayButtons.Add(FrogPlayButton);
            PlayButtons.Add(ThunderRollPlayButton);
            #endregion

            #region TapEvents
            alarm1PlayButton.Tap += alarm1PlayButton_Tap;
            alarm1Sound.Tap += alarm1Sound_Tap;
            alarm2PlayButton.Tap += alarm2PlayButton_Tap;
            alarm2Sound.Tap += alarm2Sound_Tap;
            MilitaryPlayButton.Tap += MilitaryPlayButton_Tap;
            MilitarySound.Tap += MilitarySound_Tap;
            CookooPlayButton.Tap += CookooPlayButton_Tap;
            CookooSound.Tap += CookooSound_Tap;
            TowerChimePlayButton.Tap += TowerChimePlayButton_Tap;
            TowerChimeSound.Tap += TowerChimeSound_Tap;
            ExlunaPlayButton.Tap += ExlunaPlayButton_Tap;
            ExlunaSound.Tap += ExlunaSound_Tap;
            MenePlayButton.Tap += MenePlayButton_Tap;
            MeneSound.Tap += MeneSound_Tap;
            StringsPlayButton.Tap += StringsPlayButton_Tap;
            StringsSound.Tap += StringsSound_Tap;
            SmoothPlayButton.Tap += SmoothPlayButton_Tap;
            SmoothSound.Tap += SmoothSound_Tap;
            Synth1PlayButton.Tap += Synth1PlayButton_Tap;
            Synth1Sound.Tap += SynthSound_Tap;
            Synth2PlayButton.Tap += Synth2PlayButton_Tap;
            Synth2Sound.Tap += Synth2Sound_Tap;
            VictoryPlayButton.Tap += VictoryPlayButton_Tap;
            VictorySound.Tap += VictorySound_Tap;
            FrogPlayButton.Tap += FrogPlayButton_Tap;
            FrogSound.Tap += FrogSound_Tap;
            ThunderRollPlayButton.Tap += ThunderRollPlayButton_Tap;
            ThunderRollSound.Tap += ThunderRollSound_Tap;
            #endregion


            MainMediaElement.MediaOpened += MainMediaElement_MediaOpened;
        }

        void MainMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            MainMediaElement.Play();
        }


        void ThunderRollSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 13);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void ThunderRollPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*
            if (!isPlaying)
            {
                isPlaying = true;
                ThunderRollMediaElement.Play();
                isPlaying = false;
                return;
            }
            ThunderRollMediaElement.Stop();
            isPlaying = false;            
             * */
            //ThunderRollMediaElement.Play();
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Thunder Roll.mp3", UriKind.Relative);
                MainMediaElement.Play();
                ThunderRollPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                ThunderRollPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }

            /*
            Stream stream = TitleContainer.OpenStream(@"C:\Users\Joseph\Downloads\GitHub\PhoneApp6\PhoneApp6\Audio\Thunder Roll.mp3");
            SoundEffect test = SoundEffect.FromStream(stream);
            FrameworkDispatcher.Update();
            test.Play();
             * */
        }

        void FrogSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 12);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void FrogPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Frog.mp3", UriKind.Relative);
                MainMediaElement.Play();
                FrogPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                FrogPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void VictorySound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 11);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void VictoryPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Victory.mp3", UriKind.Relative);
                MainMediaElement.Play();
                VictoryPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                VictoryPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void Synth2Sound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 10);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void Synth2PlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Synth 2.mp3", UriKind.Relative);
                MainMediaElement.Play();
                Synth2PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                Synth2PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void SynthSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 9);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void Synth1PlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Synth 1.mp3", UriKind.Relative);
                MainMediaElement.Play();
                Synth1PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                Synth1PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void SmoothSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 8);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void SmoothPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Smooth.mp3", UriKind.Relative);
                MainMediaElement.Play();
                SmoothPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                SmoothPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void StringsSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 7);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void StringsPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Smooth.mp3", UriKind.Relative);
                MainMediaElement.Play();
                SmoothPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                SmoothPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void MeneSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 6);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void MenePlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Mene.mp3", UriKind.Relative);
                MainMediaElement.Play();
                MenePlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                MenePlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void ExlunaSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 5);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void ExlunaPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Exluna.mp3", UriKind.Relative);
                MainMediaElement.Play();
                ExlunaPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                ExlunaPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void TowerChimeSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 4);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void TowerChimePlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Tower Chime.mp3", UriKind.Relative);
                MainMediaElement.Play();
                TowerChimePlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                TowerChimePlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void CookooSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 3);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void CookooPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Cookoo.mp3", UriKind.Relative);
                MainMediaElement.Play();
                CookooPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                CookooPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void MilitarySound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 2);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void MilitaryPlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/Military.mp3", UriKind.Relative);
                MainMediaElement.Play();
                MilitaryPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                MilitaryPlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void alarm2Sound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 1);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void alarm2PlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/alarm 2.mp3", UriKind.Relative);
                MainMediaElement.Play();
                alarm2PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                alarm2PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        void alarm1Sound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Update Settings
            MainSettings.AddOrUpdateValue("SoundListBoxSetting", 0);

            // Navigate to Settings Page
            NavigationService.GoBack();
        }

        void alarm1PlayButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPlaying)
            {
                foreach (Image i in PlayButtons)
                {
                    i.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                }

                MainMediaElement.Source = new Uri("/Audio/alarm 1.mp3", UriKind.Relative);
                MainMediaElement.Play();
                alarm1PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPause.png", UriKind.Relative));
                isPlaying = true;
            }
            else
            {
                alarm1PlayButton.Source = new BitmapImage(new Uri(@"/Media/editedPlay.png", UriKind.Relative));
                MainMediaElement.Stop();
                isPlaying = false;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                SystemTray.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 25, 25, 25));
                LayoutRoot.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 25, 25, 25));
                Microsoft.Phone.Shell.SystemTray.BackgroundColor = System.Windows.Media.Color.FromArgb(255, 25, 25, 25);
            }
            else
            {
                SystemTray.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 209, 209, 209));
                LayoutRoot.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 209, 209, 209));
                Microsoft.Phone.Shell.SystemTray.BackgroundColor = System.Windows.Media.Color.FromArgb(255, 209, 209, 209);
            }
        }
    }
}