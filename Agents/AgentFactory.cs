using sensore;

namespace Agants
{
    public static class Agentfactory
    {
        public static Agent CreateNweAgent(string agentType)
        {
            switch (agentType)
            {
                case "foot soldier":

                    var fooutSoldier = new Footsoldier();

                    fooutSoldier.AddWeakSensore(Sensorfactory.CreateSensor("Pulse"));
                    fooutSoldier.AddWeakSensore(Sensorfactory.CreateSensor("Audio"));

                    return fooutSoldier;

                    

                case "squad leader":

                    var squadLeader = new Squadleader();

                    squadLeader.AddWeakSensore(Sensorfactory.CreateSensor("Pulse"));
                    squadLeader.AddWeakSensore(Sensorfactory.CreateSensor("Audio"));
                    squadLeader.AddWeakSensore(Sensorfactory.CreateSensor("Pulse"));
                    squadLeader.AddWeakSensore(Sensorfactory.CreateSensor("Audio"));

                    return squadLeader;
                

                default:

                    {
                        var fooutSoldier1  = new Footsoldier();

                        fooutSoldier1.AddWeakSensore(Sensorfactory.CreateSensor("Pulse"));
                        fooutSoldier1.AddWeakSensore(Sensorfactory.CreateSensor("Audio"));

                        return fooutSoldier1;


                    }



            }



        }
    }

}