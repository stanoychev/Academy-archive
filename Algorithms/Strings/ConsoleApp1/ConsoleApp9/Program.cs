using System;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string adress = Console.ReadLine();
            string protocol = adress.Split(':')[0];
            string server = adress.Split('/')[2];
            string[] splitted = adress.Split('/');
            
            StringBuilder builder = new StringBuilder();
            for (int i = 3; i <= splitted.Length-1; i++)
            {
                builder.Append('/');
                builder.Append(splitted[i]);
            }

            string resource = builder.ToString();

            Console.WriteLine(string.Format
                ("[protocol] = {0}\n[server] = {1}\n[resource] = {2}",protocol, server, resource));

        }
    }
}
