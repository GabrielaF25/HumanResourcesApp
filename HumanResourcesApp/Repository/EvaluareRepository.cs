
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesApp.Repository
{
	public class EvaluareRepository : IEvaluareRepository
	{
		private readonly HRDbContext _context;

		public EvaluareRepository(HRDbContext context)
		{
			_context = context;
		}

		public async Task<Evaluare> AddEvaluareAsync(Evaluare evaluare)
		{
			_context.Evaluari.Add(evaluare);
			await _context.SaveChangesAsync();
			return evaluare;
		}

		public async Task DeleteEvaluareAsync(int id)
		{
			var evaluare = await _context.Evaluari.FindAsync(id);
			if (evaluare != null)
			{
				_context.Evaluari.Remove(evaluare);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<bool> EvaluareExistsAsync(int id)
		{
			return await _context.Evaluari.AnyAsync(e => e.Id == id);
		}

		public async Task<IEnumerable<Evaluare>> GetAllEvaluariAsync()
		{
			return await _context.Evaluari.ToListAsync();
		}

		public async Task<Evaluare> GetEvaluareByIdAsync(int id)
		{
			return await _context.Evaluari.FindAsync(id);
		}

		public async Task<IEnumerable<Evaluare>> GetEvaluariByAngajatIdAsync(int angajatId)
		{
			return await _context.Evaluari
		   .Where(e => e.AngajatId == angajatId)
		   .ToListAsync();
		}

		public async Task UpdateEvaluareAsync(Evaluare evaluare)
		{
			var existingEvaluare = await _context.Evaluari.FindAsync(evaluare.Id);
			if (existingEvaluare != null)
			{
				_context.Entry(existingEvaluare).CurrentValues.SetValues(evaluare);
				await _context.SaveChangesAsync();
			}
		}
	}
}
