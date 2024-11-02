
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AngajatController : ControllerBase
{
	private readonly IAngajatRepository _repository;

	public AngajatController(IAngajatRepository repository)
	{
		_repository = repository;
	}

	// GET: api/Angajat
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Angajat>>> GetAngajati()
	{
		var angajati = await _repository.GetAllAngajatiAsync();
		return Ok(angajati);
	}

	// GET: api/Angajat/5
	[HttpGet("{id}")]
	public async Task<ActionResult<Angajat>> GetAngajat(int id)
	{
		var angajat = await _repository.GetAngajatByIdAsync(id);

		if (angajat == null)
		{
			return NotFound();
		}

		return Ok(angajat);
	}

	// POST: api/Angajat
	[HttpPost]
	public async Task<ActionResult<Angajat>> PostAngajat(Angajat angajat)
	{
		await _repository.AddAngajatAsync(angajat);
		return CreatedAtAction(nameof(GetAngajat), new { id = angajat.Id }, angajat);
	}

	// PUT: api/Angajat/5
	[HttpPut("{id}")]
	public async Task<IActionResult> PutAngajat(int id, Angajat angajat)
	{
		if (id != angajat.Id)
		{
			return BadRequest();
		}

		if (!await _repository.AngajatExistsAsync(id))
		{
			return NotFound();
		}

		await _repository.UpdateAngajatAsync(angajat);
		return NoContent();
	}

	// DELETE: api/Angajat/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteAngajat(int id)
	{
		if (!await _repository.AngajatExistsAsync(id))
		{
			return NotFound();
		}

		await _repository.DeleteAngajatAsync(id);
		return NoContent();
	}
}
