namespace Agants
{
    public abstract class Agent
    {
        public string Type;

        public List<string> WeaknessesSensors;



        public Agent(string type)
        {
            Type = type;

            WeaknessesSensors = new List<string> { };


        }

    }
}