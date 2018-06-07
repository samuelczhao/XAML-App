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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IndependentProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        string userpass = MainPage.username + MainPage.password;

        public HomePage()
        {
            this.InitializeComponent();
            Setup();
        }

        private void LogoutButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void AddPlantSearchButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);

            if (!text.Contains(SearchBar.Text))
            {
                await Windows.Storage.FileIO.WriteTextAsync(storage, text + "\n" + SearchBar.Text);
            }

            CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
        }
        private async void Setup()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);
            CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
        }

        // this shit doesnt work rn focus line 68 rip
        private async void RemovePlantSearchButton_ItemClickAsync(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile storage = await storageFolder.GetFileAsync(userpass + ".txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(storage);

            if (text.Contains(SearchBar.Text))
            {
                text = text.Remove(text.IndexOf(SearchBar.Text) - 1, text.IndexOf(SearchBar.Text) + SearchBar.Text.Length - 2);
                await Windows.Storage.FileIO.WriteTextAsync(storage, text);
            }

            CurrentPlantContent.Text = await Windows.Storage.FileIO.ReadTextAsync(storage);
        }
    }
}
