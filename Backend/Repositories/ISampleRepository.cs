using Backend.DomainData;

namespace Backend.Repositories;

public interface ISampleRepository
{
    Task<SampleEntity> GetAsync(Guid id);

    Task<SampleEntity> AddAsync(SampleEntity entity);

    Task<SampleEntity> UpdateAsync(SampleEntity entity);

    Task DeleteAsync(Guid id);
}
