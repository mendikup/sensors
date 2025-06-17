using System;
using Agants;
using sensore;

namespace Game
{
    public static class GameManeger
    {
        public static void Start()

        {
            SimpleAgent agent = new SimpleAgent("mac");

            // creating simple sensors for example
            ISensore BSensore1 = Sensorfactory.CreateSensor("Audio");
            ISensore BSensore2 = Sensorfactory.CreateSensor("Audio");
            ISensore BSensore3 = Sensorfactory.CreateSensor("Pulse");


            agent.AddWeakSensore(BSensore1);
            agent.AddWeakSensore(BSensore2);
            agent.AddWeakSensore(BSensore3);


            int trueGuesses = 0;

            //creating a copy of Weaknesses senssors list so we can remove sensor we already check to prevent duplication
            List<ISensore> leftToCheck = new List<ISensore>(agent.weaknessesSensors);



            while (trueGuesses < agent.weaknessesSensors.Count)
            {

                Console.WriteLine("Enter your guess:");
                string guess = Console.ReadLine();

                //checks if Pulse sensor Already exist becuase if so we wnat to reuse it
                ISensore existing = agent.AttachedSensors.FirstOrDefault(s => s.Type == guess && !s.IsBroken);

                ISensore sensore;

                if (existing != null)
                {
                    sensore = existing;
                    Console.WriteLine(" Re-using existing sensor.");
                }

                else
                {
                    sensore = Sensorfactory.CreateSensor(guess);
                    agent.AttachedSensors.Add(sensore);
                    Console.WriteLine(" New sensor created and attached.");
                }





                // loop through the weaknesses Sensors list to find a match between the gusse and one of the sensors


                if (sensore.IsBroken)
                {
                    Console.WriteLine(" This sensor is broken and was not activated.");
                    break;//we found a broken sensor so we don't want to use it again 
                }

                else
                {
                    foreach (ISensore s in leftToCheck)
                    {
                        bool match = s.Activate(guess);
                        if (match)
                        {
                            Console.WriteLine(" Match!");
                            trueGuesses++;
                            leftToCheck.Remove(s);
                            break; //there is no need to check anymore
                        }

                    }

                }
                   Console.WriteLine($"you guessed {trueGuesses}/{agent.weaknessesSensors.Count()} correct sensors ");
                     Console.WriteLine();

            }



         
        }

     
        }
}

