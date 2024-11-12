namespace HumanResourcesApp.Models
{
	public class EvaluareDTO
	{
		public int Id { get; set; }
		public int Scor { get; set; }
		public string Comentariu { get; set; }
		public DateTime DataEvaluare { get; set; }

		// Cheia externă pentru Angajat
		public int AngajatId { get; set; }
	}
}
