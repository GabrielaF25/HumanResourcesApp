using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		return await _context.Angajati.ToListAsync();
	}

	public async Task<Angajat> GetAngajatByIdAsync(int id)
	{
		return await _context.Angajati.FindAsync(id);
	}

	public async Task<Angajat> CreateAngajatAsync(Angajat angajat)
	{
		if (angajat.CereriConcediu != null)
		{
			foreach (var cerere in angajat.CereriConcediu)
			{
				_context.CereriConcediu.Add(cerere);
			}
		}

		if (angajat.Evaluari != null)
		{
			foreach (var evaluare in angajat.Evaluari)
			{
				_context.Evaluari.Add(evaluare);
			}
		}

		if (angajat.Documente != null)
		{
			foreach (var document in angajat.Documente)
			{
				_context.Documente.Add(document);
			}
		}

		_context.Angajati.Add(angajat);
		
		await _context.SaveChangesAsync();
		return angajat;

	}

	public async Task UpdateAngajatAsync(Angajat angajat)
	{
		_context.Entry(angajat).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAngajatAsync(int id)
	{
		var angajat = await _context.Angajati.FindAsync(id);
		if (angajat != null)
		{
			_context.Angajati.Remove(angajat);
			await _context.SaveChangesAsync();
		}
	}

	public async Task<bool> AngajatExistsAsync(int id)
	{
		return await _context.Angajati.AnyAsync(e => e.Id == id);
	}
}