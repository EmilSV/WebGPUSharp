namespace WebGpuSharp;


public partial struct ConstantEntry
{
    public string Key;
    public double Value;

    public ConstantEntry(string key, double value)
    {
        Key = key;
        Value = value;
    }
}