using System.Dynamic;

namespace sensore
{
    public interface ISensore
    {
        public string Type { get; set; }
        public bool IsBroken { get; set; }

        public bool CanBreak();
       public bool Activate(ISensore sensore);
    }


}
