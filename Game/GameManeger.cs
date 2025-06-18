using System;
using Agants;
using Microsoft.VisualBasic;
using sensore;

namespace Game
{
    public static class GameManeger
    {
        public static void Start()
        {
            List<Agent> agents = new List<Agent>
            {
              Agentfactory.CreateNweAgent("foot solider"),
              Agentfactory.CreateNweAgent("squad leader")
            };



            foreach (Agent agent in agents)
            {

                int trueGuesses = 0;

                // creating a copy of Weaknesses sensors list so we can remove matched sensors
                List<ISensore> leftToCheck = new List<ISensore>(agent.weaknessesSensors);

                while (trueGuesses < agent.weaknessesSensors.Count)
                {
                    Console.WriteLine("Enter the sensor type you want to attach {pulse,audio}:");
                    string guess = Console.ReadLine().Trim();  // we trim to clean spaces

                    bool matchedThisTurn = false;

                    // get all sensors of that type that are not broken
                    var candidates = agent.AttachedSensors
                                          .Where(s => s.Type == guess && !s.IsBroken)
                                          .ToList();

                    // go through existing (non-broken) sensors first
                    foreach (var sensor in candidates)
                    {
                        Console.WriteLine(" Re-using existing sensor.");

                        if (TryMatchSensor(sensor, leftToCheck, ref trueGuesses))
                        {
                            matchedThisTurn = true;
                            break;
                        }

                        if (sensor.IsBroken)
                        {
                            Console.WriteLine(" This sensor is now broken.");
                        }
                    }


                    // if no match found, create a new sensor and try again
                    if (!matchedThisTurn)
                    {
                        ISensore newSensor = Sensorfactory.CreateSensor(guess);
                        agent.AttachedSensors.Add(newSensor);
                        Console.WriteLine(" New sensor created and attached.");

                        if (TryMatchSensor(newSensor, leftToCheck, ref trueGuesses))
                        {
                            matchedThisTurn = true;
                        }




                        if (!matchedThisTurn)
                        {
                            Console.WriteLine(" No match this time.");
                        }
                    }

                    Console.WriteLine($"You guessed {trueGuesses}/{agent.weaknessesSensors.Count} correct sensors");
                    Console.WriteLine();
                    agent.OnTurnPassed(ref trueGuesses,leftToCheck);
                }

                Console.WriteLine($"the agent{agent.Rank} was exposed and now you continu to the next level");
               

            }
 
        }

        // try to match a sensor against the remaining weaknesses
        // if match found  remove it and increase trueGuesses
        private static bool TryMatchSensor(ISensore sensor, List<ISensore> weaknesses, ref int trueGuesses)
        {
            foreach (ISensore s in weaknesses)
            {
                bool isMatch = sensor.Activate(s);
                if (isMatch)
                {
                    Console.WriteLine(" Match!");
                    weaknesses.Remove(s); // remove matched weakness
                    trueGuesses++; // count the success
                    return true;
                }
            }

            return false; // no match found
        }
    }
}
