using Backend.DomainData;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;
[ApiController]
[Route("sample")]
public class SampleController : ControllerBase
{   
    private readonly ISampleRepository _sampleRepository;
    private readonly ILogger<SampleController> _logger;

    public SampleController(ISampleRepository sampleRepository, ILogger<SampleController> logger)
    {
        _sampleRepository = sampleRepository ?? throw new ArgumentNullException(nameof(sampleRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var entity = await _sampleRepository.GetAsync(id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] object data)
    {
        var result = await _sampleRepository.AddAsync(new SampleEntity { Id = Guid.NewGuid(), SomeData = data });

        return CreatedAtAction("Get", new { result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SampleEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        var result = await _sampleRepository.UpdateAsync(entity);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _sampleRepository.DeleteAsync(id);

        return NoContent();
    }
}
