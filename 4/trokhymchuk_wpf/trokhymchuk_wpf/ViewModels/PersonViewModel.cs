using KMA_ProgrammingCsharp2024.Exceptions;
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
using KMA_ProgrammingCsharp2024.Views;
using System.Windows.Forms;
namespace KMA_ProgrammingCsharp2024.ViewModels
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person = new Person();

        private GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window> _calculateCommand;
        public PersonViewModel(Person person)
        {
            _person = person;
        }
        public String Name
        {
            get
            {
                return _person.Name;
            }
            set 
            {
                _person.Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public String LastName
        {
            get { return _person.LastName; }
            set
            {
                _person.LastName = value;
            }
        }
        public String Email
        {
            get { return _person.Email; }
            set
            {
                try
                {
                    _person.Email = value;
                } catch (InvalidEmailException e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return _person.DateOfBirth;
            }
            set
            {
                try
                {
                    _person.DateOfBirth = value;
                } catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
        public Person.WesternZodiacSigns WesternZodiacSign
        {
            get { return _person.SunSign; }
        }
        public Person.ChineseZodiacSigns ChineseZodiacSign
        {
            get { return _person.ChineseSign; }
        }
        public bool IsAdult
        {
            get { return _person.IsAdult; }
        }
        public bool IsBirthday
        {
            get { return _person.IsBirthday;  }
        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window> CalculateCommand
        {
            get
            {
                if (_calculateCommand == null)
                    _calculateCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window>(Calculate, CanExecute);
                return _calculateCommand;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private void Calculate(Window window)
        {
            if (!CanExecute(window))
            {
                System.Windows.MessageBox.Show("Please, enter correct age!\nAll fields must be set!");
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
            //    FlexibileMessageBox.FlexibileMessageBox.FlexibleMessageBox.Show(message);

            //NotifyPropertyChanged("WesternZodiacSign");
            //NotifyPropertyChanged("ChineseZodiacSign");
            //NotifyPropertyChanged("BirthYears");
            if (window != null)
            {
                window.Close();
            }



        }
        private bool CanExecute(Window window)
        {
            return Name.Length != 0 && LastName.Length != 0 && Email.Length != 0 &&
                BirthDate.Year >= 2024 - 135 && BirthDate < DateTime.Now;
        }


    }
}
