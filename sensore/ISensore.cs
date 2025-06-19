using System.Dynamic;

namespace sensore
{
    public interface ISensore
    {
        public string Type { get; set; }
        public bool IsActive
        { get; set; }

      
       public bool Activate(ISensore sensore);
    }


}
