using sensore;
namespace Agants
{
    public abstract class Agent
    {
        public string Rank { get; private set; }

        public int CurrentTurn { get; private set; }
        public List<ISensore> weaknessesSensors { get; private set; }

        public Agent()
        {

            Rank = "";
            weaknessesSensors = new List<ISensore> { };
            CurrentTurn = 0;

        }


        public void AddWeakSensore(ISensore sensore)
        {
            weaknessesSensors.Add(sensore);
        }

        public virtual void OnTurnPassed( ){}
       





        // public bool GetMatching(ISensore newsensore)

        // {
        //     bool match = false;

        //     foreach (ISensore ws in weaknessesSensors)
        //     {

        //         match = ws.Activate(newsensore.Type);
        //     }

        //     return match;


        // }







    }
}