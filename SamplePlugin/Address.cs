using System;

public class Address
{
    public string Name;
    public string Description;
    public uint WorldId;
    public string Area;
    public uint Ward;
    public uint Plot;
    public Address()
	{
        Name = "Testing";
        Description = "Why are you reading this?\nLoser.";
        WorldId = 0;
        Area = "Shirogane";
        Ward = 0;
        Plot = 0;
	}
    public Address(string name, string description, uint worldId, string area, uint ward, uint plot)
    {
        Name = name;
        Description = description;
        WorldId = worldId;
        Area = area;
        Ward = ward;
        Plot = plot;
    }
}
