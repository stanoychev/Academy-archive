using System;
using System.Collections.Generic;

namespace Conference7_100
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputLine1 = Console.ReadLine();
            long n = long.Parse(inputLine1.Split()[0]);
            long m = long.Parse(inputLine1.Split()[1]);
            List<HashSet<long>> companies = new List<HashSet<long>>();
            long sumDevsInCompanies = 0;

            string inputLine2 = Console.ReadLine();
            long x1 = long.Parse(inputLine2.Split()[0]);
            long y1 = long.Parse(inputLine2.Split()[1]);
            companies.Add(new HashSet<long> { x1, y1 });
            sumDevsInCompanies += 2;

            for (long i = 1; i <=m-1; i++)
            {
                string inputLine3 = Console.ReadLine();
                long x = long.Parse(inputLine3.Split()[0]);
                long y = long.Parse(inputLine3.Split()[1]);
                bool devsXNotAdded = true;
                bool devsYNotAdded = true;
                foreach (var company in companies)
                {
                    if (company.Contains(x))
                    {
                        if (company.Add(y))
                        {
                            sumDevsInCompanies++;
                            devsYNotAdded = false;
                        }
                    }
                    else if (company.Contains(y))
                    {
                        if (company.Add(x))
                        {
                            sumDevsInCompanies++;
                            devsXNotAdded = false;
                        }
                    }
                    if (!devsXNotAdded && !devsYNotAdded)
                    {
                        break;
                    }
                }
                if (devsXNotAdded && devsYNotAdded)
                {
                    companies.Add(new HashSet<long> { x, y });
                    sumDevsInCompanies += 2;
                }
            }

            long aloneDevs = n - sumDevsInCompanies;
            long interCompanyMeetings = 1;
            foreach (var company in companies)
            {
                interCompanyMeetings = interCompanyMeetings * company.Count;
            }

            if (companies.Count==0)
            {
                interCompanyMeetings = 0;
            }

            long betweenAloneDevs;
            betweenAloneDevs = ((aloneDevs - 1) * ((aloneDevs - 1) + 1)) / 2;

            Console.WriteLine(interCompanyMeetings + aloneDevs * sumDevsInCompanies + betweenAloneDevs);
        }
    }
}
