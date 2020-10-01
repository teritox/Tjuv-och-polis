using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Tjuv_och_polis
{
    class Gameboard
    {
        public static List<Person> Citizens = new List<Person>();

        public static void CreateCitizens()
        {
            for (int i = 0; i < 30; i++)
            {
                Civilian c = new Civilian();
                Citizens.Add(c);
            }

            for (int i = 0; i < 20; i++)
            {
                Theif t = new Theif(i + 1);
                Citizens.Add(t);
            }

            for (int i = 0; i < 15; i++)
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
            //Types out city and all the citizens. X and Y creates coordinates for the map.

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 125; x++)
                {
                    //bool to keep track of wheather a character for a civilian has been typed out or not, to avoid duplicates.
                    bool characterFound = false;

                    for (int g = 0; g < Citizens.Count; g++)
                    {
                        if (Citizens[g].Position[0] == x && Citizens[g].Position[1] == y)
                        {
                            //Goes through all citizens to detect if anyone is standing on this particular coordinate.

                            for (int h = 0; h < Citizens.Count; h++)
                            {
                                //Check to see if more than one character is standing on this coordinate. In that case their letters will be 
                                //prioritized like this Police > Theif > Citizen. 

                                if (Citizens[h].Position[0] == x && Citizens[h].Position[1] == y && Citizens[h] != Citizens[g])
                                {
                                    Encounter.CitizenEncounter(Citizens[g], Citizens[h]);

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
                                //If only one person is stading on the coordinate their letter will be typed out.
                                Console.Write(Citizens[g]);
                                characterFound = true;
                            }
                        }
                    }
                    if (!characterFound)
                    {
                        //If no one is standing on the coordinate a blankspace will be made instead.
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
