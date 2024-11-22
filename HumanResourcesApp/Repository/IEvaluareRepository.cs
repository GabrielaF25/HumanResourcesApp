namespace HumanResourcesApp.Repository
{
	public interface IEvaluareRepository
	{
		Task<IEnumerable<Evaluare>> GetAllEvaluariAsync();

		// Obține evaluările pentru un angajat
		Task<IEnumerable<Evaluare>> GetEvaluariByAngajatIdAsync(int angajatId);

		// Obține o evaluare specifică
		Task<Evaluare> GetEvaluareByIdAsync(int id);

		// Adaugă o nouă evaluare
		Task<Evaluare> AddEvaluareAsync(Evaluare evaluare);

		// Actualizează o evaluare existentă
		Task UpdateEvaluareAsync(Evaluare evaluare);

		// Șterge o evaluare după ID
		Task DeleteEvaluareAsync(int id);

		// Verifică dacă o evaluare există
		Task<bool> EvaluareExistsAsync(int id);
	}
}
