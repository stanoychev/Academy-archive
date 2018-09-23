using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils;
using Academy.Models.Enums;

namespace Academy.Models.Utils
{
    public static class Validator
    {
        public static void StringValidator(string input, int minLength, int maxLength, string message)
        {
            if (input.Length < minLength ||
                input.Length > maxLength ||
                input == null)
            {
                throw new ArgumentException(message);
            }
        }
        public static void NumberValidator(IComparable checkNumber, IComparable min, IComparable max, string message)
        {
            if (checkNumber.CompareTo(min)==-1
                ||
                checkNumber.CompareTo(max)==1)
            {
                throw new ArgumentException(message);
            }
        }
        public static void StudentTrackValidator(Track track)
        {
            if (track != Track.Frontend &&
                track != Track.Dev &&
                track != Track.None)
            {
                throw new ArgumentException(GlobalConstants.InvalidTrack);
            }
        }
    }
}
