using sensore;
namespace Agants
{
    public abstract class Agent
    {
        public string Rank { get; protected set; }
        public List<ISensore> weaknessesSensors { get; private set; }
        public List<ISensore> AttachedSensors { get; private set; }


        public Agent(string rank)
        {
            Rank = rank;
            weaknessesSensors = new List<ISensore> { };
            AttachedSensors = new List<ISensore> { };




        }


        public void AddWeakSensore(ISensore sensore)
        {
            weaknessesSensors.Add(sensore);
        }

        public void AttachSensore(ISensore sensore)
        {
            weaknessesSensors.Add(sensore);
        }





        public bool GetMatching(ISensore newsensore)

        {
            bool match = false;

            foreach (ISensore ws in weaknessesSensors)
            {

                match = ws.Activate(newsensore.Type);
            }

            return match;


        }







    }
}