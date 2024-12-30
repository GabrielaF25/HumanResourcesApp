using AutoMapper;
using HumanResourcesApp.Models;
using HumanResourcesApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesApp.Controllers
{
	[Route("api/{idAngajat}/[controller]")]
	[ApiController]
	public class EvaluareController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IEvaluareRepository _repository;
		private readonly IAngajatRepository _angajatRepository;

		public EvaluareController(IAngajatRepository angajatRepository, IEvaluareRepository repository, IMapper mapper)
		{
			_repository = repository;
			_angajatRepository = angajatRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvaluareDTO>>> GetEvaluari(int idAngajat)
		{
			var angajat = _angajatRepository.AngajatExistsAsync(idAngajat);
			if (angajat == null) return NotFound();
			var evaluari = await _repository.GetEvaluariByAngajatIdAsync(idAngajat);
			if (!evaluari.Any())
			{
				return NotFound("Nicio evaluare găsită pentru acest angajat.");
			}

			var evaluariDTO = _mapper.Map<IEnumerable<EvaluareDTO>>(evaluari);
			return Ok(evaluariDTO);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateEvaluare(int id, [FromBody] EvaluareDTO evaluareDto)
		{

			if (id != evaluareDto.Id)
			{
				return BadRequest("ID-ul evaluării nu se potrivește cu cel din ruta.");
			}

			if (!await _repository.EvaluareExistsAsync(id))
			{
				return NotFound($"Evaluarea cu ID-ul {id} nu a fost găsită.");
			}

			var evaluare = _mapper.Map<Evaluare>(evaluareDto);

			try
			{
				await _repository.UpdateEvaluareAsync(evaluare);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Eroare internă: {ex.Message}");
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<EvaluareDTO>> AddEvaluare(int idAngajat, [FromBody] EvaluareDTO evaluareDto)
		{
			var angajat = _angajatRepository.AngajatExistsAsync(idAngajat);
			if (angajat == null) return NotFound();
			var evaluare = _mapper.Map <Evaluare>(evaluareDto);

			var createdEvaluare = await _repository.AddEvaluareAsync(evaluare);

			return CreatedAtAction(nameof(GetEvaluari), new { idAngajat }, createdEvaluare);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvaluare(int id)
		{
			if (!await _repository.EvaluareExistsAsync(id))
			{
				return NotFound();
			}

			await _repository.DeleteEvaluareAsync(id);
			return NoContent();

		}
		[HttpGet("aprobate")]
		public async Task<IActionResult> GetCereriAprobate()
		{
			var cereriAprobate = await _repository.GetAllEvaluariAsync();
			var count= cereriAprobate.Count();
			return Ok(count);
		}

	}
}
