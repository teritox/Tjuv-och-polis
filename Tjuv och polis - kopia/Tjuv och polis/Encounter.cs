using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Encounter
    {
        public static List<string> EncounterList = new List<string>();

        public static int[] StatisticsArray = new int[2];

        public static void EncounterMessages()
        {
            Console.WriteLine("- Händelser i staden \n");

            foreach (string msg in EncounterList)
            {
                Console.WriteLine(msg);
            }
            EncounterList.Clear();

        }

        public static void CitizenEncounter(Person p1, Person p2)
        {
            if (p1 is Police && p2 is Theif)
            {
                if (((Theif)p2).Loot.Count > 0)
                {
                    Inventory.PoliceArrest(p1, p2);
                    Prison.PrisonList.Add(p2);
                    Gameboard.Citizens.Remove(p2);

                    StatisticsArray[0]++;
                }
            }
            else if (p1 is Theif && p2 is Civilian)
            {
                if (((Civilian)p2).Belongings.Count > 0)
                {
                    Inventory.TheifStealing(p1, p2);

                    StatisticsArray[1]++;
                }
            }
        }

        public static void EncounterStatistics()
        {
            Console.WriteLine($"\nAntal rånade medborgare: {StatisticsArray[1]}");
            Console.WriteLine($"Antal gripna tjuvar: {StatisticsArray[0]}");
        }
    }

}
