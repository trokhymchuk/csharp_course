using KMA_ProgrammingCsharp2024.Models;
using KMA_ProgrammingCsharp2024.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgrammingCsharp2024.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZodiacSignViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new ZodiacSignViewModel();
        }

    }
}