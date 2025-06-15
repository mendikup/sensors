using System.ComponentModel;
using sensore;

namespace Agants
{
    public class SimpleAgent : Agent
    {
        public string Type;

       public List<ISensore> WeaknessesSensors;



        public SimpleAgent(string type) : base(type)
        {
            Type = type;

            WeaknessesSensors = new List<ISensore>{ };


        }

        public void AddSensore(ISensore sensore)
        {
            WeaknessesSensors.Add(sensore);


        }
        
    }
}