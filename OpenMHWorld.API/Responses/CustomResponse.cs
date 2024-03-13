using System.Text.Json;

namespace OpenMHWorld.API.Responses;

public record CustomResponse(bool Success, object Value, string Message = null)
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
