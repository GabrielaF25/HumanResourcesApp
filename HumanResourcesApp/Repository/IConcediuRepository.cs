using HumanResourcesApp.Models;

namespace HumanResourcesApp.Repository
{
	public interface IConcediuRepository
	{
		
		Task<Concediu> GetConcediuForAngajatAsync(int angajatId);

		
		Task<int> GetZileTotaleAnualeAsync(int angajatId);

		
		Task<int> GetZileConsumateAsync(int angajatId);

		
		Task<int> GetZileRamaseAsync(int angajatId);

		Task<IEnumerable<CerereConcediu>> GetCereriAprobateAsync(int angajatId);
		Task<IEnumerable<CerereConcediu>> GetToateCereriAprobateAsync();

		Task<CerereConcediu> AddCerereConcediuAsync(int angajatId, CerereConcediu cerereConcediu);

		Task UpdateCerereConcediuAsync(CerereConcediu cerereConcediu);

		Task DeleteCerereConcediuAsync(int cerereId);

	}
}
