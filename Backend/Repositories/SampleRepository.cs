using Backend.DomainData;

namespace Backend.Repositories;

public class SampleRepository : ISampleRepository
{
    public async Task<SampleEntity> GetAsync(Guid id) =>    
        await Task.FromResult(new SampleEntity(id));

    public async Task<SampleEntity> AddAsync(SampleEntity entity) =>
        await Task.FromResult(entity);

    public async Task<SampleEntity> UpdateAsync(SampleEntity entity) =>
        await Task.FromResult(entity);

    public async Task DeleteAsync(Guid id) =>
        await Task.CompletedTask;
}
