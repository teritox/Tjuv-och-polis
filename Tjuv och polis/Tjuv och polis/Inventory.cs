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

            Gameboard.EncounterList.Add("En tjuv rånade en medborgare! Tjuven stal: ");
            Gameboard.EncounterList.Add(((Civilian)p2).Belongings[itemIndex].ToString() + "\n");

            ((Theif)p1).Loot.Add(((Civilian)p2).Belongings[itemIndex].ToString());
            ((Civilian)p2).Belongings.RemoveAt(0);
        }

        public static void PoliceArrest(Person p1, Person p2)
        {
            Gameboard.EncounterList.Add("En polis tog en tjuv! Polisen konfiskerade: ");
            foreach (string item in ((Theif)p2).Loot)
            {
                Gameboard.EncounterList.Add(item);
                ((Police)p1).ConfiscatedItems.Add(item);
            }
            Gameboard.EncounterList.Add("\n");

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
