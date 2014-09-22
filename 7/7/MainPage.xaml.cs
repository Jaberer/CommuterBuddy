using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _7.Resources;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Devices;
using System.Windows.Input;
using System.Text;
using System.Windows.Media;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;

namespace _7
{
    public partial class MainPage : PhoneApplicationPage
    {
        private const double METER_TO_MILE = 0.000621371;

        private double distanceLeft;

        // Class Variables
        // Get Location
        private RouteQuery MyQuery;
        private GeocodeQuery Mygeocodequery;

        // Data
        /**
         * My Location and Destination
         * */
        private GeoCoordinate[] MyCoordinates = new GeoCoordinate[2];

        /**
         * Data for Item Source
         * */
        private List<string> Locations;

        /**
         * Options for selection
         * */
        private String[] distances;

        private UserLocationMarker CSULMarker;

        private bool isCurrentLocationCenter;
        private bool isDestinationSearched;

        private bool isCurrentLocationChanged;

        private bool isTyping;
        private bool isDestinationBoxFirstClick;

        private bool isAlarmActivated;

        private bool isMapFocused;

        private VibrateController MainVibrateController;


        private AppSettings MainSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            MainSettings = new AppSettings();
            MainVibrateController = VibrateController.Default;

            #region Locations
            Locations = new List<string>();
            Locations.Add("19th Ave E & E Republican St");
            Locations.Add("10th Ave E & E Mercer St");
            Locations.Add("1270 6th Ave S, Seattle, WA 98134");
            Locations.Add("12th Ave S & S Atlantic St");
            Locations.Add("12th Ave S & S Jackson St");
            Locations.Add("12th Ave S & S Judkins St");
            Locations.Add("12th Ave S & S Massachusetts St");
            Locations.Add("12th Ave S & S Weller St");
            Locations.Add("13th Ave & E Pike St");
            Locations.Add("14th Ave S & S Hill St");
            Locations.Add("14th Ave S & S Holgate St");
            Locations.Add("14th Ave S & S Massachusetts St");
            Locations.Add("14th Ave S & S Walker St");
            Locations.Add("15th Ave & E Denny Way");
            Locations.Add("15th Ave & E Howell St");
            Locations.Add("15th Ave & E Madison St");
            Locations.Add("15th Ave & E Pine St");
            Locations.Add("15th Ave E & E Harrison St");
            Locations.Add("15th Ave E & E Mercer St");
            Locations.Add("15th Ave E & E Republican St");
            Locations.Add("15th Ave E & E Roy St");
            Locations.Add("15th Ave S & S Stevens St");
            Locations.Add("19th Ave & E Denny Way");
            Locations.Add("19th Ave & E Madison St");
            Locations.Add("19th Ave E & E Denny Way");
            Locations.Add("19th Ave E & E Harrison St");
            Locations.Add("19th Ave E & E John St");
            Locations.Add("19th Ave E & E Mercer St");
            Locations.Add("1st Ave & Bay St");
            Locations.Add("1st Ave & Broad St");
            Locations.Add("1st Ave & Cedar St");
            Locations.Add("1st Ave & Lenora St");
            Locations.Add("1st Ave & Marion St");
            Locations.Add("1st Ave & Union St");
            Locations.Add("1st Ave & Wall St");
            Locations.Add("1st Ave & Yesler Way");
            Locations.Add("1st Ave N & Denny Way");
            Locations.Add("1st Ave N & Mercer S");
            Locations.Add("1st Ave N & Republican St");
            Locations.Add("1st Ave S & S Hanford St");
            Locations.Add("1st Ave S & S Lander St");
            Locations.Add("2 Ave Ext S & S Washington St");
            Locations.Add("201 S Jackson St S5, Seattle, WA 98104");
            Locations.Add("21ST Ave & E James St");
            Locations.Add("23RD Ave & E Cherry St");
            Locations.Add("23RD Ave & E Jefferson St");
            Locations.Add("23RD Ave & E Madison St");
            Locations.Add("23RD Ave & E Marion St");
            Locations.Add("23RD Ave & E Marion St");
            Locations.Add("23RD Ave & E Olive St");
            Locations.Add("23RD Ave & E Pine St");
            Locations.Add("23RD Ave & E Spring St");
            Locations.Add("23RD Ave & E Union St");
            Locations.Add("23RD Ave & E Yesler Way");
            Locations.Add("23RD Ave E & E John St");
            Locations.Add("23RD Ave E & E Thomas St");
            Locations.Add("23RD Ave S & E Yesler Way");
            Locations.Add("23RD Ave S & S Dearborn St");
            Locations.Add("23RD Ave S & S Jackson St");
            Locations.Add("23RD Ave S & S Judkins St");
            Locations.Add("23RD Ave S & S Massachusetts St");
            Locations.Add("23RD Ave S & S Norman St");
            Locations.Add("23RD Ave S & S Plum St");
            Locations.Add("2408 1st Ave, Seattle, WA 98121");
            Locations.Add("24th Ave S & S Norman St");
            Locations.Add("2nd & Jackson");
            Locations.Add("2nd & Pike");
            Locations.Add("2nd Ave & Bell St");
            Locations.Add("2nd Ave & Broad St");
            Locations.Add("2nd Ave & Cedar St");
            Locations.Add("2nd Ave & Cherry St");
            Locations.Add("2nd Ave & James ");
            Locations.Add("2nd Ave & Marion St");
            Locations.Add("2nd Ave & Seneca St");
            Locations.Add("2nd Ave & Stewart St");
            Locations.Add("2nd Ave & Wall St");
            Locations.Add("31ST Ave S & S Dearborn St");
            Locations.Add("31ST Ave S & S King St");
            Locations.Add("31ST Ave S & S Norman St");
            Locations.Add("3rd Ave & Bell St");
            Locations.Add("3rd Ave & Columbia St");
            Locations.Add("3rd Ave & James St");
            Locations.Add("3rd Ave & Madison St");
            Locations.Add("3rd Ave & Marion St");
            Locations.Add("3rd Ave & Pike St");
            Locations.Add("3rd Ave & Seneca St");
            Locations.Add("3rd Ave & Union St");
            Locations.Add("3rd Ave & Vine St");
            Locations.Add("3rd Ave & Virginia St");
            Locations.Add("400 Pine St, Seattle, WA 98101");
            Locations.Add("41 S Jackson St, Seattle, WA 98104");
            Locations.Add("4th & University");
            Locations.Add("4th Ave & Cherry St");
            Locations.Add("4th Ave & Jackson St");
            Locations.Add("4th Ave & James St");
            Locations.Add("4th Ave & Madison St");
            Locations.Add("4th Ave & Seneca St");
            Locations.Add("4th Ave & Stewart St");
            Locations.Add("4th Ave S & Edgar Martinez Dr S");
            Locations.Add("4th Ave S & S Forest St");
            Locations.Add("4th Ave S & S Hanford St");
            Locations.Add("4th Ave S & S Horton St");
            Locations.Add("4th Ave S & S Jackson St");
            Locations.Add("4th Ave S & S Lander St");
            Locations.Add("4th Ave S & S Royal Brougham Way");
            Locations.Add("4th Ave S at Washington St");
            Locations.Add("5th Ave & James St");
            Locations.Add("5th Ave & Seneca St");
            Locations.Add("5th Ave & Spring St");
            Locations.Add("5th Ave N & Broad St");
            Locations.Add("5th Ave N & Denny Way");
            Locations.Add("5th Ave N & Mercer St");
            Locations.Add("5th Ave N & Republican St");
            Locations.Add("5th Ave N & Valley St");
            Locations.Add("5th Ave S & S Jackson St");
            Locations.Add("5th Ave S, Seattle, WA 98104");
            Locations.Add("5th Ave at Jefferson St");
            Locations.Add("5th Ave at Marion St (SB)");
            Locations.Add("6th Ave & Marion St");
            Locations.Add("6th Ave S & S Atlantic St");
            Locations.Add("6th Ave S & S Royal Brougham Way");
            Locations.Add("8th Ave S & S King St");
            Locations.Add("9th Ave & Alder St");
            Locations.Add("9th Ave & Columbia St");
            Locations.Add("9th Ave & James St");
            Locations.Add("9th Ave & Jefferson St");
            Locations.Add("9th Ave & Marion St");
            Locations.Add("9th Ave & Spring St");
            Locations.Add("9th Ave N & John St");
            Locations.Add("9th Ave N & Mercer St");
            Locations.Add("9th Ave, Seattle, WA 98104");
            Locations.Add("Airpt Way S & S Bayview St");
            Locations.Add("Airpt Way S & S College St");
            Locations.Add("Airpt Way S & S Hill St");
            Locations.Add("Airpt Way S & S Holgate St");
            Locations.Add("Airpt Way S & S Horton St");
            Locations.Add("Airpt Way S & S Lander St");
            Locations.Add("Airpt Way S & S Stacy St");
            Locations.Add("Airpt Way S & S Stevens St");
            Locations.Add("Airpt Way S & S Walker St");
            Locations.Add("Aurora Ave N & Denny Way");
            Locations.Add("Aurora Ave N & Prospect St");
            Locations.Add("Beacon Ave S & 15th Ave S");
            Locations.Add("Beacon Ave S & S Bayview St");
            Locations.Add("Beacon Ave S & S Lander St");
            Locations.Add("Bell St & 7th Ave");
            Locations.Add("Bellevue Ave E & Bellevue Pl E");
            Locations.Add("Bellevue Ave E & E Denny Way");
            Locations.Add("Bellevue Ave E & E Republican St");
            Locations.Add("Bellevue Ave E & E Roy St");
            Locations.Add("Bellevue Ave E & E Thomas St");
            Locations.Add("Belmont Ave E & Summit Ave E");
            Locations.Add("Blanchard St & 1st Ave");
            Locations.Add("Blanchard St & 4th Ave");
            Locations.Add("Boren Ave & Columbia St");
            Locations.Add("Boren Ave & E Yesler Way");
            Locations.Add("Boren Ave & James St");
            Locations.Add("Boren Ave & Madison St");
            Locations.Add("Boren Ave & Pike St");
            Locations.Add("Boren Ave & Seneca St");
            Locations.Add("Broad St & 2nd Ave");
            Locations.Add("Broadway & E Columbia St");
            Locations.Add("Broadway & E Denny Way");
            Locations.Add("Broadway & E Pike St");
            Locations.Add("Broadway & E Pine St");
            Locations.Add("Broadway & E Union St");
            Locations.Add("Broadway & Terrace St");
            Locations.Add("Broadway E & E Harrison St");
            Locations.Add("Broadway E & E John St");
            Locations.Add("Broadway E & E Mercer St");
            Locations.Add("Broadway E & E Republican St");
            Locations.Add("Broadway E & E Thomas St");
            Locations.Add("Cedar St & Denny Way");
            Locations.Add("Columbia St & 2nd Ave");
            Locations.Add("Convention Pl & Union St");
            Locations.Add("Convention Place");
            Locations.Add("Denny Way & 1st Ave N");
            Locations.Add("Denny Way & 6th Ave N");
            Locations.Add("Denny Way & Fairview Ave N");
            Locations.Add("Denny Way & Stewart St");
            Locations.Add("Denny Way & Warren Pl");
            Locations.Add("Denny Way & Westlake Ave");
            Locations.Add("Dexter Ave N & Aloha St");
            Locations.Add("Dexter Ave N & Denny Way");
            Locations.Add("Dexter Ave N & Harrison St");
            Locations.Add("Dexter Ave N & Mercer St");
            Locations.Add("E Aloha St & Broadway E");
            Locations.Add("E Cherry St & 24th Ave");
            Locations.Add("E Cherry St & 25th Ave");
            Locations.Add("E Cherry St & 32ND Ave");
            Locations.Add("E Denny Way & E Olive Way");
            Locations.Add("E Jefferson St & 12th Ave");
            Locations.Add("E Jefferson St & 14th Ave");
            Locations.Add("E Jefferson St & 15th Ave");
            Locations.Add("E Jefferson St & 20th Ave");
            Locations.Add("E Jefferson St & 21ST Ave");
            Locations.Add("E Jefferson St & 23RD Ave");
            Locations.Add("E Jefferson St & Broadway");
            Locations.Add("E John St & 12th Ave E");
            Locations.Add("E John St & 15th Ave E");
            Locations.Add("E John St & 23RD Ave E");
            Locations.Add("E Madison St & 12th Ave");
            Locations.Add("E Madison St & 14th Ave");
            Locations.Add("E Madison St & 15th Ave");
            Locations.Add("E Madison St & 15th Ave");
            Locations.Add("E Madison St & 17th Ave");
            Locations.Add("E Madison St & 18th Ave");
            Locations.Add("E Madison St & 19th Ave");
            Locations.Add("E Madison St & 20th Ave");
            Locations.Add("E Madison St & 22ND Ave");
            Locations.Add("E Madison St & 23RD Ave E");
            Locations.Add("E Madison St & Broadway");
            Locations.Add("E Olive Way & Broadway E");
            Locations.Add("E Olive Way & Summit Ave E");
            Locations.Add("E Pine St & 10th Ave");
            Locations.Add("E Pine St & 11th Ave");
            Locations.Add("E Pine St & 12th Ave");
            Locations.Add("E Pine St & 13th Ave");
            Locations.Add("E Pine St & 15th Ave");
            Locations.Add("E Pine St & Bellevue Ave");
            Locations.Add("E Pine St & Belmont Ave");
            Locations.Add("E Pine St & Summit Ave");
            Locations.Add("E Roy St & Broadway E");
            Locations.Add("E Thomas St & 16th Ave E");
            Locations.Add("E Thomas St & 19th Ave E");
            Locations.Add("E Union St & 14th Ave");
            Locations.Add("E Union St & 16th Ave");
            Locations.Add("E Union St & 18th Ave");
            Locations.Add("E Union St & 20th Ave");
            Locations.Add("E Union St & 23RD Ave");
            Locations.Add("E Union St & 25th Ave");
            Locations.Add("E Union St & 26th Ave");
            Locations.Add("E Union St & 27th Ave");
            Locations.Add("E Union St & 29th Ave");
            Locations.Add("E Union St & Martin L King Jr Way");
            Locations.Add("E Yesler Way & 12th Ave S");
            Locations.Add("E Yesler Way & 14th Ave S");
            Locations.Add("E Yesler Way & 16th Ave S");
            Locations.Add("E Yesler Way & 17th Ave");
            Locations.Add("E Yesler Way & 19th Ave");
            Locations.Add("E Yesler Way & 20th Ave S");
            Locations.Add("E Yesler Way & 21ST Ave");
            Locations.Add("E Yesler Way & 22ND Ave S");
            Locations.Add("E Yesler Way & 23RD Ave S");
            Locations.Add("E Yesler Way & 27th Ave S");
            Locations.Add("E Yesler Way & 28th Ave S");
            Locations.Add("E Yesler Way & 30th Ave S");
            Locations.Add("E Yesler Way & 32ND Ave S");
            Locations.Add("E Yesler Way & Broadway");
            Locations.Add("Eastlake Ave E & Aloha St");
            Locations.Add("Eastlake Ave E & Harrison St");
            Locations.Add("Eastlake Ave E & Mercer St");
            Locations.Add("Elliot Ave & Broad St");
            Locations.Add("Elliott Ave w & 4th Ave W");
            Locations.Add("Fairview Ave N & Harrison St");
            Locations.Add("Fairview Ave N & John St");
            Locations.Add("Fairview Ave N & Mercer St");
            Locations.Add("Fairview Ave N & Minor Ave N");
            Locations.Add("Fairview Ave N & Valley St");
            Locations.Add("Fairview Ave N & Yale Ave N");
            Locations.Add("Fairview Ave N, Seattle, WA 98109");
            Locations.Add("Golf Dr S & 14th Ave S");
            Locations.Add("I-90 & Rainier Frwy Station");
            Locations.Add("International District");
            Locations.Add("James St & 8th Ave");
            Locations.Add("Jefferson St & Broadway");
            Locations.Add("LK Dell Ave & 32ND Ave");
            Locations.Add("Lenora St & 4th Ave");
            Locations.Add("Lkview Blvd E & Belmont Ave E");
            Locations.Add("Madison St & 2nd Ave");
            Locations.Add("Madison St & 4th Ave");
            Locations.Add("Madison St & 5th Ave");
            Locations.Add("Madison St & 8th Ave");
            Locations.Add("Madison St & 9th Ave");
            Locations.Add("Madison St & Boren Ave");
            Locations.Add("Madison St & Summit Ave");
            Locations.Add("Marion St & 1st Ave");
            Locations.Add("Marion St & 2nd Ave");
            Locations.Add("Marion St & 4th Ave");
            Locations.Add("Martin L King Jr Way & E Alder St");
            Locations.Add("Martin L King Jr Way & E Cherry St");
            Locations.Add("Martin L King Jr Way & E Marion St");
            Locations.Add("Martin L King Jr Way & E Marion St");
            Locations.Add("Martin L King Jr Way & E Union St");
            Locations.Add("Martin L King Jr Way S & S Dearborn St");
            Locations.Add("Martin L King Jr Way S & S Irving St");
            Locations.Add("Martin L King Jr Way S & S Jackson St");
            Locations.Add("Martin L King Jr Way S & S Judkins St");
            Locations.Add("Martin L King Jr Way S & S Massachusetts St");
            Locations.Add("Olive Way & 4th Ave");
            Locations.Add("Olive Way & 8th Ave");
            Locations.Add("Pike St & 4th Ave");
            Locations.Add("Pike St & 6th Ave");
            Locations.Add("Pike St & Boren Ave");
            Locations.Add("Pike St & Convention Pl");
            Locations.Add("Pine St & 2nd Ave");
            Locations.Add("Pine St & 3rd Ave");
            Locations.Add("Pine St & 4th Ave");
            Locations.Add("Pine St & 5th Ave");
            Locations.Add("Pine St & 9th Ave");
            Locations.Add("Pine St, Seattle, WA 98101");
            Locations.Add("Pioneer Square");
            Locations.Add("Queen Anne Ave N & w Harrison St");
            Locations.Add("Queen Anne Ave N & w John St");
            Locations.Add("Queen Anne Ave N & w Mercer St");
            Locations.Add("Rainier Ave S & S Charles St");
            Locations.Add("Rainier Ave S & S Dearborn St");
            Locations.Add("Rainier Ave S & S Grand St");
            Locations.Add("Rainier Ave S & S Norman St");
            Locations.Add("Rainier Ave S & S Plum St");
            Locations.Add("Rainier Ave S & S State St");
            Locations.Add("Rainier Ave S & S Walker St");
            Locations.Add("S Charles St & Golf Dr S");
            Locations.Add("S Dearborn St & 24th Ave S");
            Locations.Add("S Dearborn St & 26th Ave S");
            Locations.Add("S Dearborn St & 5th Ave S");
            Locations.Add("S Dearborn St & 6th Ave S");
            Locations.Add("S Dearborn St & Corwin Pl S");
            Locations.Add("S Holgate St & Airport Way S");
            Locations.Add("S Jackson St & 12th Ave S");
            Locations.Add("S Jackson St & 20th Ave S");
            Locations.Add("S Jackson St & 22ND Ave S");
            Locations.Add("S Jackson St & 28th Ave S");
            Locations.Add("S Jackson St & 2nd Ave S");
            Locations.Add("S Jackson St & 30th Ave S");
            Locations.Add("S Jackson St & 5th Ave S");
            Locations.Add("S Jackson St & 8th Ave S");
            Locations.Add("S Jackson St & Boren Ave S");
            Locations.Add("S Jackson St & Martin L King Jr Way S");
            Locations.Add("S Jackson St & Maynard Ave S");
            Locations.Add("S Jackson St & Occidental Ave S");
            Locations.Add("S Jackson St & Rainier Ave S");
            Locations.Add("S Lander St & 3rd Ave S");
            Locations.Add("S Lander St & Sodo Busway ACS");
            Locations.Add("S Main St & 3rd Ave S");
            Locations.Add("S Plum St & 25th Ave S");
            Locations.Add("S Washington St & 3rd Ave S");
            Locations.Add("S Washington St & 4th Ave S");
            Locations.Add("Seneca St & 4th Ave");
            Locations.Add("Seneca St & 6th Ave");
            Locations.Add("Seneca St & 8th Ave");
            Locations.Add("Seneca St & 9th Ave");
            Locations.Add("Seneca St & Boylston Ave");
            Locations.Add("Seneca St & Harvard Ave");
            Locations.Add("Seneca St & Summit Ave");
            Locations.Add("Seneca St & Terry Ave");
            Locations.Add("Sodo Busway & S Holgate St");
            Locations.Add("Sodo Busway & S Lander St");
            Locations.Add("Sodo Busway & S Royal Brougham Way");
            Locations.Add("Spring St & 4th Ave");
            Locations.Add("Spring St & 6th Ave");
            Locations.Add("Stewart St & 4th Ave");
            Locations.Add("Stewart St & 7th Ave");
            Locations.Add("Summit Ave E & E Harrison St");
            Locations.Add("Summit Ave E & E Mercer St");
            Locations.Add("Terrace St & 5th Ave");
            Locations.Add("Terry Ave & Spruce St");
            Locations.Add("Union St & 4th Ave");
            Locations.Add("Union St & 6th Ave");
            Locations.Add("University Street");
            Locations.Add("Valley St & Taylor Ave N");
            Locations.Add("Virginia St & 6th Ave");
            Locations.Add("Virginia St & 9th Ave");
            Locations.Add("Wall St & 5th Ave");
            Locations.Add("Western Ave w & Elliott Ave W");
            Locations.Add("Westlake Ave N & Aloha St");
            Locations.Add("Westlake Ave N & Harrison St");
            Locations.Add("Westlake Ave N & Mercer St");
            Locations.Add("Westlake Station");
            Locations.Add("Yesler Way & 5th Ave");
            Locations.Add("Yesler Way & 6th Ave S");
            Locations.Add("Yesler Way & 8th Ave S");
            Locations.Add("Yesler Way & Prefontaine Pl S");
            #endregion
            XAMLAutoCompleteBox.ItemsSource = Locations;

