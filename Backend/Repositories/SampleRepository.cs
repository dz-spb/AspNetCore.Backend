using Backend.DomainData;
using Microsoft.Extensions.Caching.Memory;

namespace Backend.Repositories;

public class SampleRepository : ISampleRepository
{
    // TODO: real database should be used in the real app
    //
    // If IMemoryCache is used when the app is running on multiple servers, 
    // sticky session mechanism should be used
    private readonly IMemoryCache _cache;

    public SampleRepository(IMemoryCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public async Task<SampleEntity?> GetAsync(Guid id)
    {
        _cache.TryGetValue(id, out SampleEntity? entity);
        return await Task.FromResult(entity);
    }

    public async Task<SampleEntity> AddAsync(SampleEntity entity) =>    
        await Task.FromResult(_cache.Set(entity.Id, entity));    

    public async Task<SampleEntity> UpdateAsync(SampleEntity entity) =>    
        await Task.FromResult(_cache.Set(entity.Id, entity));

    public async Task DeleteAsync(Guid id)
    {
        _cache.Remove(id);
        await Task.CompletedTask;
    }
}
