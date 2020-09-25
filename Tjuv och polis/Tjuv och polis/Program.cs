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
                Gameboard.EncounterMessages();
                Thread.Sleep(500);
                Console.Clear();
                Gameboard.UpdatePositioning();
            }

            
        }
    }
}
