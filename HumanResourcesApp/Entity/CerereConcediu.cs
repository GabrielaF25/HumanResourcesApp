using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CerereConcediu
{
	[Key]
	public int Id { get; set; }
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Required]
	public DateTime DataInceput { get; set; }

	[Required]
	public DateTime DataSfarsit { get; set; }

	public string Motiv { get; set; }

	[Required]
	public string Status { get; set; } // "Aprobat", "Respins", "In asteptare"

	// Foreign Key pentru Angajat
	public int AngajatId { get; set; }
	public Angajat? Angajat { get; set; }
}