using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lab6.ViewModels
{
    [ImplementPropertyChanged]

    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string LocationName { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ObservableCollection<ForecastDayViewModel> Forecast { get; } = new ObservableCollection<ForecastDayViewModel>();
    }
}
