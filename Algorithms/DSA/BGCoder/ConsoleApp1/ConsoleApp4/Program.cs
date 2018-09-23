using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] predictedPricePerGold = Console.ReadLine().Split();

            long currentGold = 0;
            long currentCash = 0;
            
            for (int i = 0; i <= n - 2; i++)
            {
                long pricePerGoldToday = long.Parse(predictedPricePerGold[i]);
                long pricePerGoldTomorrow = long.Parse(predictedPricePerGold[i + 1]);

                if (i!=n-2)
                {
                    if (pricePerGoldToday < pricePerGoldTomorrow)
                    {
                        //buyOneOunceGold();
                        currentGold++;
                        currentCash -= pricePerGoldToday;
                    }
                    else if (pricePerGoldToday > pricePerGoldTomorrow)
                    //има случай в който това се игнорира, ако не е достигнат локален максимум
                    //(по голям или равен на сумата от дните преди това)
                    //след който да има намаляване на цената
                    {
                        if (currentGold > 0)
                        {
                            //sellAllGold();
                            currentCash += currentGold * pricePerGoldToday;
                            currentGold = 0;
                        } // else { doNothing(); }
                    } // else { doNothing(); }
                }
                else //if (i==n-2)
                {
                    if (pricePerGoldToday < pricePerGoldTomorrow) // && i==n-2
                    {
                        //buyOneOunceGold() today and sell all tomorrow
                        currentGold++;
                        currentCash -= pricePerGoldToday;
                        currentCash += currentGold * pricePerGoldTomorrow;
                    }
                    else if (pricePerGoldToday > pricePerGoldTomorrow) // && i==n-2
                    {
                        if (currentGold > 0)
                        {
                            //sellAllGold() today and doNothing() tomorrow
                            currentCash += currentGold * pricePerGoldToday;
                        } // else { doNothing(); }

                    } // else { doNothing(); }
                }
            }
            Console.WriteLine(currentCash);
        }
    }
}