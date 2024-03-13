namespace OpenMHWorld.API.Data;

public record Weakness
{
    public Weakness(Dictionary<string, object> weaknessDocument)
    {
        Name = (string)weaknessDocument.FirstOrDefault(x => x.Key == "name").Value;
        Stars = Convert.ToInt32(weaknessDocument.FirstOrDefault(x => x.Key == "stars").Value);
    }

    public string Name { get; init; }
    public int Stars { get; init; }
}
