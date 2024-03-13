using Google.Cloud.Firestore;
using OpenMHWorld.API.Data;
using OpenMHWorld.API.Services;

namespace OpenMHWorld.API.Extensions;

public static class FirebaseExtension
{
    public static IServiceCollection ConfigureFirebase(this IServiceCollection services, IConfiguration configuration)
    {
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(Directory.GetCurrentDirectory() + "/mhapi.json"));
        services.AddSingleton<IMonsterRepository>(s => new MonsterRepository(FirestoreDb.Create(configuration["Firebase:ProjectId"])));
        services.AddSingleton<IMonsterService, MonsterService>();

        return services;
    }
}
