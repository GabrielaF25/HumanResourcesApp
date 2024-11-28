﻿using HumanResourcesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesApp.Repository
{
	public class ConcediuRepository : IConcediuRepository
	{
		private readonly HRDbContext _context;

		public ConcediuRepository(HRDbContext context)
		{
			_context = context;
		}

			public async Task<CerereConcediu> AddCerereConcediuAsync(int angajatId, CerereConcediu cerereConcediu)
		{

			cerereConcediu.AngajatId = angajatId;

			_context.CereriConcediu.Add(cerereConcediu);
			await _context.SaveChangesAsync();

			return cerereConcediu;
		}

		public async Task DeleteCerereConcediuAsync(int cerereId)
		{
			var cerere = await _context.CereriConcediu.FindAsync(cerereId);
			if (cerere == null)
			{
				throw new KeyNotFoundException($"Cererea de concediu cu ID-ul {cerereId} nu a fost găsită.");
			}

			_context.CereriConcediu.Remove(cerere);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CerereConcediu>> GetCereriAprobateAsync(int angajatId)
		{
			var angajat = await _context.Angajati
		   .Include(a => a.CereriConcediu)
		   .FirstOrDefaultAsync(a => a.Id == angajatId);

			return angajat?.CereriConcediu
				.Where(c => c.Status == "Aprobat")
				.ToList() ?? new List<CerereConcediu>();
		}

		public async Task<Concediu> GetConcediuForAngajatAsync(int angajatId)
		{
			var angajat = await _context.Angajati
			.Include(a => a.CereriConcediu)
			.FirstOrDefaultAsync(a => a.Id == angajatId);

			return new Concediu
			{
				AngajatId = angajat.Id,
				DataAngajarii = angajat.DataAngajarii,
				CereriConcediu = angajat.CereriConcediu.ToList()
			};
		}

		public async Task<int> GetZileConsumateAsync(int angajatId)
		{
			var concediu = await GetConcediuForAngajatAsync(angajatId);
			return concediu?.ZileConsumate ?? 0;
		}

		public async Task<int> GetZileRamaseAsync(int angajatId)
		{
			var concediu = await GetConcediuForAngajatAsync(angajatId);
			return concediu?.ZileRamase ?? 0;
		}

		public async Task<int> GetZileTotaleAnualeAsync(int angajatId)
		{
			var concediu = await GetConcediuForAngajatAsync(angajatId);
			return concediu?.ZileTotaleAnuale ?? 0;
		}

		public async Task UpdateCerereConcediuAsync(CerereConcediu cerereConcediu)
		{
			var existingCerere = await _context.CereriConcediu.FindAsync(cerereConcediu.Id);
			if (existingCerere == null)
			{
				throw new KeyNotFoundException($"Cererea de concediu cu ID-ul {cerereConcediu.Id} nu a fost găsită.");
			}

			_context.Entry(existingCerere).CurrentValues.SetValues(cerereConcediu);
			await _context.SaveChangesAsync();
		}
	}
}