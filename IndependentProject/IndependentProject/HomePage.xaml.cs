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
using IndependentProject.ViewModels;
using IndependentProject.Models;
using System.Threading.Tasks;
using System.Net.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        string userpass = MainPage.username + MainPage.password;
        public HomePageViewModel ViewModel { get; set; } = new HomePageViewModel();

        public HomePage()
        {
            this.InitializeComponent();
            Setup();
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
            ViewModel.temp = conditionsRoot.Current_observation.Temp_f;

            // These checks are to notify the user if their plants are in danger of anything
            if (ViewModel.temp < 32)
            {
                WarningTextBlock.Text = "Warning : There is frost outside";
            }
            if (!ViewModel.Description.Equals("rain") || ViewModel.Description.Equals("thunderstorm"))
            {
                WarningTextBlock.Text = "Warning : May need to water your garden";
            }

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
            WeatherRetriever weatherRetriever = new IndependentProject.WeatherRetriever();
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
            string selectedCityLink = ((RESULT)selectedCity).l;
            await UpdateWeather(selectedCityLink);
        }

        private async void LocationAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            string selectedCityLink = ((RESULT)args.SelectedItem).l;
            await UpdateWeather(selectedCityLink);
        }

        private void LogoutButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        // This method adds plants to the plantlist. It prevents duplicates and also only allows plants.
        private async void AddPlantSearchButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);

            // Check if the plant is already in the user's list
            if (text.Contains(SearchBar.Text))
            {
                ErrorBox.Text = "Entry already exists";
                return;
            }

            // check if the entry is a plant. The code here is ugly. 
            for (int i = 0; i < plants.Length; i++)
            {
                if (plants[i] == (SearchBar.Text))
                {
                    await Windows.Storage.FileIO.WriteTextAsync(storage, text + "\n" + SearchBar.Text);
                    CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
                    return;
                }
            }

            ErrorBox.Text = "Entry is not a viable plant";
        }

        // This method sets the plant list up when the user first logs on
        private async void Setup()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);
            CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
        }

        // Implementation for the remove from plant list button
        private async void RemovePlantSearchButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);

            if (text.Contains(SearchBar.Text))
            {
                text = text.Replace("\n" + SearchBar.Text, "");
                await Windows.Storage.FileIO.WriteTextAsync(storage, text);
            }

            CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
        }

        // Hardcoded list of plants that my app supports
        public string[] plants = new string[] {"chamomile","chervil","chicory","chives","cilantro",
            "dill","marjoram","spearmint","tarragon","thyme","artichoke","asparagus","beets",
            "carrot","celeriac","corn","eggplant","fennel","kohlrabi","mushroom","parsnip","potato",
            "pumpkin","rhubarb","rutabaga","apples","avocados","blackberry",
            "blueberry","cherry","cucumber","figs","grapefruit","grape","cantaloupe","tomato",
            "kumquat","lemon","lime","pear","pomegranate","strawberry","tangerine","tomatillo",
            "watermelon","lettuce","sorrel","spinach","sprout"};

        private void PlantAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                AutoSuggestBox autoSuggestBox = (AutoSuggestBox)sender;
                string[] filtered = plants.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
                autoSuggestBox.ItemsSource = filtered;
            }
        }

        // This opens the wikipedia page for the plant
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if(plants.Contains(PlantAutoSuggestBox.Text.ToLower()))
            {
                string content = PlantAutoSuggestBox.Text;
                Uri target = new Uri($"https://en.wikipedia.org/wiki/{content}?action=render");
                PlantView.Navigate(target);
            }
        }
    }
}
