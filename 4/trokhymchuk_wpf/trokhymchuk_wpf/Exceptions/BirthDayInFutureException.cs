using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024.Exceptions
{
    internal class BirthDayInFutureException : Exception
    {
        public BirthDayInFutureException()
        {
        }

        public BirthDayInFutureException(string message)
            : base(message)
        {
        }

        public BirthDayInFutureException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BirthDayInFutureException(DateTime birthDay) : this("Date " + birthDay.Date.ToString("dd.MM.yyyy") + " is invalid, because it is in future") { }
        
    }
}
