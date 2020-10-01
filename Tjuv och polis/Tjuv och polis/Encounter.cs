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
            //Keeps all the strings from different events to typ out in console when called and then clears the list.
            Console.WriteLine("- Händelser i staden \n");

            foreach (string msg in EncounterList)
            {
                Console.WriteLine(msg);
            }
            EncounterList.Clear();
        }

        public static void CitizenEncounter(Person p1, Person p2)
        {
            //If a theif carries loot it will be added to the police and then will be removed from gameboards list and addded to prison.
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

            //Theif steals from civilian if they are carrying anything.
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
