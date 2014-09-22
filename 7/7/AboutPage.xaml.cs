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

namespace _7
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            if ((Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Collapsed)
            {
                Information.Foreground = new SolidColorBrush(Colors.DarkGray);
                NameName.Foreground = new SolidColorBrush(Colors.DarkGray);
                Version.Foreground = new SolidColorBrush(Colors.DarkGray);
                Author.Foreground = new SolidColorBrush(Colors.DarkGray);
                Date.Foreground = new SolidColorBrush(Colors.DarkGray);
                Note.Foreground = new SolidColorBrush(Colors.DarkGray);
                NoteText.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }
}