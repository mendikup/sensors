namespace Agants
{
    public class Squadleader : Agent
    {
        public string Rank;
        public Squadleader()
        {
            Rank = "SquadLaeder";
        }

        public override void OnTurnPassed()
        {
            base.OnTurnPassed();

            if (CurrentTurn % 3 == 0 && AttachedSensors.Count > 0)
            {
                Random random = new Random();
                int indeex = random.Next(AttachedSensors.Count);
                var removed = AttachedSensors[indeex];
                AttachedSensors.RemoveAt(indeex);
                Console.WriteLine($"Counterattack! {removed.Type} sensor was removed.");
            }

           
        }


        

    }
}