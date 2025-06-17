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

            agent.AddWeakSensore(BSensore3);
            agent.AddWeakSensore(BSensore2);
            agent.AddWeakSensore(BSensore1);

            int trueGuesses = 0;

            // creating a copy of Weaknesses sensors list so we can remove matched sensors
            List<ISensore> leftToCheck = new List<ISensore>(agent.weaknessesSensors);

            while (trueGuesses < agent.weaknessesSensors.Count)
            {
                Console.WriteLine("Enter your guess:");
                string guess = Console.ReadLine();

                // Try to reuse existing sensor
                ISensore existing = agent.AttachedSensors.FirstOrDefault(s => s.Type == guess);
                ISensore sensore;

                if (existing != null)
                {
                    sensore = existing;

                    if (!existing.IsBroken)
                        Console.WriteLine(" Re-using existing sensor.");
                }
                else
                {
                    sensore = Sensorfactory.CreateSensor(guess);
                    agent.AttachedSensors.Add(sensore);
                    Console.WriteLine(" New sensor created and attached.");
                }

                // If the sensor is broken (like Pulse after 3 activations), skip it
                if (sensore.IsBroken)
                {
                    Console.WriteLine(" This sensor is broken and was not activated.");
                    continue; // 
                }

                // Try to match with any remaining weakness
                bool matchedThisTurn = false;

                foreach (ISensore s in leftToCheck)
                {
                    bool match = sensore.Activate(s);
                    if (match)
                    {
                        Console.WriteLine(" Match!");
                        trueGuesses++;
                        leftToCheck.Remove(s); // remove matched weakness
                        matchedThisTurn = true;
                        break;
                    }
                }

                if (!matchedThisTurn)
                {
                    Console.WriteLine(" No match this time.");
                }

                Console.WriteLine($"You guessed {trueGuesses}/{agent.weaknessesSensors.Count} correct sensors");
                Console.WriteLine();
            }
        }
    }
}
