using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Model;
using WeatherApp.Services;

namespace WeatherApp.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CityWeather> _pinnedCities;
        private ObservableCollection<CityWeather> _currentSearchResult = new ObservableCollection<CityWeather>();
        private string _searchQuery;

        private readonly WeatherService _weatherService = new WeatherService();

        public ObservableCollection<CityWeather> PinnedCities
        {
            get => _pinnedCities;
            set
            {
                _pinnedCities = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CityWeather> CurrentSearchResult
        {
            get => _currentSearchResult;
            set
            {
                _currentSearchResult = value;
                OnPropertyChanged();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCityTabCommand { get; }
        public ICommand SearchCityCommand { get; }
        public ICommand PinCityCommand { get; }

        public MainWindowViewModel()
        {
            PinnedCities = new ObservableCollection<CityWeather>();

            DeleteCityTabCommand = new RelayCommand(DeleteCity);
            SearchCityCommand = new RelayCommand(async _ => await SearchCityAsync());
            PinCityCommand = new RelayCommand(_ => PinCity());
        }

        private async Task SearchCityAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery)) return;

            try
            {
                var weather = await _weatherService.GetWeatherAsync(SearchQuery);

                CurrentSearchResult.Clear();
                CurrentSearchResult.Add(weather);
            }
            catch (Exception ex)
            {
                CurrentSearchResult.Clear();
            }
        }

        private void PinCity()
        {
            if (CurrentSearchResult.Any())
            {
                var city = CurrentSearchResult.First();
                if (!PinnedCities.Any(c => c.CityName == city.CityName))
                {
                    PinnedCities.Add(city);
                }
            }
        }

        private void DeleteCity(object param)
        {
            if (param is CityWeather cityWeather && PinnedCities.Contains(cityWeather))
            {
                PinnedCities.Remove(cityWeather);
            }
        }

        private readonly string _storagePath = "pinned.txt";

        public void SavePinnedCities()
        {
            File.WriteAllLines(_storagePath, PinnedCities.Select(c => c.CityName));
        }

        public async Task LoadPinnedCitiesAsync()
        {
            if (File.Exists(_storagePath))
            {
                var cityNames = File.ReadAllLines(_storagePath);
                PinnedCities.Clear();

                foreach (var name in cityNames)
                {
                    try
                    {
                        var weather = await _weatherService.GetWeatherAsync(name);
                        PinnedCities.Add(weather);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"LoadPinnedCitiesAsync error for '{name}': {ex.Message}");
                    }
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
