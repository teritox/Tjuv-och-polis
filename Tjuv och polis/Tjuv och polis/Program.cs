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

                Gameboard.EncounterStatistics();
                Prison.ShowPrisoners();
                Gameboard.EncounterMessages();

                Thread.Sleep(1000);

                Gameboard.UpdatePositioning();
                Prison.UpdatePrisonTime();

                Console.Clear();


            }            
        }
    }
}
