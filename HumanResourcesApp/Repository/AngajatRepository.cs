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

	public async Task AddAngajatAsync(Angajat angajat)
	{
		_context.Angajati.Add(angajat);
		await _context.SaveChangesAsync();
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