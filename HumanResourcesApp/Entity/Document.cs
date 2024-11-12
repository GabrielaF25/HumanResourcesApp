using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Document
{
	[Key]
	public int Id { get; set; }
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

	[Required]
	[MaxLength(200)]
	public string Nume { get; set; }

	public string TipDocument { get; set; } = string.Empty; // Ex: "Contract", "Certificat", etc.

	public DateTime DataIncarcare { get; set; }


	[ForeignKey("AngajatId")]
	public int AngajatId { get; set; }
	public Angajat? Angajat { get; set; }
}