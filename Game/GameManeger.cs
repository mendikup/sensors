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

                // check if the sensor is broken, if so we skip it
                if (sensore.IsBroken)
                {
                    Console.WriteLine(" This sensor is broken and was not activated.");
                    continue;
                }

                // try to match this sensor with one of the remaining weaknesses
                bool matchedThisTurn = TryMatchSensor(sensore, leftToCheck, ref trueGuesses);

                if (!matchedThisTurn)
                {
                    Console.WriteLine(" No match this time.");
                }

                Console.WriteLine($"You guessed {trueGuesses}/{agent.weaknessesSensors.Count} correct sensors");
                Console.WriteLine();
            }

            Console.WriteLine("the Agent was exposed!!");
        }

        // this method checks if sensor matches any of the weaknesses
        // if match found, we remove it and add to trueGuesses
        private static bool TryMatchSensor(ISensore sensor, List<ISensore> weaknesses, ref int trueGuesses)
        {
            foreach (ISensore s in weaknesses)
            {
                bool isMatch = sensor.Activate(s);
                if (isMatch)
                {
                    Console.WriteLine(" Match!");
                    weaknesses.Remove(s); // remove matched sensor so we don’t count it again
                    trueGuesses++; // increase number of successful guesses
                    return true; // we found a match, no need to check more
                }
            }

            return false; // no match found
        }
    }
}
