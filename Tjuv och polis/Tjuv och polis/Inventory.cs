using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Inventory
    {
        public static void TheifStealing(Person p1, Person p2)
        {
            //Adds random item to theifs inventory from civilian and removes it from civilians inventory.

            Random r = new Random();
            int itemIndex = r.Next(0, ((Civilian)p2).Belongings.Count);

            Encounter.EncounterList.Add("En tjuv rånade en medborgare!");

            ((Theif)p1).Loot.Add(((Civilian)p2).Belongings[itemIndex].ToString());
            ((Civilian)p2).Belongings.RemoveAt(itemIndex);
        }

        public static void PoliceArrest(Person p1, Person p2)
        {
            //Adds all stolen items from theif and adds them to polices inventory.

            Encounter.EncounterList.Add("En polis grep en tjuv!");
 
            foreach (string item in ((Theif)p2).Loot)
            {
                ((Police)p1).ConfiscatedItems.Add(item);
            }

            Encounter.EncounterList.Add("\n");

            ((Theif)p2).Loot.Clear();
        }

        public static List<string> CreateInventoryForPoliceAndTheif()
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
