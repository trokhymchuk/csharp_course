using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024
{
    internal class Person
    {
        private String _name;
        private String _lastName;
        private String _email;
        private DateTime _dateOfBirth;
        private bool _isAdult;
        private WesternZodiacSigns _sunSign;
        private ChineseZodiacSigns _chineseSign;



        public Person(String name, String lastName, String email, DateTime dateOfBirth)
        {
            _name = name;
            _lastName = lastName;
            _email = email;
            _dateOfBirth = dateOfBirth;
        }
        public Person(String name, String lastName, String email) : this(name, lastName, email, DateTime.Now)
        {
        }
        public Person(String name, String lastName, DateTime dateOfBirth) : this(name, lastName, "", dateOfBirth)
        {
        }
        public Person() : this("", "", "", DateTime.Now)
        { }
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                _sunSign = CalculateWesternZodiacSign(_dateOfBirth).Result;
                _chineseSign = CalculateChineseZodiacSigns(_dateOfBirth).Result;
                _isAdult = CalculateAge(_dateOfBirth).Result >= 18;
            }
        }
        public bool IsAdult
        { get { return _isAdult; } }
        public WesternZodiacSigns SunSign { get { return _sunSign; } }
        public ChineseZodiacSigns ChineseSign { get { return _chineseSign; } }

        public bool IsBirthday { get { return isBirthday().Result; } }

        private async Task<bool> isBirthday()
        {
            return DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day == DateOfBirth.Day;
        }


        public enum WesternZodiacSigns
        {
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        };
        private async Task<WesternZodiacSigns> CalculateWesternZodiacSign(DateTime birthDate)
        {
            int month = birthDate.Month;
            int day = birthDate.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return WesternZodiacSigns.Aries;
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return WesternZodiacSigns.Taurus;
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return WesternZodiacSigns.Gemini;
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return WesternZodiacSigns.Cancer;
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return WesternZodiacSigns.Leo;
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return WesternZodiacSigns.Virgo;
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return WesternZodiacSigns.Libra;
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return WesternZodiacSigns.Scorpio;
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return WesternZodiacSigns.Sagittarius;
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return WesternZodiacSigns.Capricorn;
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return WesternZodiacSigns.Aquarius;
            else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                return WesternZodiacSigns.Pisces;
            else
                throw new ArgumentOutOfRangeException("Invalid birth date");
        }


        public enum ChineseZodiacSigns
        {
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Goat,
            Monkey,
            Rooster,
            Dog,
            Pig
        }
        public static async Task<ChineseZodiacSigns> CalculateChineseZodiacSigns(DateTime birthDate)
        {
            // Determine the Chinese Zodiac sign based on the birth date
            int year = birthDate.Year;
            int startYear = 1924; // The first year of the Chinese zodiac cycle

            int offset = (year - startYear) % 12;

            return (ChineseZodiacSigns)offset;
        }
        public static async Task<int> CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                --age;
            return age;

        }

    }
}
