using sensore;

namespace Agants
{
    public class Squadleader : Agent
    {
        public string Rank;
        public int CurrentTurn;
        public Squadleader()
        {
            Rank = "SquadLaeder";
        }

        public override void OnTurnPassed(ref int trueGuesses, List<ISensore> leftToCheck)
        {
            // Increment the internal turn counter for this agent
            CurrentTurn++;

            // Every 3 turns, trigger a counterattack
            if (CurrentTurn % 3 == 0 && AttachedSensors.Count > 0)
            {
                // Pick a random sensor from the attached sensors
                Random random = new Random();
                int index = random.Next(AttachedSensors.Count);
                var attackedSensor = AttachedSensors[index];

                // Disable the sensor (does not remove it)
                if (attackedSensor.CanBreak)
                {
                    attackedSensor.IsBroken = true;
                    Console.WriteLine(" This sensor is now broken.");
                }
                Console.WriteLine($"Counterattack! {attackedSensor.Type} sensor was disabled.");

                // If the removed sensor was previously matched, re-add it to weaknesses
                var matchedWeakness = weaknessesSensors
                    .FirstOrDefault(w => w.Type == attackedSensor.Type && !leftToCheck.Contains(w));

                if (matchedWeakness != null)
                {
                    leftToCheck.Add(matchedWeakness);
                    trueGuesses = Math.Max(0, trueGuesses - 1);
                }
            }
        }
    }


}





}
