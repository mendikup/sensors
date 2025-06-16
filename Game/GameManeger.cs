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
            ISensore BSensore1 = new SimpleSensore("thermal");
            ISensore BSensore2 = new SimpleSensore("base");

            agent.AddSensore(BSensore1);
            agent.AddSensore(BSensore2);

            int trueGuesses = 0;

            while (trueGuesses < agent.weaknessesSensors.Count)
            {
                Console.WriteLine("Enter your guess:");
                string guess = Console.ReadLine();

                // loop through the weaknesses Sensors list to find a match between the gusse and one of the sensors
                foreach (ISensore s in agent.weaknessesSensors)
                {
                    bool match = s.Activate(guess);
                    if (match)
                    {
                        trueGuesses++;
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
