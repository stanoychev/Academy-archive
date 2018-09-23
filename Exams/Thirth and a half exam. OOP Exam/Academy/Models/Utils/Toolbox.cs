using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    public static class Toolbox
    {
        public static string PrintEnumerable<T>(IList<T> enumerable, string messageIfEmptyOrNull)
        {
            //tuka ne znam kakvo napravih no mi hareswa
            StringBuilder builder = new StringBuilder();

            if (enumerable == null || enumerable.Count == 0)
            {
                return messageIfEmptyOrNull;
            }
            else
            {
                for (int i = 0; i <= enumerable.Count - 1; i++)
                {
                    if (i == enumerable.Count - 1)
                    {
                        builder.Append(enumerable.ElementAt(i).ToString());
                    }
                    else
                    {
                        builder.Append(string.Format("{0}\n", enumerable.ElementAt(i).ToString()));
                    }
                }
                return builder.ToString();
            }

        }
        public static string PrintEnumerable<T>(IList<T> enumerable)
        {
            StringBuilder builder = new StringBuilder();
            
            for (int i = 0; i <= enumerable.Count - 1; i++)
            {
                if (i == enumerable.Count - 1)
                {
                    builder.Append(enumerable.ElementAt(i).ToString());
                }
                else
                {
                    builder.Append(string.Format("{0}\n", enumerable.ElementAt(i).ToString()));
                }
            }
            return builder.ToString();
            
        }
    }
}
