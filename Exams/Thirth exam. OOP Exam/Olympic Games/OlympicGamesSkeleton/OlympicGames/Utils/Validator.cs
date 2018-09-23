using System;

namespace OlympicGames.Utils
{
    public static class Validator
    {
        public static void ValidateIfNull(this object value, string msg = null)
        {
            if (msg == null)
            {
                msg = "Value cannot be null!"; //това за на спринтера рекордите
            }

            if (value == null)
            {
                throw new ArgumentNullException(msg);
            }
        }


        public static void ValidateMinAndMaxNumber(this int value, string nameOfValue, int min, int max = int.MaxValue - 1, string msg = null)
        {
            if (msg == null)
            {
                msg = string.Format("{0} must be between {1} and {2}!", nameOfValue, min, max);//tova moje bi
            }

            if (value < min || value > max)
            {
                throw new ArgumentException(msg);
            }
        }

        public static void ValidateMinAndMaxLength(this string value, string nameOfValue, int min, int max = int.MaxValue - 1, string msg = null)
        {
            if (msg == null)
            {
                msg = string.Format("{0} must be between {1} and {2} characters long!", nameOfValue, min, max);
            }

            if (value.Length < min || value.Length > max)
            {
                throw new ArgumentException(msg);
            }
        }
    }
}
