using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Prison
    {
        public static List<Person> PrisonList = new List<Person>();

        public static void Cell()
        {
            if (PrisonList.Count > 0)
            {
                for (int i = PrisonList.Count - 1; i >= 0; i--)
                {
                    if (((Theif)PrisonList[i]).PrisonTime > 30)
                    {
                        ((Theif)PrisonList[i]).PrisonTime = 0;
                        Gameboard.Citizens.Add(PrisonList[i]);

                        Encounter.EncounterList.Add($"Tjuv {((Theif)PrisonList[i]).Serialnumber} går nu fri från fängelset!\n");

                        PrisonList.RemoveAt(i);
                    }
                }

            }
        }

        public static void UpdatePrisonTime()
        {
            foreach (Person theif in PrisonList)
            {
                ((Theif)theif).PrisonTime++;
            }

            Cell();

        }

        public static void ShowPrisoners()
        {
            Console.WriteLine("\n\n- Fängelset \n");

            if (PrisonList.Count > 0)
            {
                foreach (Person theif in PrisonList)
                {
                    Console.WriteLine($"Tjuv {((Theif)theif).Serialnumber} har suttit i fängelset i {((Theif)theif).PrisonTime} sekunder.");
                }
                Console.WriteLine();
            }
        }
    }
}
