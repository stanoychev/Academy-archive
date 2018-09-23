using System;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            /*
            Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
            Please visit [our site](http://academy.telerik.com) to choose a training course.
            */

            string[] subString = input.Split(new string[] { string.Format("<a href={0}", '"'), "</a>" }, StringSplitOptions.None);

            for (int i = 0; i <=subString.Length-1; i++)
            {
                if (i%2==1)
                {
                    string url = subString[i].Split(new string[] { string.Format("{0}>",'"') },StringSplitOptions.None)[0];
                    string text = subString[i].Split(new string[] { string.Format("{0}>", '"') }, StringSplitOptions.None)[1];
                    subString[i] = builder.Append(string.Format("[{0}]({1})",text,url)).ToString();
                    builder.Clear();
                }
            }
            
            Console.WriteLine(string.Join("", subString));
        }
    }
}
