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
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace KMA_ProgrammingCsharp2024.ViewModels
{
    internal class PersonListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons = null;
        private ObservableCollection<Person> _tmp; 
        private Person _selectedPerson;

        private GalaSoft.MvvmLight.CommandWpf.RelayCommand _addPersonCommand;
        private GalaSoft.MvvmLight.CommandWpf.RelayCommand _editPersonCommand;
        private GalaSoft.MvvmLight.CommandWpf.RelayCommand _removePersonCommand;
        private GalaSoft.MvvmLight.CommandWpf.RelayCommand _filterPersonCommand;


        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Now;
        private string _isAdult;
        private string _isBirthday;
        private string _westernSign;
        private string _chineseSign;

        const string SERIALIZE_FILE = "serialize.json";
        public PersonListViewModel()
        {
            if (File.Exists(SERIALIZE_FILE))
            {
                string json_content = File.ReadAllText(SERIALIZE_FILE);
                _persons = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Person>>(json_content);

            }
            if(_persons == null)
            {
                _persons = new ObservableCollection<Person>(GenerateRandomPersons(50));
            }
            _tmp = new ObservableCollection<Person>(_persons);

        }
        static List<Person> GenerateRandomPersons(int count)
        {
            List<Person> persons = new List<Person>();
            Random random = new Random();

            // Generate random persons
            for (int i = 0; i < count; i++)
            {
                string firstName = GetRandomName();
                string lastName = GetRandomName();
                string email = $"{firstName.ToLower()}_{lastName.ToLower()}@example.com";
                DateTime birthDate = GetRandomBirthDate(random);
                persons.Add(new Person(firstName, lastName, email, birthDate));
            }

            return persons;
        }

        static string GetRandomName()
        {
            string[] names = { "John", "Jane", "Michael", "Emily", "Robert", "Jessica", "William", "Olivia", "David", "Sophia" };
            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        static DateTime GetRandomBirthDate(Random random)
        {
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string IsAdult
        {
            get { return _isAdult; }
            set { _isAdult = value; }
        }

        public string IsBirthday
        {
            get { return _isBirthday; }
            set { _isBirthday = value; }
        }

        public string WesternSign
        {
            get { return _westernSign; }
            set { _westernSign = value; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            set { _chineseSign = value; }
        }
    

    public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }
        public Person SelectedPerson { get { return _selectedPerson; } set { _selectedPerson = value; } }
        private void AddPerson()
        {
            Person p = new Person();
            AddPerson addingPerson = new AddPerson(p);
            addingPerson.ShowDialog();
            _persons.Add(p);
            _tmp.Add(p);
            FileStream createStream = File.Create(SERIALIZE_FILE);
            JsonSerializer.Serialize(createStream, _tmp);
            createStream.Close();
            NotifyPropertyChanged("Persons");

        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand AddPersonCommand
        {
            get
            {
                if (_addPersonCommand == null)
                    _addPersonCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(AddPerson);
                return _addPersonCommand;

            }
        }
        private void Filter()
        {
            _persons.Clear();
            foreach(Person p in _tmp)
            {
                _persons.Add(p);
            }

            foreach (Person p in _tmp) {
                if(!string.IsNullOrEmpty(Name) && !p.Name.Equals(Name))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(LastName) && !p.LastName.Equals(LastName))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(Email) && !p.Email.Equals(Email))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (BirthDate != DateTime.Now.Date && !p.DateOfBirth.Date.Equals(BirthDate.Date))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(WesternSign) && !p.SunSign.Equals(WesternSign))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(ChineseSign) && !p.ChineseSign.Equals(ChineseSign))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(IsAdult) && !(p.IsAdult == (bool.Parse(IsAdult))))
                {
                    _persons.Remove(p);
                    continue;
                }
                if (!string.IsNullOrEmpty(IsBirthday) && !(p.IsBirthday == (bool.Parse(IsBirthday))))
                {
                    _persons.Remove(p);
                    continue;
                }
            }
            NotifyPropertyChanged("Persons");

        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand FilterCommand
        {
            get
            {
                if (_filterPersonCommand == null)
                    _filterPersonCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Filter);
                return _filterPersonCommand;

            }
        }

        private void EditPerson()
        {
            Person p = SelectedPerson;
            if(p == null)
            {
                System.Windows.MessageBox.Show("Select person to edit", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int position = _persons.ToList().FindIndex(person => (p == person));
            AddPerson addingPerson = new AddPerson(p);
            addingPerson.ShowDialog();
            _persons.Remove(p);
            _persons.Insert(position, p);
            _tmp.Remove(p);
            _tmp.Insert(position, p);
            FileStream createStream = File.Create(SERIALIZE_FILE);
            JsonSerializer.Serialize(createStream, _tmp);
            createStream.Close();
            NotifyPropertyChanged("Persons");

        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand EditPersonCommand
        {
            get
            {
                if (_editPersonCommand == null)
                    _editPersonCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(EditPerson);
                return _editPersonCommand;

            }
        }
        private void RemovePerson()
        {
            Person p = SelectedPerson;
            if (p == null)
            {
                System.Windows.MessageBox.Show("Select person to remove", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _persons.Remove(p);
            _tmp.Remove(p);
            FileStream createStream = File.Create(SERIALIZE_FILE);
            JsonSerializer.Serialize(createStream, _tmp);
            createStream.Close();
            NotifyPropertyChanged("Persons");

        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand RemovePersonCommand
        {
            get
            {
                if (_removePersonCommand == null)
                    _removePersonCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(RemovePerson);
                return _removePersonCommand;

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        //private void Calculate()
        //{
        //    AddPerson addWindow = new AddPerson();
        //    addWindow.ShowDialog();
        //    if (!CanExecute())
        //    {
        //        MessageBox.Show("Please, enter correct age!\nAll fields must be set!");
        //        return;
        //    }
        //    string message = "";
        //    if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day == BirthDate.Day)
        //        message += "Happy Birth Day!";
        //    message += "\nName       : " + Name;
        //    message += "\nLast name  : " + LastName;
        //    message += "\nEmail      : " + Email;
        //    message += "\nBirthday   : " + BirthDate.Date.ToString("dd.MM.yyyy");
        //    message += "\nIsAdult    : " + IsAdult;
        //    message += "\nSunSign    : " + WesternZodiacSign;
        //    message += "\nChineseSign: " + ChineseZodiacSign;
        //    message += "\nIsBirthday : " + IsBirthday;
        //    FlexibileMessageBox.FlexibileMessageBox.FlexibleMessageBox.FONT = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 13);
        //    FlexibileMessageBox.FlexibileMessageBox.FlexibleMessageBox.Show(message);

        //    //NotifyPropertyChanged("WesternZodiacSign");
        //    //NotifyPropertyChanged("ChineseZodiacSign");
        //    //NotifyPropertyChanged("BirthYears");

        //}
        //private bool CanExecute()
        //{
        //    return Name.Length != 0 && LastName.Length != 0 && Email.Length != 0 &&
        //        BirthDate.Year >= 2024 - 135 && BirthDate < DateTime.Now;
        //}


    }
}
