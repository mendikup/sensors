using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace sensore
{
    public class Audio : ISensore
    {

        public string Type { get; set; }
        public bool IsBroken { get; set; }


        public Audio()
        {
            Type = "Audio";
            IsBroken = false;

        }

        public bool Activate(ISensore sensore)
        {
            return this.Type == sensore.Type;
        }










    }



}









