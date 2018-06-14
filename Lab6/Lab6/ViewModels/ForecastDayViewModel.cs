using PropertyChanged;
using System.ComponentModel;

namespace Lab6.ViewModels
{
    [ImplementPropertyChanged]

    public class ForecastDayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
