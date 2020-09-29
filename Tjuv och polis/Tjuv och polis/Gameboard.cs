using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Tjuv_och_polis
{
    class Gameboard
    {
        public static List<Person> Citizens = new List<Person>();

        public static List<string> EncounterList = new List<string>();

        public static int[] StatisticsArray = new int[2];

        public static void CreateCitizens()
        {
            for (int i = 0; i < 30; i++)
            {
                Civilian c = new Civilian();
                Citizens.Add(c);
            }

            for (int i = 0; i < 20; i++)
            {
                Theif t = new Theif();
                Citizens.Add(t);
            }

            for (int i = 0; i < 10; i++)
            {
                Police p = new Police();
                Citizens.Add(p);
            }
        }

        public static void UpdatePositioning()
        {
            foreach (Person person in Citizens)
            {
                person.Move();
            }
        }
        public static void City()
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 125; x++)
                {
                    bool characterFound = false;

                    for (int g = 0; g < Citizens.Count; g++)
                    {

                        if (Citizens[g].Position[0] == x && Citizens[g].Position[1] == y)
                        {
                            for (int h = 0; h < Citizens.Count; h++)
                            {
                                if (Citizens[h].Position[0] == x && Citizens[h].Position[1] == y && Citizens[h] != Citizens[g])
                                {
                                    CitizenEncounter(Citizens[g], Citizens[h]);

                                    if(Citizens[g] is Police || Citizens[h] is Police)
                                    {
                                        Console.Write("P");                                     
                                    }
                                    else if (Citizens[g] is Theif || Citizens[h] is Theif)
                                    {                                      
                                        Console.Write("T");                                    
                                    }
                                    else
                                    {
                                        Console.Write("M");
                                    }
                                    characterFound = true;
                                }
                            }
                            if (!characterFound)
                            {
                                Console.Write(Citizens[g]);
                                characterFound = true;
                            }
                        }

                    }
                    if (!characterFound)
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
        }

        public static void EncounterMessages()
        {
            Console.WriteLine();

            foreach (string msg in EncounterList)
            {
                Console.WriteLine(msg);
            }
            EncounterList.Clear();
        }

        private static void CitizenEncounter(Person p1, Person p2)
        {
            if (p1 is Police && p2 is Theif)
            {
                if (((Theif)p2).Loot.Count > 0)
                {
                    Inventory.PoliceArrest(p1, p2);
                    Prison.PrisonList.Add(p2);
                    Citizens.Remove(p2);

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
            Console.WriteLine($"Antal tjuvar tagna av polis: {StatisticsArray[0]}");
            Console.WriteLine($"Antal rånade medborgare: {StatisticsArray[1]}");
        }
    }
}
