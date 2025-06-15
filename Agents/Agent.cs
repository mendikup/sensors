using sensore;
namespace Agants
{
    public abstract class Agent
    {
       public string Type;

       public List<ISensore> WeaknessesSensors;



        public Agent(string type)
        {
            Type = type;

            WeaknessesSensors = new List<ISensore> { };


        }


        public void AddSensore(ISensore sensore)
        {
            WeaknessesSensors.Add(sensore);
        }


    }
}