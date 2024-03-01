using KMA_ProgrammingCsharp2024.Models;
using KMA_ProgrammingCsharp2024.Tools.Commands;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMA_ProgrammingCsharp2024.ViewModels
{
    internal class ZodiacSignViewModel : INotifyPropertyChanged
    {
        private ZodiacModel _zodiacModel = new ZodiacModel();

        private RelayCommand _calculateCommand;

        public DateTime BirthDate
        {
            get
            {
                return _zodiacModel.BirthDate;
            }
            set
            {
                _zodiacModel.BirthDate = value;
            }
        }
        public ZodiacModel.WesternZodiacSigns WesternZodiacSign
        {
            get { return _zodiacModel.WesternZodiacSign; }
        }
        public ZodiacModel.ChineseZodiacSigns ChineseZodiacSign
        {
            get { return _zodiacModel.ChineseZodiacSign; }
        }
        public int BirthYears
        {
            get { return _zodiacModel.BirthYears; }
        }
        public RelayCommand CalculateCommand
        {
            get 
            {
                if (_calculateCommand == null)
                    _calculateCommand = new RelayCommand(Calculate);
                return _calculateCommand;
                        
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void Calculate()
        {
            if (!CanExecute())
            {
                MessageBox.Show("Please, enter correct age!");
                return;
            }

            if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day == BirthDate.Day)
                MessageBox.Show("Happy Birth Day!");
            NotifyPropertyChanged("WesternZodiacSign");
            NotifyPropertyChanged("ChineseZodiacSign");
            NotifyPropertyChanged("BirthYears");

        }
        private bool CanExecute()
        {
            return BirthDate.Year >= 2024 - 135 && BirthDate < DateTime.Now;
        }

    }
}
