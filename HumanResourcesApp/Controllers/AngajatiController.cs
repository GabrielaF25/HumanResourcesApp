
using AutoMapper;
using HumanResourcesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AngajatController : ControllerBase
{
	private readonly IAngajatRepository _repository;
	private readonly IMapper _mapper;

	public AngajatController(IAngajatRepository repository,IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	// GET: api/Angajat
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Angajat>>> GetAngajati()
	{
		var angajati = await _repository.GetAllAngajatiAsync();
		return Ok(angajati);
	}

	// GET: api/Angajat/5
	[HttpGet("{id}", Name ="GetById")]
	public async Task<ActionResult<AngajatDTO>> GetAngajatById(int id)
	{
		var angajat = await _repository.GetAngajatByIdAsync(id);

		if (angajat == null)
		{
			return NotFound();
		}
		var angajatDto = _mapper.Map<AngajatDTO>(angajat);
		return Ok(angajatDto);
	}

	// POST: api/Angajat
	[HttpPost]
	public async Task<ActionResult<Angajat>> PostAngajat(Angajat angajat)
	{
		// Validare suplimentară pentru asocierile complexe, dacă este nevoie

		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		//foreach (var cerere in angajat.CereriConcediu)
		//{
		//	cerere.AngajatId = angajat.Id;
		//}

		//foreach (var evaluare in angajat.Evaluari)
		//{
		//	evaluare.AngajatId = angajat.Id;
		//}

		// foreach (var document in angajat.Documente)
		// {
		//     document.AngajatId = angajat.Id;
		// } var angajat = _mapper.Map<Angajat>(angajatDto);

		var createdAngajat = await _repository.CreateAngajatAsync(angajat);

		// Convertim înapoi la DTO pentru a returna rezultatul
		var createdAngajatDto = _mapper.Map<AngajatDTO>(createdAngajat);

		return CreatedAtAction(nameof(GetAngajatById), new { id = createdAngajatDto.Id }, createdAngajatDto);
	

	//var createdAngajat = await _repository.CreateAngajatAsync(angajat);

		//return CreatedAtAction("GetById", new { id = createdAngajat.Id }, createdAngajat);
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
