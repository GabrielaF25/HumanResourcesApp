using AutoMapper;
using HumanResourcesApp.Models;
using HumanResourcesApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesApp.Controllers
{
	[Route("api/angajat/{idAngajat}/[controller]")]
	[ApiController]
	public class EvaluareController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IEvaluareRepository _repository;

		public EvaluareController(IEvaluareRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<EvaluareDTO>>> GetEvaluari(int idAngajat)
		{
			var evaluari = await _repository.GetEvaluariByAngajatIdAsync(idAngajat);
			if (!evaluari.Any())
			{
				return NotFound("Nicio evaluare găsită pentru acest angajat.");
			}

			var evaluariDTO = _mapper.Map<IEnumerable<EvaluareDTO>>(evaluari);
			return Ok(evaluariDTO);
		}

		[HttpPost]
		public async Task<ActionResult<EvaluareDTO>> AddEvaluare(int idAngajat, [FromBody] EvaluareDTO evaluareDto)
		{
			var evaluare = new Evaluare
			{
				AngajatId = idAngajat,
				Scor = evaluareDto.Scor,
				Comentariu = evaluareDto.Comentariu,
				DataEvaluare = evaluareDto.DataEvaluare
			};

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
	}
}
