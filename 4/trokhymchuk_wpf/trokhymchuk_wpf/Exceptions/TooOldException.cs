using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024.Exceptions
{
    internal class TooOldException : Exception
    {
        public TooOldException()
        {
        }

        public TooOldException(string message)
            : base(message)
        {
        }

        public TooOldException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public TooOldException(DateTime birthDay) : this("Date " + birthDay.Date.ToString("dd.MM.yyyy") + " is invalid, because it too far from now") { }

    }
}
