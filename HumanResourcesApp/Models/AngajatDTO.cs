using System.ComponentModel.DataAnnotations;

namespace HumanResourcesApp.Models
{
	public class AngajatDTO
	{
		public int Id { get; set; }
		public string Nume { get; set; }
		public string Prenume { get; set; }
		public string Email { get; set; }
		public string Pozitie { get; set; }
		public DateTime DataAngajarii { get; set; }

		// Relații cu entitățile copil
		public ICollection<CerereConcediuDTO> CereriConcediu { get; set; } = new List<CerereConcediuDTO>();
		public ICollection<EvaluareDTO> Evaluari { get; set; } = new List<EvaluareDTO>();
		public ICollection<DocumentDTO> Documente { get; set; } = new List<DocumentDTO>();
	}

}