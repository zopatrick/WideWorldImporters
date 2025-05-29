using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WideWorldImporters.API.Services;
using WideWorldImporters.Server.Models;

namespace WideWorldImporters.API.Services
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryManager _manager;

        public CountryController(CountryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _manager.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _manager.GetByIdAsync(id);
            return country == null ? NotFound() : Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country country)
        {
            Country created = await _manager.CreateAsync(country);
            return CreatedAtAction(nameof(Get), new { id = created.CountryID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Country country)
        {
            var updated = await _manager.UpdateAsync(id, country);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _manager.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}

