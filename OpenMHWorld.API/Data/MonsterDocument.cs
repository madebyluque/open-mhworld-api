using Google.Cloud.Firestore;

namespace OpenMHWorld.API.Data;

[FirestoreData]
public class MonsterDocument
{
    [FirestoreProperty("ailments")]
    public List<string> Ailments { get; set; }

    [FirestoreProperty("elements")]
    public List<string> Elements { get; set; }

    [FirestoreProperty("icon")]
    public string Icon { get; set; }

    [FirestoreProperty("index")]
    public int Index { get; set; }

    [FirestoreProperty("largeCrown")]
    public float LargeCrown { get; set; }

    [FirestoreProperty("locations")]
    public List<string> Locations { get; set; }

    [FirestoreDocumentId]
    public string Name { get; set; }

    [FirestoreProperty("resistances")]
    public List<string> Resistances { get; set; }

    [FirestoreProperty("smallCrown")]
    public float SmallCrown { get; set; }

    [FirestoreProperty("temperedLevel")]
    public int TemperedLevel { get; set; }

    [FirestoreProperty("type")]
    public string Type { get; set; }

    [FirestoreProperty("weakness")]
    public List<Dictionary<string, object>> Weaknessess { get; set; }
}
