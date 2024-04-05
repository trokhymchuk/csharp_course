using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException()
        {
        }

        public InvalidEmailException(string message)
            : base("The email " + message + " is invalid!")
        {
        }

        public InvalidEmailException(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}

