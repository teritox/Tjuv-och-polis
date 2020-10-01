using System;
using System.Collections.Generic;
using System.Text;

namespace Tjuv_och_polis
{
    class Person
    {
        public int[] Position = new int[2];

        public int[] MovementDirection = new int[2];
      

        public void SetPosition()
        {
            //Sets a starting position for character on the map
            Random r = new Random();
            Position[0] = r.Next(0, 125);
            Position[1] = r.Next(0, 30);
            
        }

        public void SetMovement()
        {
            Random r = new Random();
            //Decides which way the character moves on the map, also makes sure no one stands still by rolling 0, 0
            do
            {
                MovementDirection[0] = r.Next(-1, 2);
                MovementDirection[1] = r.Next(-1, 2);
            } while (MovementDirection[0] == 0 && MovementDirection[1] == 0);

        }

        public void Move()
        {
            //Adds the movementdirection to position for a new set of coordinates. Moves character to otherside of map when their coordinates go out of bounds.
            Position[0] = Position[0] + (MovementDirection[0]);
            if (Position[0] == 125)
            {
                Position[0] = 0;
            }
            else if (Position[0] == (-1))
            {
                Position[0] = 124;
            }
            Position[1] = Position[1] + (MovementDirection[1]);
            if (Position[1] == 30)
            {
                Position[1] = 0;
            }
            else if (Position[1] == (-1))
            {
                Position[1] = 29;
            }
        }
    }

    class Police : Person
    {
        public List<string> ConfiscatedItems;
        public Police()
        {
            SetPosition();
            SetMovement();
            ConfiscatedItems = Inventory.CreateInventoryForPoliceAndTheif();
        }

        public override string ToString()
        {
            return $"P";
        }
    }

    class Theif : Person
    {
        public List<string> Loot;
        public int PrisonTime { get; set; }
        public int Serialnumber { get; set; }

        public Theif(int serialnumber)
        {
            Serialnumber = serialnumber;
            SetPosition();
            SetMovement();
            Loot = Inventory.CreateInventoryForPoliceAndTheif();
        }

        public override string ToString()
        {
            return "T";
        }
    }

    class Civilian : Person
    {
        public List<string> Belongings;
        public Civilian()
        {
            SetPosition();
            SetMovement();
            Belongings = Inventory.CreateInventoryForCivilian();
        }

        public override string ToString()
        {
            return "M";
        }
    }
}
