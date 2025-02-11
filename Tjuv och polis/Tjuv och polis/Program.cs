﻿using System;
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
                //Creates map
                Gameboard.City();

                //Shows various information
                Encounter.EncounterStatistics();
                Prison.Prisoners();
                Encounter.EncounterMessages();

                Gameboard.UpdatePositioning();
                Prison.UpdatePrisonTime();

                Thread.Sleep(1000);

                Console.Clear();

            }            
        }
    }
}
