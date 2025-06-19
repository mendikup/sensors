using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace sensore
{
    public class Audio : ISensore
    {

        public string Type { get; set; }
        public bool IsActive { get; set; }


        public Audio()
        {
            Type = "Audio";
            IsActive = false;

        }

        public bool Activate(ISensore sensore)
        {
            IsActive = true;

            return this.Type == sensore.Type;

        }

       










    }



}









