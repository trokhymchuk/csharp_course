using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA_ProgrammingCsharp2024.Models
{
    internal class ZodiacModel
    {
        private DateTime _birthDate = DateTime.Now;
        private WesternZodiacSigns _westernZodiacSign;
        private ChineseZodiacSigns _chineseZodiacSign;
        private int _birthYears;
        public DateTime BirthDate { 
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                _westernZodiacSign = CalculateWesternZodiacSign(_birthDate);
                _chineseZodiacSign = CalculateChineseZodiacSigns(_birthDate);
                _birthYears = CalculateAge(_birthDate);
            }
        }
        public WesternZodiacSigns WesternZodiacSign { get { return _westernZodiacSign; } }
        public ChineseZodiacSigns ChineseZodiacSign { get { return _chineseZodiacSign; } }

        public int BirthYears { get { return _birthYears; } }
        public enum WesternZodiacSigns
        {
            Aries,       // March 21 - April 19
            Taurus,      // April 20 - May 20
            Gemini,      // May 21 - June 20
            Cancer,      // June 21 - July 22
            Leo,         // July 23 - August 22
            Virgo,       // August 23 - September 22
            Libra,       // September 23 - October 22
            Scorpio,     // October 23 - November 21
            Sagittarius, // November 22 - December 21
            Capricorn,   // December 22 - January 19
            Aquarius,    // January 20 - February 18
            Pisces       // February 19 - March 20
        };
        private WesternZodiacSigns CalculateWesternZodiacSign(DateTime birthDate)
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
        public static ChineseZodiacSigns CalculateChineseZodiacSigns(DateTime birthDate)
        {
            // Determine the Chinese Zodiac sign based on the birth date
            int year = birthDate.Year;
            int startYear = 1924; // The first year of the Chinese zodiac cycle

            int offset = (year - startYear) % 12;

            return (ChineseZodiacSigns) offset;
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                --age;
            return age;

        }

    }
}
