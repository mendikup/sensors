using sensore;
namespace Agants
{
    public abstract class Agent
    {
        public string Type { get; protected set; }

        protected List<ISensore> _weaknessesSensors;

        public IReadOnlyList<ISensore> Sensors => _weaknessesSensors;
        public Agent(string type)
        {
            Type = type;

            _weaknessesSensors = new List<ISensore> { };


        }


        public void AddSensore(ISensore sensore)
        {
            _weaknessesSensors.Add(sensore);
        }


    }
}