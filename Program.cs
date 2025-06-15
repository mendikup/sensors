
using Agants;
using sensore;
public class Program
{
    static void Main(string[] args)
    {
        SimpleAgent agent = new SimpleAgent("mac");
        ISensore BSensore2 = new SimpleSensore("base");
        ISensore BSensore1 = new SimpleSensore("thermal");

        agent.AddSensore(BSensore1);
        agent.AddSensore(BSensore2);

        int trueGusses = 0;

        while (trueGusses < agent.WeaknessesSensors.Count())
        {
           
            System.Console.WriteLine("enter yuor gusse");
            string gusse = Console.ReadLine();
            foreach (ISensore s in agent.WeaknessesSensors)
            {
                bool match = s.Activate(gusse);
                if (match)
                {
                    trueGusses++;

                }
                
                
            }
            
          Console.WriteLine($"{trueGusses}/{agent.WeaknessesSensors.Count()} matches!");

        }


 
    }
}