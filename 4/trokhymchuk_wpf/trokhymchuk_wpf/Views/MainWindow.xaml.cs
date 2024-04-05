using KMA_ProgrammingCsharp2024.Models;
using KMA_ProgrammingCsharp2024.ViewModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProgrammingCsharp2024.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonListViewModel _viewModel;
        private PersonList _personList;
        private static DispatcherTimer _dataUpdateTimer = null;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonListViewModel();
            dgUsers.ItemsSource = _viewModel.Persons;
            dgUsers.LostFocus += refresh;
           // SetupDataUpdateTimer();
        }
        private void SetupDataUpdateTimer()
        {
            _dataUpdateTimer = new DispatcherTimer();
            _dataUpdateTimer.Tick += refresh;
            _dataUpdateTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _dataUpdateTimer.Start();
        }

        private void refresh(object sender, EventArgs e)
        {
            try
            {
                CollectionViewSource.GetDefaultView(dgUsers.ItemsSource).Refresh();
            }
            catch (Exception exception)
            {
            }
        }

    }
}