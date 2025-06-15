namespace sensore
{
    public interface ISensore
    {
       protected string Type { get; set; }
       protected bool IsBroken { get; set; }
       protected bool Activate(string guss);
    }


}
