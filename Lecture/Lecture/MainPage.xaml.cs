using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lecture
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Book> Books;

        public MainPage()
        {
            this.InitializeComponent();
            Books = BookManager.GetBooks();
        }

        public void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var book = (Book)e.ClickedItem;
            ResultTextBox.Text = "You selected " + book.Title;
        }

        private void AddPictureButton_ItemClick(object sender, RoutedEventArgs e)
        {
            Books.Add(new Book { BookId = 4, Title = "gamma", Author = "d", CoverImage = "Assets/4.jpg" });
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        //}

        //private void HomeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    InnerFrame.Navigate(typeof(Page1));
        //}

        //private void BackButton_Click(object sender, RoutedEventArgs e)
        //{
        //    InnerFrame.GoBack();
        //}

        //private void ForwardButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (InnerFrame.CanGoForward)
        //    {
        //        InnerFrame.GoForward();
        //    }
        //}

        //private void MyCheckBox_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    if (MyCheckBox.IsChecked.Value)
        //    {
        //        CheckBoxResultTextBlock.Text = "Yes";
        //    }
        //    else
        //    {
        //        CheckBoxResultTextBlock.Text = "No";
        //    }
        //}

        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (YesRadioButton.IsChecked.Value)
        //    {
        //        RadioButtonTextBlock.Text = "Yes";
        //    }
        //    else
        //    {
        //        RadioButtonTextBlock.Text = "No";
        //    }
        //}

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (ComboBoxResultTextBox != null)
        //    {
        //        ComboBox combo = (ComboBox)sender;
        //        ComboBoxItem item = (ComboBoxItem)combo.SelectedItem;

        //        ComboBoxResultTextBox.Text = item.Content.ToString();
        //    }
        //}

        //private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string itemsStr = "";

        //    foreach (object item in MyListBox.Items)
        //    {
        //        ListBoxItem listboxitem = (ListBoxItem)item;

        //        if (listboxitem.IsSelected)
        //        {
        //            itemsStr += listboxitem.Content.ToString() + " ";
        //        }

        //        ListBoxResultTextBlock.Text = itemsStr;
        //    }
        //}

        //private void MyToggleButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (MyToggleButton.IsChecked.HasValue)
        //    {
        //        if (MyToggleButton.IsChecked.Value == true)
        //        {
        //            ToggleButtonResultTextBlock.Text = "True";
        //        }
        //        else
        //        {
        //            ToggleButtonResultTextBlock.Text = "False";
        //        }
        //    }
        //    else
        //    {
        //        ToggleButtonResultTextBlock.Text = "Null";
        //    }
        //}

        //private void MyCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        //{
        //    var selectedDates = sender.SelectedDates.Select(p => p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();
        //    var values = string.Join(", ", selectedDates);
        //    CalendarViewResultTextBox.Text = values;
        //}

        //private void InnerFlyoutButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MyFlyout.Hide();
        //}

        //private string[] selectionItems = new String[] { "hi", "hello", "hep", "Hella", "help" };
        //private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        //{
        //    var autoSuggestBox = (AutoSuggestBox)sender;
        //    var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
        //    autoSuggestBox.ItemsSource = filtered;
        //
        //}
    }
}
