using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024.Models
{
    internal class PersonList
    {
        private ObservableCollection<Person> _persons;
        public PersonList()
        {
            _persons = new ObservableCollection<Person>();
            _persons.Add(new Person("Z", "1", "artem@gmail.com"));
            _persons.Add(new Person("A", "3", "aztem@gmail.com"));
            _persons.Add(new Person("B", "2", "abtem@gmail.com"));

        }
        public ObservableCollection<Person> Persons { get { return _persons; } }
    }
}
