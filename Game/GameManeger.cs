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
            ISensore BSensore1 = new Audio("thermal");
            ISensore BSensore2 = new Audio("base");
            ISensore BSensore3 = new Audio("base");


            agent.AddSensore(BSensore1);
            agent.AddSensore(BSensore2);
            agent.AddSensore(BSensore3);


            int trueGuesses = 0;

            //creating a copy of Weaknesses senssors list so we can remove sensor we already check to prevent duplication
            List<ISensore> leftToCheck =new List<ISensore>( agent.weaknessesSensors);



            while (trueGuesses < agent.weaknessesSensors.Count)
            {
                Console.WriteLine("Enter your guess:");
                string guess = Console.ReadLine();

                // loop through the weaknesses Sensors list to find a match between the gusse and one of the sensors
                foreach (ISensore s in leftToCheck)
                {
                    bool match = s.Activate(guess);
                    if (match)
                    {
                        trueGuesses++;
                        leftToCheck.Remove(s);
                        break; //there is no need to check anymore
                    }
                }

                Console.WriteLine($"you guessed {trueGuesses}/{agent.weaknessesSensors.Count()} correct sensors ");
                System.Console.WriteLine();
            }

            Console.WriteLine("the agent was Exposed!!!");
        }
    }
}
