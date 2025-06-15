using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace sensore
{
    public class SimpleSensore : ISensore
    {

        public string Type { get; set; }
        public bool IsBroken { get; set; }


        public SimpleSensore(string type)
        {
            Type = type;
            IsBroken = false;

        }

        public bool Activate(string guss)
        {
            return this.Type == guss;
        }










    }



}









