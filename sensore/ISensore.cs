namespace sensore
{
    public interface ISensore
    {
       public string Type { get; set; }
       public bool IsBroken { get; set; }
       public bool Activate(ISensore sensore);
    }


}
