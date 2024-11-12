namespace HumanResourcesApp.Models
{
	public class CerereConcediuDTO
	{
		public int Id { get; set; }
		public DateTime DataInceput { get; set; }
		public DateTime DataSfarsit { get; set; }
		public string Motiv { get; set; }
		public string Status { get; set; }

		// Cheia externă pentru Angajat
		public int AngajatId { get; set; }
	}
}
