namespace sensore
{
    public static class Sensorfactory
    {
        public static ISensore CreateSensor(string type)


        {
            switch (type)

            {
                case "Audio":

                    return new Audio();


                case "pulse":
                    return new Pulse();

                default:
                    return new Audio();

            }
        }
    }
}