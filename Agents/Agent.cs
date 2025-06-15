namespace Agants
{
    public abstract class Agent
    {
        string Type;

        List<string> WeaknessesSensors;
        
        

        public Agent(string type)
        {
            Type = type;

            WeaknessesSensors = new List<string> { };


        }
        
    }
}