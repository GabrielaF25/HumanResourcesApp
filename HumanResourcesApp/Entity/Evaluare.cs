using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Evaluare
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[Required]
	public int Scor { get; set; } // Scorul poate fi de la 1 la 10, de exemplu

	public string Comentariu { get; set; }

	public DateTime DataEvaluare { get; set; }

	[ForeignKey("AngajatId")]
	public int AngajatId { get; set; }
	public Angajat? Angajat { get; set; }
}