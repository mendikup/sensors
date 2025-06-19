namespace sensore
{
    public class Pulse : ISensore
    {
        public string Type { get; set; }

        public bool IsActive { get; set; }

        public int _ActivationCount { get; set; }

        private const int _MaxActivation = 3;


        public Pulse()
        {
            Type = "Pulse";
            IsActive = false;
            _ActivationCount = 0;
        }

        public bool Activate(ISensore sensore)
        {

        

            _ActivationCount++;

          

            return this.Type == sensore.Type;


        }
        

    }

}