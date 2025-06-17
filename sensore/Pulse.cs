namespace sensore
{
    public class Pulse : ISensore
    {
        public string Type { get; set; }

        public bool IsBroken { get; set; }

        private int _ActivationCount = 0;

        private const int _MaxActivation = 3;


        public Pulse()
        {
            Type = "Pulse";
            IsBroken = false;
        }

        public bool Activate(ISensore sensore)
        {

            if (IsBroken)
            {
                return false;

            }

            _ActivationCount++;

            if (_ActivationCount >= _MaxActivation)
            {
              
                IsBroken = true;
            }

            return this.Type == sensore.Type;


        }

    }

}