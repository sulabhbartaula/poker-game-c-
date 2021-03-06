using System;

namespace PockerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\t\t------------------------------- Welcome to Pocker Game -------------------------------\n\n\n");

            DealCardsRandomly dcr = new DealCardsRandomly();
            dcr.DealCards();

     

        }
    }
}
