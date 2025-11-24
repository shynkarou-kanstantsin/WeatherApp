using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WeatherApp.ViewModel;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainWindowViewModel();
            DataContext = vm;

            Loaded += async (_, __) => await vm.LoadPinnedCitiesAsync();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (DataContext is MainWindowViewModel vm)
            {
                vm.SavePinnedCities();
            }
        }


        public void MinimizeWindow(object sender, RoutedEventArgs e)
        {
             WindowState = WindowState.Minimized;
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DragMoveWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}