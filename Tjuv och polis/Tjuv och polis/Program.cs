using System;
using System.Threading;

namespace Tjuv_och_polis
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameboard.CreateCitizens();

            while (true)
            {
                Gameboard.City();

                Console.WriteLine();
                Gameboard.EncounterStatistics();

                Console.WriteLine();
                Gameboard.EncounterMessages();
                Prison.ShowPrisoners();

                Thread.Sleep(1000);

                Gameboard.UpdatePositioning();
                Prison.UpdatePrisonTime();

                Console.Clear();


            }

            
        }
    }
}