            RingerSlider.ValueChanged += RingerSlider_ValueChanged;
            VibrateSlider.ValueChanged += VibrateSlider_ValueChanged;
            DistanceSettingSlider.ValueChanged += DistanceSettingSlider_ValueChanged;

            isCurrentLocationCenter = false;
            isDestinationSearched = false;
            isCurrentLocationChanged = false;
            isTyping = true;
            isDestinationBoxFirstClick = false;
            isMapFocused = false;

            GetCurrentCoordinates();

            // Map Page Events
            XAMLAutoCompleteBox.Tap += XAMLAutoCompleteBox_Tap;
            XAMLAutoCompleteBox.KeyUp += XAMLAutoCompleteBox_KeyUp;
            //DestinationTextBox.Tap += DestinationTextBox_Tap;
            //DestinationTextBox.TextChanged += DestinationTextBox_TextChanged;
            XAMLMap.Tap += XAMLMap_Tap;
            //XAMLMap.LostFocus += XAMLMap_LostFocus;
            XAMLMap.GotFocus += XAMLMap_GotFocus;
            //this.Tap += MainPage_Tap;
            //MainMediaElement.MediaEnded += MainMediaElement_MediaEnded;
            MainMediaElement.MediaOpened += MainMediaElement_MediaOpened;

