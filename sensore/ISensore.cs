
public interface ISensors
{
    string Name { get; }
    bool IsBroken { get; }
    bool Activate(string[] weaknes);
}
