namespace HumanResourcesApp.Models
{
	public class DocumentDTO
	{
		public int Id { get; set; }

		public string Nume { get; set; }

		public string TipDocument { get; set; }

		public DateTime DataIncarcare { get; set; }

		// Cheia externă pentru Angajat
		public int AngajatId { get; set; }
	}
}
