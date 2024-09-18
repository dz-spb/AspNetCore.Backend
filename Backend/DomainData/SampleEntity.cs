namespace Backend.DomainData;

public class SampleEntity
{
    public SampleEntity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }

    public object? SomeData { get; set; }
}
