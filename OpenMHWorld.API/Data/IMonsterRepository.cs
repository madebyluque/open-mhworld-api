namespace OpenMHWorld.API.Data;

public interface IMonsterRepository
{
    Task<long?> GetTotalCount();
    Task<MonsterDocument> GetMonsterDocumentById(long id);
    Task<List<MonsterDocument>> GetMonstersDocuments(int page, int pageSize);
}
