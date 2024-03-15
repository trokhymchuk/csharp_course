using KMA_ProgrammingCsharp2024.Models;
using KMA_ProgrammingCsharp2024.Tools.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KMA_ProgrammingCsharp2024.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private PersonModel _personModel = new PersonModel();

        private GalaSoft.MvvmLight.CommandWpf.RelayCommand _calculateCommand;

        public String Name
        {
            get
            {
                return _personModel.Name;
            }
            set 
            {
                _personModel.Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public String LastName
        {
            get { return _personModel.LastName; }
            set
            {
                _personModel.LastName = value;
            }
        }
        public String Email
        {
            get { return _personModel.Email; }
            set
            {
                _personModel.Email = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return _personModel.DateOfBirth;
            }
            set
            {
                _personModel.DateOfBirth = value;
            }
        }
        public PersonModel.WesternZodiacSigns WesternZodiacSign
        {
            get { return _personModel.SunSign; }
        }
        public PersonModel.ChineseZodiacSigns ChineseZodiacSign
        {
            get { return _personModel.ChineseSign; }
        }
        public bool IsAdult
        {
            get { return _personModel.IsAdult; }
        }
        public bool IsBirthday
        {
            get { return _personModel.IsBirthday;  }
        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand CalculateCommand
        {
            get
            {
                if (_calculateCommand == null)
                    _calculateCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Calculate, CanExecute);
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
                MessageBox.Show("Please, enter correct age!\nAll fields must be set!");
                return;
            }
            string message = "";
            if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day == BirthDate.Day)
                message += "Happy Birth Day!";
            message += "\nName       : " + Name;
            message += "\nLast name  : " + LastName;
            message += "\nEmail      : " + Email;
            message += "\nBirthday   : " + BirthDate.Date.ToString("dd.MM.yyyy");
            message += "\nIsAdult    : " + IsAdult;
            message += "\nSunSign    : " + WesternZodiacSign;
            message += "\nChineseSign: " + ChineseZodiacSign;
            message += "\nIsBirthday : " + IsBirthday;
            FlexibileMessageBox.FlexibileMessageBox.FlexibleMessageBox.FONT = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 13);
            FlexibileMessageBox.FlexibileMessageBox.FlexibleMessageBox.Show(message);

            //NotifyPropertyChanged("WesternZodiacSign");
            //NotifyPropertyChanged("ChineseZodiacSign");
            //NotifyPropertyChanged("BirthYears");

        }
        private bool CanExecute()
        {
            return Name.Length != 0 && LastName.Length != 0 && Email.Length != 0 &&
                BirthDate.Year >= 2024 - 135 && BirthDate < DateTime.Now;
        }


    }
}
