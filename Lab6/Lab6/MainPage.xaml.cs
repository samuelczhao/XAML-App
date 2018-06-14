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
using Windows.UI.Xaml.Navigation;
using Lab6.ViewModels;
using Lab6.Models;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lab6
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel { get; set; } = new MainPageViewModel();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Description = "";
            ViewModel.LocationName = "";
            ViewModel.Temperature = "Loading...";
            ViewModel.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3a/Gray_circles_rotate.gif";

            await UpdateWeather("/q/CA/San_Francisco");
        }

        private async Task UpdateWeather(string cityLink)
        {
            WeatherRetriever weatherRetriever = new WeatherRetriever();
            ConditionsRootObject conditionsRoot = await weatherRetriever.GetConditions(cityLink);

            ViewModel.Description = conditionsRoot.Current_observation.Weather;
            ViewModel.LocationName = conditionsRoot.Current_observation.Display_location.Full;
            ViewModel.Temperature = conditionsRoot.Current_observation.Temperature_string;
            ViewModel.ImageUrl = conditionsRoot.Current_observation.Icon_url;

        }

        private async void LocationAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                await SearchForCities(LocationAutoSuggestBox.Text);
            }
        }

        private async Task SearchForCities(string text)
        {
            WeatherRetriever weatherRetriever = new Lab6.WeatherRetriever();
            AutoCompleteRootObject AutoCompleteRoot = await weatherRetriever.GetSuggestions(text);

            LocationAutoSuggestBox.ItemsSource = AutoCompleteRoot.RESULTS;
        }

        private async void LocationAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                await ChangeCity(args.ChosenSuggestion);
            }
            else
            {
                await SearchForCities(args.QueryText);
            }
        }

        private async Task ChangeCity(object selectedCity)
        {
            string selectedCityLink = ((RESULT) selectedCity).l;
            await UpdateWeather(selectedCityLink);
        }

        private async void LocationAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            string selectedCityLink = ((RESULT)args.SelectedItem).l;
            await UpdateWeather(selectedCityLink);
        }
    }
}
