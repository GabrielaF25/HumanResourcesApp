using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class AngajatRepository : IAngajatRepository
{
	private readonly HRDbContext _context;

	public AngajatRepository(HRDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Angajat>> GetAllAngajatiAsync()
	{
		return await _context.Angajati
			.Include(a => a.CereriConcediu)   // Include CereriConcediu
			.Include(a => a.Evaluari)          // Include Evaluari
			.Include(a => a.Documente)         // Include Documente
			.ToListAsync();
	}

	public async Task<Angajat> GetAngajatByIdAsync(int id)
	{
		return await _context.Angajati
	   .Include(a => a.Documente)         // Include Documente
	   .Include(a => a.CereriConcediu)   // Include CereriConcediu
	   .Include(a => a.Evaluari)          // Include Evaluari
	   .FirstOrDefaultAsync(a => a.Id == id);
	}

	public async Task<Angajat> CreateAngajatAsync(Angajat angajat)
	{
			// Salvează mai întâi angajatul pentru a-i genera Id-ul
			_context.Angajati.Add(angajat);
			await _context.SaveChangesAsync(); // Acum angajat.Id este disponibil
			return angajat;
		

	}

	public async Task UpdateAngajatAsync(Angajat angajat)
	{
		var existingAngajat = await _context.Angajati
	   .Include(a => a.Evaluari)
	   .Include(a => a.CereriConcediu)
	   .Include(a => a.Documente)
	   .FirstOrDefaultAsync(a => a.Id == angajat.Id);


		// Actualizează proprietățile simple
		_context.Entry(existingAngajat).CurrentValues.SetValues(angajat);

		// Gestionarea Evaluărilor
		foreach (var evaluare in angajat.Evaluari)
		{
			var existingEvaluare = existingAngajat.Evaluari.FirstOrDefault(e => e.Id == evaluare.Id);

			if (existingEvaluare == null)
			{
				// Dacă evaluarea nu există, adaug-o
				existingAngajat.Evaluari.Add(evaluare);
			}
			else
			{
				// Dacă există, actualizează valorile
				_context.Entry(existingEvaluare).CurrentValues.SetValues(evaluare);
			}
		}


		// Similar pentru CereriConcediu
		foreach (var cerere in angajat.CereriConcediu)
		{
			var existingCerere = existingAngajat.CereriConcediu.FirstOrDefault(c => c.Id == cerere.Id);

			if (existingCerere == null)
			{
				existingAngajat.CereriConcediu.Add(cerere);
			}
			else
			{
				_context.Entry(existingCerere).CurrentValues.SetValues(cerere);
			}
		}

		// Similar pentru Documente
		foreach (var document in angajat.Documente)
		{
			var existingDocument = existingAngajat.Documente.FirstOrDefault(d => d.Id == document.Id);

			if (existingDocument == null)
			{
				existingAngajat.Documente.Add(document);
			}
			else
			{
				_context.Entry(existingDocument).CurrentValues.SetValues(document);
			}
		}

		await _context.SaveChangesAsync();
	}

	public async Task DeleteAngajatAsync(int id)
	{
		var angajat = await _context.Angajati.FindAsync(id);
		if (angajat != null)
		{
			// Șterge angajatul din baza de date
			_context.Angajati.Remove(angajat);
			await _context.SaveChangesAsync();

			// Resetează autoincrementul
			using (var connection = _context.Database.GetDbConnection())
			{
				await connection.OpenAsync();

				try
				{
					// Găsește valoarea maximă a ID-ului curent în tabel
					var getMaxIdCommand = connection.CreateCommand();
					getMaxIdCommand.CommandText = "SELECT IFNULL(MAX(Id), 0) FROM Angajati";
					var maxId = Convert.ToInt32(await getMaxIdCommand.ExecuteScalarAsync()); // Conversie sigură

					// Actualizează secvența în sqlite_sequence
					var resetCommand = connection.CreateCommand();
					resetCommand.CommandText = $"UPDATE sqlite_sequence SET seq = {maxId} WHERE name = 'Angajati'";
					await resetCommand.ExecuteNonQueryAsync();
				}
				catch (Exception ex)
				{
					// Opțional: loghează eroarea pentru debugging
					Console.WriteLine($"Eroare la resetarea secvenței: {ex.Message}");
					throw;
				}
			}
		}
		else
		{
			throw new KeyNotFoundException($"Angajatul cu ID-ul {id} nu a fost găsit.");
		}
	}




	public async Task<bool> AngajatExistsAsync(int id)
	{
		return await _context.Angajati.AnyAsync(e => e.Id == id);
	}
}