using Google.Cloud.Firestore;

namespace OpenMHWorld.API.Data;

public class MonsterRepository(FirestoreDb db) : IMonsterRepository
{
    private const string _collectionName = "monsters";

    public async Task<MonsterDocument> GetMonsterDocumentById(long id)
    {
        var query = GetCollection().WhereEqualTo("index", id);
        return (await RunQuery(query)).FirstOrDefault();
    }

    public async Task<List<MonsterDocument>> GetMonstersDocuments(int page, int pageSize)
    {
        var query = GetCollection().OrderBy("index")
                                   .StartAt((page - 1) * pageSize + 1)
                                   .Limit(pageSize);

        return await RunQuery(query);
    }

    public async Task<long?> GetTotalCount() =>
        (await GetCollection().Count().GetSnapshotAsync()).Count;

    private static async Task<List<MonsterDocument>> RunQuery(Query query)
    {
        var snapshot = await query.GetSnapshotAsync();
        return snapshot.Documents.Select(s => s.ConvertTo<MonsterDocument>())
                                 .ToList();
    }

    private CollectionReference GetCollection() => db.Collection(_collectionName);
}
