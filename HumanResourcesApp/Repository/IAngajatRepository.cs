using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAngajatRepository
{
	Task<IEnumerable<Angajat>> GetAllAngajatiAsync();
	Task<Angajat> GetAngajatByIdAsync(int id);
	Task AddAngajatAsync(Angajat angajat);
	Task UpdateAngajatAsync(Angajat angajat);
	Task DeleteAngajatAsync(int id);
	Task<bool> AngajatExistsAsync(int id);
}