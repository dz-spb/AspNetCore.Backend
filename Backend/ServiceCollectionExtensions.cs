using Backend.Repositories;

namespace Backend;

public static class ServiceCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ISampleRepository, SampleRepository>();
    }
}
