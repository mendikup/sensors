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

        public override void OnTurnPassed(ref int trueGuesses,  List<ISensore> leftToCheck )
        {

            CurrentTurn ++ ;

            if (CurrentTurn % 3 == 0 && AttachedSensors.Count > 0)
            {
                Random random = new Random();
                int indeex = random.Next(AttachedSensors.Count);
                var removed = AttachedSensors[indeex];
                leftToCheck.RemoveAt(indeex);
                Console.WriteLine($"Counterattack! {removed.Type} sensor was removed.");
                trueGuesses--;
            }

           
        }


        

    }
}