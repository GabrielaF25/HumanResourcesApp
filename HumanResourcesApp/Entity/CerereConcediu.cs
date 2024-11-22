using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CerereConcediu
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	
	[Required]
	public DateTime DataInceput { get; set; }

	[Required]
	public DateTime DataSfarsit { get; set; }

	public string Motiv { get; set; }

	[Required]
	public string Status { get; set; } // "Aprobat", "Respins", "In asteptare"

	[ForeignKey("AngajatId")]
	public int AngajatId { get; set; }
	public Angajat? Angajat { get; set; }
}