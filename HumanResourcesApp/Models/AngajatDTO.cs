using System.ComponentModel.DataAnnotations;

namespace HumanResourcesApp.Models
{
	public class AngajatDTO
	{
		public int Id { get; set; }

		[Required]
		public string Nume { get; set; }

		[Required]
		public string Prenume { get; set; }

		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		public DateTime DataAngajare { get; set; }

		public string Departament { get; set; } = string.Empty;
	}
}
