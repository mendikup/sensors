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

        public override void OnTurnPassed()
        {
            // Increment the internal turn counter for this agent
            CurrentTurn++;

            // Every 3 turns, trigger a counterattack as long as the game not finished
            if (CurrentTurn % 3 == 0 && weaknessesSensors.Any(sensor => !sensor.IsActive))
            {
                // Pick a random sensor from the weaknesses sensors and disable it
                Random random = new Random();
                int index = random.Next(weaknessesSensors.Count);
                var atttaced = weaknessesSensors[index];
                atttaced.IsActive = false;

                Console.WriteLine($"ATTACK!![the agent removed the {atttaced.Type}try again!]");

          
            }
        }
    }


}






