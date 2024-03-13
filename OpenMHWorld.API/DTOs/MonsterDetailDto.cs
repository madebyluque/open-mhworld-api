using OpenMHWorld.API.Data;

namespace OpenMHWorld.API.DTOs;

public record MonsterDetailDto(
        int Id,
        List<string> Ailments,
        List<string> Elements,
        string Icon,
        float LargeCrown,
        List<string> Locations,
        string Name,
        List<string> Resistances,
        float SmallCrown,
        int TemperedLevel,
        string Type,
        List<Weakness> Weaknessess)
{

}
