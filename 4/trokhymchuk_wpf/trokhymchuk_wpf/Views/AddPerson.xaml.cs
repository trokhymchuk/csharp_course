using KMA_ProgrammingCsharp2024.Models;
using KMA_ProgrammingCsharp2024.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KMA_ProgrammingCsharp2024.Views
{

    public partial class AddPerson : Window
    {
        private PersonViewModel _viewModel;

        public AddPerson(Person person)
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonViewModel(person);

        }

    }
}
