using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Inventory
    {
        

        public void AddItem()
        {

        }

        public void RemoveItem()
        {

        }

        public static string[] CreateInventoryForPoliceOrTheif()
        {
            string[] array = new string[10];
            return array;
        }

        public static string[] CreateInventoryForCivilian()
        {
            string[] array = new string[4];

            array[0] = "Nycklar";
            array[1] = "Mobiltelefon";
            array[2] = "Pengar";
            array[3] = "Klocka";

            return array;
        }
    }
}
