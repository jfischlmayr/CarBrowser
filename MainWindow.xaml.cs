using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            CurrentCar = Cars[0];

            InitializeComponent();
            DataContext = this;
        }

        private const string BaseUrl = "https://cddataexchange.blob.core.windows.net/data-exchange/Cars/";
        private Car CurrentCarValue;
        public Car CurrentCar
        {
            get { return CurrentCarValue; }
            set
            {
                CurrentCarValue = value;
                PropertyChanged?.Invoke(this, new(nameof(CurrentCar)));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Car> Cars { get; set; } = new()
        {
            new(
                $"{BaseUrl}Car_1_01.png",
                "Ferrari",
                "What a great car from Italy. Only buy it in red, never buy a Ferrari in any other color."
            ),
            new(
                $"{BaseUrl}Car_2_01.png",
                "Police",
                "Epic police car. Looks like taken right out of a classic hollywood move."
            ),
            new(
                $"{BaseUrl}Car_3_01.png",
                "Lambo",
                "Lamborghini sports car. A MUST HAVE for every rapper on earth that wants to be cool."
            )
        };

        private void OnPrevious(object sender, RoutedEventArgs e)
        {
            var currentCarIndex = Cars.IndexOf(CurrentCar);
            if (currentCarIndex > 0)
            {
                CurrentCar = Cars[currentCarIndex - 1];
            }
        }

        private void OnNext(object sender, RoutedEventArgs e)
        {
            var currentCarIndex = Cars.IndexOf(CurrentCar);
            if (currentCarIndex < Cars.Count - 1)
            {
                CurrentCar = Cars[currentCarIndex + 1];
            }
        }

        private void OnEdit(object sender, RoutedEventArgs e)
        {
            var dialog = new EditCarWindow();
            dialog.DataContext = CurrentCar;
            dialog.ShowDialog();
        }
    } 
}
