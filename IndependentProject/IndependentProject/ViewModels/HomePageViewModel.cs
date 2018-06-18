using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IndependentProject.ViewModels
{
    [ImplementPropertyChanged]
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string LocationName { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double temp { get; set; }
        // I added this in to check if the temp was below freezing. (aka frost point)

    }
}
