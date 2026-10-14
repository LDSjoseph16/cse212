public class FeatureCollection
{
    public List<Feature> Features { get; set; } = new();
}

public class Feature
{
    public Properties Properties { get; set; } = new();
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }   // nullable: some events have no magnitude
}