
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
				// Șterge evaluarea din baza de date
				_context.Evaluari.Remove(evaluare);
				await _context.SaveChangesAsync();

				// Resetează autoincrementul
				using (var connection = _context.Database.GetDbConnection())
				{
					await connection.OpenAsync();

					// Găsește valoarea maximă a ID-ului curent în tabel
					var getMaxIdCommand = connection.CreateCommand();
					getMaxIdCommand.CommandText = "SELECT IFNULL(MAX(Id), 0) FROM Evaluari";
					var maxId = Convert.ToInt32(await getMaxIdCommand.ExecuteScalarAsync()); // Conversie sigură

					// Actualizează secvența în sqlite_sequence
					var resetCommand = connection.CreateCommand();
					resetCommand.CommandText = $"UPDATE sqlite_sequence SET seq = {maxId} WHERE name = 'Evaluari'";
					await resetCommand.ExecuteNonQueryAsync();
				}
			}
			else
			{
				throw new KeyNotFoundException($"Evaluarea cu ID-ul {id} nu a fost găsită.");
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
