public class ModelCard : IEquatable<ModelCard>
{
    public string id;
    public string name;
    public string description;
    public string series;
    public int value;
    public string rarity;

    public ModelCard()
    {
        id = "";
        name = "";
        description = "";
        series = "";
        value = 0;
        rarity = "";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ModelCard);
    }

    public bool Equals(ModelCard? other)
    {
        return other != null && id == other.id;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}