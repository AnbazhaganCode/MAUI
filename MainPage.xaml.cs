using System;
using MauiApp1.Platforms.Android.Resources;
using Microsoft.Maui.Controls;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        List<LanguageItem> languages = new List<LanguageItem>
        {
            new LanguageItem { Name = "English", FlagImage = "flag_one.png" },
            new LanguageItem { Name = "Español", FlagImage = "flag_two.png" },
        };

        public MainPage()
        {
            InitializeComponent();

            DropdownList.ItemsSource = languages;
            SelectedFlagImage.Source = languages[0].FlagImage;
            SelectedLanguageLabel.Text = languages[0].Name.Substring(0, 2);
        }
        private void MySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MySwitch.IsEnabled = !MySwitch.IsEnabled;
        }

        private void ToggleDropdown(object sender, EventArgs e)
        {
            DropdownList.IsVisible = !DropdownList.IsVisible;
            DropdownFrame.IsVisible = !DropdownFrame.IsVisible;
        }

        private void DropdownList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count > 0)
            {
                var selectedLanguage = e.CurrentSelection[0] as LanguageItem;
                if (selectedLanguage != null)
                {
                    SelectedFlagImage.Source = selectedLanguage.FlagImage;
                    SelectedLanguageLabel.Text = selectedLanguage.Name.Substring(0, 2);
                    DropdownList.IsVisible = false;
                    DropdownFrame.IsVisible = false;
                }
            }
        }
    }
}
