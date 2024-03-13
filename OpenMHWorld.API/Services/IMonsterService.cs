using OpenMHWorld.API.DTOs;
using OpenMHWorld.API.Responses;

namespace OpenMHWorld.API.Services;

public interface IMonsterService
{
    Task<MonsterDetailDto> GetMonsterById(int id);
    Task<PaginatedResponse> GetMonsters(int page, int pageSize);
}
