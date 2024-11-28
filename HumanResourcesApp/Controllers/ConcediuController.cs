using AutoMapper;
using HumanResourcesApp.Models;
using HumanResourcesApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourcesApp.Controllers
{
	[Route("api/{angajatId}/concediu")]
	[ApiController]
	public class ConcediuController : ControllerBase
	{
		private readonly IConcediuRepository _concediurepository;
		private readonly IMapper _mapper;

		public ConcediuController(IConcediuRepository concediurepository, IMapper mapper)
		{
			_concediurepository = concediurepository;
			_mapper = mapper;
		}

		// GET: api/concediu/{angajatId}
		[HttpGet]
		public async Task<ActionResult<Concediu>> GetConcediuForAngajat(int angajatId)
		{
			var concediu = await _concediurepository.GetConcediuForAngajatAsync(angajatId);
			if (concediu == null)
			{
				return NotFound($"Angajatul cu ID-ul {angajatId} nu a fost găsit.");
			}
			var concediuDto = new Concediu
			{
				AngajatId = concediu.AngajatId,
				DataAngajarii = concediu.DataAngajarii,
				CereriConcediuDTO = concediu.CereriConcediu?.Select(c => _mapper.Map<CerereConcediuDTO>(c))?.ToList() ?? new List<CerereConcediuDTO>()
		};


			return Ok(concediuDto);
	
		}

		// GET: api/concediu/{angajatId}/zile-ramase
		[HttpGet("zile-ramase")]
		public async Task<ActionResult<int>> GetZileRamase(int angajatId)
		{
			var zileRamase = await _concediurepository.GetZileRamaseAsync(angajatId);
			return Ok(zileRamase);
		}
		[HttpGet("zile-consumate")]
		public async Task<ActionResult<int>> GetZileConsumate(int angajatId)
		{
			try
			{
				var zileConsumate = await _concediurepository.GetZileConsumateAsync(angajatId);
				return Ok(zileConsumate);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("zile-totale")]
		public async Task<ActionResult<int>> GetZileTotale(int angajatId)
		{
			try
			{
				var zileTotale = await _concediurepository.GetZileTotaleAnualeAsync(angajatId);
				return Ok(zileTotale);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		// POST: api/concediu/{angajatId}/adaugare
		[HttpPost]
		public async Task<ActionResult<CerereConcediu>> AddCerereConcediu(int angajatId, [FromBody] CerereConcediu cerereConcediu)
		{
			try
			{
				var addedCerere = await _concediurepository.AddCerereConcediuAsync(angajatId, cerereConcediu);
				return CreatedAtAction(nameof(GetConcediuForAngajat), new { angajatId }, addedCerere);
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// PUT: api/concediu/{angajatId}/modificare/{cerereId}
		[HttpPut("{cerereId}")]
		public async Task<IActionResult> UpdateCerereConcediu(int angajatId, int cerereId, [FromBody] CerereConcediu cerereConcediu)
		{
			if (cerereId != cerereConcediu.Id)
			{
				return BadRequest("ID-ul cererii din ruta nu se potrivește cu ID-ul cererii din corp.");
			}

			try
			{
				await _concediurepository.UpdateCerereConcediuAsync(cerereConcediu);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// DELETE: api/concediu/{angajatId}/stergere/{cerereId}
		[HttpDelete("{cerereId}")]
		public async Task<IActionResult> DeleteCerereConcediu(int angajatId, int cerereId)
		{
			try
			{
				await _concediurepository.DeleteCerereConcediuAsync(cerereId);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
