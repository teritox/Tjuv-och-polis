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

                Encounter.EncounterStatistics();
                Prison.ShowPrisoners();

                Encounter.EncounterMessages();

               
                Gameboard.UpdatePositioning();
                Prison.UpdatePrisonTime();

                Thread.Sleep(1000);

                Console.Clear();

            }            
        }
    }
}
