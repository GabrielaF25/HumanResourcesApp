using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Angajat
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	[MaxLength(100)]
	public string Nume { get; set; }

	[Required]
	[MaxLength(100)]
	public string Prenume { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	public string Pozitie { get; set; }

	public DateTime DataAngajarii { get; set; }

	// Relația cu CereriConcediu
	public ICollection<CerereConcediu> CereriConcediu { get; set; }=new List<CerereConcediu>();

	// Relația cu Evaluari
	public ICollection<Evaluare> Evaluari { get; set; } = new List<Evaluare>();

	// Relația cu Documente
	public ICollection<Document> Documente { get; set; } = new List<Document>();
}