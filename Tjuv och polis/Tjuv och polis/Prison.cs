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
                foreach (Person person in PrisonList)
                {
                    if (((Theif)person).PrisonTime > 30)
                    {
                        ((Theif)person).PrisonTime = 0;
                        Gameboard.Citizens.Add(person);

                        PrisonList.Remove(person);
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
            Console.WriteLine("Fängelset: ");

            if (PrisonList.Count > 0)
            {
                int theifs = 1;

                foreach (Person theif in PrisonList)
                {
                    Console.WriteLine($"Tjuv {theifs} har suttit i fängelset i {((Theif)theif).PrisonTime} sekunder.");
                    theifs++;
                }
            }
        }


    }
}