            // Setting Page Events
            DistanceSettingSlider.MouseEnter += DistanceSettingSlider_MouseEnter;
            DistanceSettingSlider.MouseLeave += DistanceSettingSlider_MouseLeave;

            /*
            SoundSettingButton.MouseEnter += SoundSettingTextBox_MouseEnter;
            SoundSettingButton.MouseLeave += SoundSettingTextBox_MouseLeave;
            */
            SoundSettingButton.Click += SoundSettingButton_Click;

            VibrateSettingButton.Click += VibrateSettingButton_Click;

            //SoundSettingTextBox.BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);
            XAMLAutoCompleteBox.BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);

            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                SoundSettingButton.BorderBrush = new SolidColorBrush(Colors.White);
            }
            else
            {
                SoundSettingButton.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        void MainMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            //if (isAlarmActivated && (distanceLeft <= Convert.ToDouble(DistanceLeftDistanceTextBlock)) && RingerTextBlockState.Text.Equals("On"))
            {
                MainMediaElement.Play();
            }
            /*
            (new Thread(new ThreadStart(delegate 
                {
                    MainMediaElement.Play();
                } ))).Start();
            */
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var askforReview = (bool)IsolatedStorageSettings.ApplicationSettings["askforreview"];
            if (askforReview)
            {
                //make sure we only ask once! 
                IsolatedStorageSettings.ApplicationSettings["askforreview"] = false;
                var returnvalue = MessageBox.Show("Thank you for using Commuter Buddy!",
                    "Like it? Give us a review!", MessageBoxButton.OKCancel);
                if (returnvalue == MessageBoxResult.OK)
                {
                    var marketplaceReviewTask = new MarketplaceReviewTask();
                    marketplaceReviewTask.Show();
                }
            }

            // Update Settings if changed
            updateSettingsGUI();

            // Stop MediaElement
            //MainMediaElement.Stop();
            MainMediaElement.Source = null;
        }

        private void updateSettingsGUI()
        {
            checkSoundSettings();
            checkVibrateSettings();
        }

        private void checkSoundSettings()
        {
            switch (MainSettings.GetValueOrDefault("SoundListBoxSetting", 0))
            {
                case 0:
                    SoundSettingButton.Content = "alarm 1";
                    break;
                case 1:
                    SoundSettingButton.Content = "alarm 2";
                    break;
                case 2:
                    SoundSettingButton.Content = "Military";
                    break;
                case 3:
                    SoundSettingButton.Content = "Cookoo";
                    break;
                case 4:
                    SoundSettingButton.Content = "Tower Chime";
                    break;
                case 5:
                    SoundSettingButton.Content = "Exluna";
                    break;
                case 6:
                    SoundSettingButton.Content = "Mene";
                    break;
                case 7:
                    SoundSettingButton.Content = "Strings";
                    break;
                case 8:
                    SoundSettingButton.Content = "Smooth";
                    break;
                case 9:
                    SoundSettingButton.Content = "Synth";
                    break;
                case 10:
                    SoundSettingButton.Content = "Synth 2";
                    break;
                case 11:
                    SoundSettingButton.Content = "Victory";
                    break;
                case 12:
                    SoundSettingButton.Content = "Frog";
                    break;
                case 13:
                    SoundSettingButton.Content = "Thunder Roll";
                    break;
            }
        }

        private void checkVibrateSettings()
        {
            switch (MainSettings.GetValueOrDefault("VibrateListBoxSetting", 3))
            {
                case 0:
                    VibrateSettingButton.Content = "Trill";
                    break;
                case 1:
                    VibrateSettingButton.Content = "Spicato";
                    break;
                case 2:
                    VibrateSettingButton.Content = "Pizzicato";
                    break;
                case 3:
                    VibrateSettingButton.Content = "Staccato";
                    break;
                case 4:
                    VibrateSettingButton.Content = "Tenuto";
                    break;
                case 5:
                    VibrateSettingButton.Content = "Fermata";
                    break;
                case 6:
                    VibrateSettingButton.Content = "Snake";
                    break;
                case 7:
                    VibrateSettingButton.Content = "Zig Zag";
                    break;
                case 8:
                    VibrateSettingButton.Content = "Random";
                    break;
            }
        }



        private async void GetCurrentCoordinates()
        {
            // Get the phone's current location.
            Geolocator MyGeolocator = new Geolocator();     // Main object to locate points
            if (MyGeolocator.LocationStatus == PositionStatus.Disabled || MyGeolocator.LocationStatus == PositionStatus.NotInitialized)
            {
                MessageBox.Show("Please enable Location Settings"
                    + "\nCommuter Buddy requires your location to function properly");
                // Location is turned off
                Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:"));
            }

            MyGeolocator.DesiredAccuracyInMeters = 5;
            MyGeolocator.MovementThreshold = 100; // in meters

            Geoposition MyGeoPosition = null;               // My Location
            try
            {
                MyGeoPosition = await MyGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(1));   // gets location
                MyCoordinates[0] = new GeoCoordinate(MyGeoPosition.Coordinate.Latitude, MyGeoPosition.Coordinate.Longitude);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Location is disabled in phone settings or capabilities are not checked.");
            }
            catch (Exception ex)
            {
                // Something else happened while acquiring the location.
                //MessageBox.Show(ex.Message + "\nAn Error Occured at Line 667 in MainPage.xaml.cs");
                MessageBox.Show(ex.Message + "\nPlease enable Location Settings");
                // Good Launcher!
                //Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-location:")); 
            }

            Map CSMap = (Map)FindName("XAMLMap");
            CSMap.Center = MyCoordinates[0];
            CSMap.ZoomLevel = 14;

            CSULMarker = (UserLocationMarker)FindName("XAMLULMarker");
            CSULMarker.GeoCoordinate = MyCoordinates[0]; // works! 29 July 2014
            isCurrentLocationCenter = true;

            MyGeolocator.PositionChanged += MyGeolocator_PositionChanged;
        }

        protected void MyGeolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                if (!MyCoordinates[0].Equals(new GeoCoordinate(args.Position.Coordinate.Latitude, args.Position.Coordinate.Longitude)))
                {
                    MyCoordinates[0] = new GeoCoordinate(args.Position.Coordinate.Latitude, args.Position.Coordinate.Longitude);
                    Map CSMap = (Map)FindName("XAMLMap");
                    CSMap.Center = MyCoordinates[0];
                    CSMap.ZoomLevel = 14;
                }
                else
                {
                    return;
                }

                CSULMarker = (UserLocationMarker)FindName("XAMLULMarker");
                CSULMarker.GeoCoordinate = MyCoordinates[0]; // works! 29 July 2014
                isCurrentLocationCenter = true;

                if (MyCoordinates[1] != null)
                {
                    distanceLeft = MyCoordinates[0].GetDistanceTo(MyCoordinates[1]) * 0.000621371; // distance calculator in meters, converted to miles
                    DistanceLeftDistanceTextBlock.Text = distanceLeft.ToString("0.00");
                    checkAlarm();
                }
            });
        }

        private void checkAlarm()
        {
            if (isAlarmActivated)
            {
                //MainMediaElement.Source = new Uri("/Audio/" + SoundSettingButton.Content + ".mp3", UriKind.Relative);

                //if (distanceLeft <= Convert.ToDouble(DistanceListBox.SelectedItem))
                if (distanceLeft <= DistanceSettingSlider.Value)
                {
                    if (RingerTextBlockState.Text.Equals("On"))
                    {
                        // access settings and make noise
                        MainMediaElement.Source = new Uri("/Audio/" + SoundSettingButton.Content + ".mp3", UriKind.Relative);
                        //Microsoft.Xna.Framework.Audio.SoundEffect test;
                        //MainMediaElement.Play();

                        /*
                        switch (MainSettings.GetValueOrDefault("SoundListBoxSetting", 0))
                        {
                            case 0:
                                alarm1MediaElement.Play();
                                break;
                            case 1:
                                alarm2MediaElement.Play();
                                break;
                            case 2:
                                MilitaryMediaElement.Play();
                                break;
                            case 3:
                                CookooMediaElement.Play();
                                break;
                            case 4:
                                TowerChimeMediaElement.Play();
                                break;
                            case 5:
                                ExlunaMediaElement.Play();
                                break;
                            case 6:
                                MeneMediaElement.Play();
                                break;
                            case 7:
                                StringsMediaElement.Play();
                                break;
                            case 8:
                                SmoothMediaElement.Play();
                                break;
                            case 9:
                                Synth1MediaElement.Play();
                                break;
                            case 10:
                                Synth2MediaElement.Play();
                                break;
                            case 11:
                                VictoryMediaElement.Play();
                                break;
                            case 12:
                                FrogMediaElement.Play();
                                break;
                            case 13:
                                ThunderRollMediaElement.Play();
                                break;
                        }
                         * */
                    }
                    if (VibrateTextBlockState.Text.Equals("On"))
                    {
                        // access settings and vibrate
                        switch (MainSettings.GetValueOrDefault("VibrateListBoxSetting", 3))
                        {
                            case 0:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(200);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(200);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(200);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                break;
                            case 1:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(250);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(250);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(250);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                break;
                            case 2:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.1));
                                break;
                            case 3:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                break;
                            case 4:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.2));
                                break;
                            case 5:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                System.Threading.Thread.Sleep(400);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                System.Threading.Thread.Sleep(400);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                System.Threading.Thread.Sleep(400);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                break;
                            case 6:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                break;
                            case 7:
                                // Present one pattern loop
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.3));
                                System.Threading.Thread.Sleep(300);
                                MainVibrateController.Start(TimeSpan.FromSeconds(0.15));
                                break;
                            case 8:
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
                                break;
                        }
                    }
                }
                isAlarmActivated = false;
            }
        }

        void MainMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (isAlarmActivated)
            {
                //MainMediaElement.Play();

            }

            //BackgroundAudioPlayer.Instance
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDestinationSearched) // quick fix for restarting search
            {
                Mygeocodequery = null;
                MyQuery = null;
                getDestination();
            }
            else
            {
                getDestination(); // produces a route to the destination (pretty quickly)
            }
            isDestinationBoxFirstClick = false;
        }

        private void getDestination()
        {
            Mygeocodequery = new GeocodeQuery();
            //Mygeocodequery.SearchTerm = DestinationTextBox.Text;
            Mygeocodequery.SearchTerm = XAMLAutoCompleteBox.Text;
            Mygeocodequery.GeoCoordinate = MyCoordinates[0];

            Mygeocodequery.QueryCompleted += Mygeocodequery_QueryCompleted;
            Mygeocodequery.QueryAsync();
        }

        void Mygeocodequery_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if (e.Error == null)
            {
                MyQuery = new RouteQuery();
                //MyCoordinates.Add(e.Result[0].GeoCoordinate);
                MyCoordinates[1] = e.Result[0].GeoCoordinate;
                DrawDestinationPushpin();

                distanceLeft = MyCoordinates[0].GetDistanceTo(MyCoordinates[1]) * 0.000621371; // distance calculator in meters, converted to miles
                DistanceLeftDistanceTextBlock.Text = distanceLeft.ToString("0.00");
                /*
                MyQuery.Waypoints = MyCoordinates;
                MyQuery.QueryCompleted += MyQuery_QueryCompleted;
                MyQuery.QueryAsync();
                Mygeocodequery.Dispose();
                 * */
            }
        }

        void MyQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error == null)
            {
                Route MyRoute = e.Result;
                MapRoute MyMapRoute = new MapRoute(MyRoute);
                XAMLMap.AddRoute(MyMapRoute);

                MyQuery.Dispose();
            }
        }

        private void DrawDestinationPushpin()
        {
            DrawMapMarkers();
        }

        private void DrawMapMarkers()
        {
            //XAMLMap.Layers.Clear();

            if (isDestinationSearched)
            {
                XAMLMap.Layers.RemoveAt(1);
            }

            //XAMLMap.Layers.RemoveAt(1);
            MapLayer mapLayer = new MapLayer();

            // Draw marker for current position
            if (MyCoordinates[0] != null)
            {
                DrawDestinationPushpin(MyCoordinates[1], mapLayer);
                //DrawDistanceRadius(MyCoordinates[0], mapLayer);
            }

            XAMLMap.Layers.Add(mapLayer);
            isDestinationSearched = true;
        }

        private void DrawDestinationPushpin(GeoCoordinate coordinate, MapLayer mapLayer)
        {
            //var content = new Grid { Width = 120, Height = 40 };

            // Create a map marker
            Polygon MyPositionPolygon = new Polygon();

            MyPositionPolygon.Points.Add(new Point(0, 0));
            MyPositionPolygon.Points.Add(new Point(0, 25));
            MyPositionPolygon.Points.Add(new Point(25, 0));

            /*
            MyPositionPolygon.Points.Add(new Point(0, 0)); // triangle pointy pointer
            MyPositionPolygon.Points.Add(new Point(120, 0));
            MyPositionPolygon.Points.Add(new Point(120, 40));
            MyPositionPolygon.Points.Add(new Point(30, 40));
            MyPositionPolygon.Points.Add(new Point(30, 10));
            */

            /*
            MyPositionCustomPushpin.Points.Add(new Point(0, 0));
            MyPositionCustomPushpin.Points.Add(new Point(0, -40));
            MyPositionCustomPushpin.Points.Add(new Point(120, -40));
            MyPositionCustomPushpin.Points.Add(new Point(120, -10));
            MyPositionCustomPushpin.Points.Add(new Point(30, -10));
            */
            MyPositionPolygon.Fill = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);

            //MyPositionCustomPushpin.DataContext = "Test Text";
            /*
            var myPosition = new TextBlock
            {
                Text = "My Position",
                Foreground = new SolidColorBrush(Colors.White),
            };
            var viewbox = new Viewbox { Child = myPosition };
            content.Children.Add(MyPositionPolygon);
            content.Children.Add(viewbox);
            */
            // Enable marker to be tapped for location information
            //polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            //polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = MyPositionPolygon;
            //overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            overlay.GeoCoordinate = coordinate;
            overlay.PositionOrigin = new Point(0.0, 1.0);
            mapLayer.Add(overlay);
        }

        private void DrawDistanceRadius(GeoCoordinate coordinate, MapLayer mapLayer)
        {
            double metersPerPixels = (Math.Cos(MyCoordinates[0].Latitude * Math.PI / 180) * 2 * Math.PI * 6378137) / (256 * Math.Pow(2, XAMLMap.ZoomLevel));
            double radius = distanceLeft / metersPerPixels;

            Ellipse DistanceRadius = new Ellipse();
            DistanceRadius.Width = radius * 2;
            DistanceRadius.Height = radius * 2;
            DistanceRadius.Fill = new SolidColorBrush(Color.FromArgb(75, 50, 140, 150));
            DistanceRadius.Stroke = new SolidColorBrush(Colors.Black);
            DistanceRadius.StrokeThickness = 3;
            DistanceRadius.Opacity = 100;

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = DistanceRadius;
            //overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            overlay.GeoCoordinate = coordinate;
            overlay.PositionOrigin = new Point(0.0, 1.0);
            mapLayer.Add(overlay);
        }

        private void XAMLMap_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*
            if (!isMapFocused)
            {
                XAMLMap.Height = 525;
                XAMLMap.Margin = new Thickness(0, -130, 0, 0);
                isMapFocused = true;
            }
            */
            XAMLMap.Focus();
            MyCoordinates[1] = XAMLMap.ConvertViewportPointToGeoCoordinate(e.GetPosition(XAMLMap));
            DrawMapMarkers();

            distanceLeft = MyCoordinates[0].GetDistanceTo(MyCoordinates[1]) * 0.000621371; // distance calculator in meters, converted to miles
            DistanceLeftDistanceTextBlock.Text = distanceLeft.ToString("0.00");

            ReverseGeocodeQuery query = new ReverseGeocodeQuery()
            {
                GeoCoordinate = MyCoordinates[1]
            };
            query.QueryCompleted += query_QueryCompleted;
            query.QueryAsync();
        }

        private void XAMLMap_LostFocus(object sender, RoutedEventArgs e)
        {
            XAMLMap.Height = 325;
            XAMLMap.Margin = new Thickness(-13, -117, -13, 0);
        }

        void XAMLMap_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!isMapFocused)
            {
                XAMLMap.Height = 520;
                XAMLMap.Margin = new Thickness(0, -130, 0, 0);
                isMapFocused = true;
                XAMLAutoCompleteBox.Margin = new Thickness(-13, -117, -13, 0);
                XAMLAutoCompleteBox.Visibility = Visibility.Visible;
            }
        }

        void query_QueryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in e.Result)
            {
                sb.Append(item.Information.Name + " ");
                sb.Append(item.Information.Address.HouseNumber + " ");
                sb.Append(item.Information.Address.Street + " ");
                sb.Append(item.Information.Address.City + " ");
                //sb.Append(item.Information.Address.State + " ");
                //sb.Append(item.Information.Address.PostalCode + " ");
            }
            //MessageBox.Show(sb.ToString());
            //DestinationTextBox.Text = sb.ToString();
            XAMLAutoCompleteBox.Text = sb.ToString();
        }

        void XAMLAutoCompleteBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButton_Click(null, null);
                //this.Focus();
                XAMLMap.Focus();
            }
        }

        private void XAMLAutoCompleteBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*
            if (isMapFocused)
            {
                XAMLMap.Height = 325;
                XAMLMap.Margin = new Thickness(-13, -117, -13, 0);
                isMapFocused = false;
            }
            */
            /*
            if (!isDestinationBoxFirstClick)
            {
                //(e.OriginalSource as TextBox).SelectAll();
                var autoBox = (AutoCompleteBox)sender;
                
                isDestinationBoxFirstClick = true;
            }
             * */
            /*
             *  GOOD VERSION PUT THIS BACK EVENTUALLY FOR V1.0.0.1
            if (!isDestinationBoxFirstClick)
            {
                XAMLMap.Focus();
                XAMLAutoCompleteBox.Text = "";
                isDestinationBoxFirstClick = true;
                XAMLAutoCompleteBox.Focus();
            } 
             * */
            this.Focus();
        }

        private void MainPage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (isMapFocused)
            {
                XAMLMap.Height = 325;
                XAMLMap.Margin = new Thickness(-13, -117, -13, 0);
                isMapFocused = false;
            }
        }

        private void StartAlarmButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyCoordinates[1] == null)
            {
                return;
            }
            isAlarmActivated = true;
            checkAlarm();
            DistanceLeftDistanceTextBlock.Foreground = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);
            StartAlarmButton.Visibility = Visibility.Collapsed;
            CancelButton.Visibility = Visibility.Visible;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (isMapFocused)
            {
                XAMLMap.Height = 325;
                XAMLMap.Margin = new Thickness(-13, -117, -13, 0);
                isMapFocused = false;
            }
             * */
            isAlarmActivated = false;
            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                DistanceLeftDistanceTextBlock.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                DistanceLeftDistanceTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (MainVibrateController != null)
            {
                MainVibrateController.Stop();
            }
            MainMediaElement.Stop();
            CancelButton.Visibility = Visibility.Collapsed;
            StartAlarmButton.Visibility = Visibility.Visible;
        }

        private void RingerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RingerSlider.Value = Math.Round(RingerSlider.Value, 0);
            if (RingerSlider.Value == 1)
            {
                RingerTextBlockState.Text = "On";
                return;
            }
            RingerTextBlockState.Text = "Off";
        }

        private void VibrateSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VibrateSlider.Value = Math.Round(VibrateSlider.Value, 0);
            if (VibrateSlider.Value == 1)
            {
                VibrateTextBlockState.Text = "On";
                return;
            }
            VibrateTextBlockState.Text = "Off";
        }

        private void DistanceSettingSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Snap to 0.5, 1, 1.5, and 2 when value is within 0.05
            /*
            if ((DistanceSettingSlider.Value <= 0.55 && DistanceSettingSlider.Value >= 0.45)
                || (DistanceSettingSlider.Value <= 1.05 && DistanceSettingSlider.Value >= 0.95)
                || (DistanceSettingSlider.Value <= 1.55 && DistanceSettingSlider.Value >= 1.45)
                || (DistanceSettingSlider.Value <= 2.05 && DistanceSettingSlider.Value >= 1.95))
            {*/
            if (DistanceSettingSlider.Value <= 1.0)
            {
                DistanceSettingSlider.Value = Math.Round(DistanceSettingSlider.Value, 1);
            }
            else
            {
                //DistanceSettingSlider.Value = Math.Round(DistanceSettingSlider.Value, 0);
            }

            DistanceSettingLabelTextBlock.Text = DistanceSettingSlider.Value.ToString("0.00");
        }

        private void DistanceSettingSlider_MouseEnter(object sender, MouseEventArgs e)
        {
            DistanceSettingLabelTextBlock.Foreground = new SolidColorBrush((Color)Application.Current.Resources["PhoneAccentColor"]);
        }

        private void DistanceSettingSlider_MouseLeave(object sender, MouseEventArgs e)
        {
            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
            {
                DistanceSettingLabelTextBlock.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                DistanceSettingLabelTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void VibrateSettingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/VibrateListBoxPage.xaml", UriKind.Relative));
        }

        private void SoundSettingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SoundsListBoxPage.xaml", UriKind.Relative));
        }

        // Application Bar Controls
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();
            // Create a new button and set the text value to the localized string from AppResources.

            ApplicationBarIconButton SearchIcon = new ApplicationBarIconButton(
                    new Uri("/ApplicationBarImages/light.feature.search.png", UriKind.Relative));
            SearchIcon.Text = "search";
            ApplicationBar.Buttons.Add(SearchIcon);
            SearchIcon.Click += SearchIcon_Click;

            ApplicationBarIconButton CenterIcon = new ApplicationBarIconButton(
                    new Uri("/ApplicationBarImages/center.png", UriKind.Relative));
            CenterIcon.Text = "me";
            ApplicationBar.Buttons.Add(CenterIcon);
            CenterIcon.Click += CenterIcon_Click;

            ApplicationBarIconButton DestinationIcon = new ApplicationBarIconButton(
                    new Uri("/ApplicationBarImages/pin.png", UriKind.Relative));
            DestinationIcon.Text = "destination";
            ApplicationBar.Buttons.Add(DestinationIcon);
            DestinationIcon.Click += DestinationIcon_Click;

            ApplicationBarIconButton SettingsIcon = new ApplicationBarIconButton(
                    new Uri("/ApplicationBarImages/light.feature.settings.png", UriKind.Relative));
            SettingsIcon.Text = "settings";
            ApplicationBar.Buttons.Add(SettingsIcon);
            SettingsIcon.Click += SettingsIcon_Click;

            // Create a new menu item with the localized string from AppResources.
            /*
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
             * */
            ApplicationBarMenuItem ReviewMenuItem = new ApplicationBarMenuItem();
            ReviewMenuItem.Text = "review";
            ReviewMenuItem.Click += ReviewMenuItem_Click;
            ApplicationBar.MenuItems.Add(ReviewMenuItem);

            /*
            ApplicationBarMenuItem HelpMenuItem = new ApplicationBarMenuItem();
            HelpMenuItem.Text = "help";
            HelpMenuItem.Click += HelpMenuItem_Click;
            ApplicationBar.MenuItems.Add(HelpMenuItem);
            */

            ApplicationBarMenuItem AboutMenuItem = new ApplicationBarMenuItem();
            AboutMenuItem.Text = "about";
            AboutMenuItem.Click += AboutMenuItem_Click;
            ApplicationBar.MenuItems.Add(AboutMenuItem);
        }

        void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private void ReviewMenuItem_Click(object sender, EventArgs e)
        {
            var marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void SearchIcon_Click(object sender, EventArgs e)
        {
            if (PivotControl.SelectedIndex != 0)
            {
                PivotControl.SelectedIndex = 0;
                XAMLAutoCompleteBox.Visibility = System.Windows.Visibility.Visible;
            }
            XAMLMap.Focus();
            if (XAMLAutoCompleteBox.Visibility == System.Windows.Visibility.Collapsed)
            {
                XAMLAutoCompleteBox.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                XAMLAutoCompleteBox.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void CenterIcon_Click(object sender, EventArgs e)
        {
            XAMLMap.Focus();
            if (MyCoordinates[0] != null)
            {
                XAMLMap.Center = MyCoordinates[0];
            }
        }

        private void DestinationIcon_Click(object sender, EventArgs e)
        {
            XAMLMap.Focus();
            if (MyCoordinates[1] != null)
            {
                XAMLMap.Center = MyCoordinates[1];
            }
        }

        private void SettingsIcon_Click(object sender, EventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/Page.xaml?PivotMain.SelectedIndex = 1", UriKind.Relative));
            PivotControl.SelectedIndex = 1;
        }

        // public commands for modification


    }
}