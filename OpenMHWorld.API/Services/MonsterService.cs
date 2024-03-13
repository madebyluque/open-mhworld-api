using OpenMHWorld.API.Data;
using OpenMHWorld.API.DTOs;
using OpenMHWorld.API.Responses;

namespace OpenMHWorld.API.Services;

public class MonsterService(IMonsterRepository repository) : IMonsterService
{
    public async Task<MonsterDetailDto> GetMonsterById(int id)
    {
        var monsterDocument = await repository.GetMonsterDocumentById(id);

        if (monsterDocument == null)
        {
            return null;
        }

        return ConvertDocumentToMonsterDetailsDto(monsterDocument);
    }

    public async Task<PaginatedResponse> GetMonsters(int page, int pageSize)
    {
        var documents = await repository.GetMonstersDocuments(page, pageSize);
        var count = await repository.GetTotalCount();
        var monsters = documents.Select(ConvertDocumentToMonsterDto).ToList();
        return new PaginatedResponse(new CustomResponse(true, monsters), count, page, pageSize);
    }

    public MonsterDto ConvertDocumentToMonsterDto(MonsterDocument document)
    {
        return new MonsterDto(document.Index, document.Name, document.Icon);
    }

    public MonsterDetailDto ConvertDocumentToMonsterDetailsDto(MonsterDocument document)
    {
        var weaknesses = document.Weaknessess.Select(x => new Weakness(x)).ToList();
        return new MonsterDetailDto(
            document.Index,
            document.Ailments,
            document.Elements,
            document.Icon,
            document.LargeCrown,
            document.Locations,
            document.Name,
            document.Resistances,
            document.SmallCrown,
            document.TemperedLevel,
            document.Type,
            weaknesses);
    }
}
