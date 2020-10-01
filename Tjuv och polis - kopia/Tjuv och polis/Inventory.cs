using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Inventory
    {
        public static void TheifStealing(Person p1, Person p2)
        {
            Random r = new Random();
            int itemIndex = r.Next(0, ((Civilian)p2).Belongings.Count);

            Encounter.EncounterList.Add("En tjuv rånade en medborgare! Tjuven stal: ");

            //Used in development to ensure the theifs was able to steal something and typing it out in console for easy monitoring.
            //Encounter.EncounterList.Add(((Civilian)p2).Belongings[itemIndex].ToString() + "\n"); 

            ((Theif)p1).Loot.Add(((Civilian)p2).Belongings[itemIndex].ToString());
            ((Civilian)p2).Belongings.RemoveAt(0);
        }

        public static void PoliceArrest(Person p1, Person p2)
        {
            Encounter.EncounterList.Add("En polis tog en tjuv! Polisen konfiskerade: ");
 
            foreach (string item in ((Theif)p2).Loot)
            {
                //Used in delopment to ensure the police confiscated the stolen goods and typing it out in console for easy monitoring. 
                //Encounter.EncounterList.Add(item);
                ((Police)p1).ConfiscatedItems.Add(item);
            }

            Encounter.EncounterList.Add("\n");

            ((Theif)p2).Loot.Clear();
        }

        public static List<string> CreateInventoryForPoliceOrTheif()
        {
            List<string> list = new List<string>();
            return list;
        }

        public static List<string> CreateInventoryForCivilian()
        {
            List<string> list = new List<string>();

            list.Add("Nycklar");
            list.Add("Mobiltelefon");
            list.Add("Pengar");
            list.Add("Klocka");

            return list;
        }
    }
}
