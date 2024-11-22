namespace HumanResourcesApp.Models
{
	public class Concediu
	{
		public int AngajatId { get; set; } // Legătură logică cu angajatul

		public DateTime DataAngajarii { get; set; } // Data angajării angajatului

		public List<CerereConcediu> CereriConcediu { get; set; } = new List<CerereConcediu>();

		// Proporționalitatea zilelor de concediu
		public int ZileTotaleAnuale
		{
			get
			{
				const int ZileMaxConcediuAnuale = 21; // Zilele maxime de concediu pe an
				var acum = DateTime.Now;

				// Dacă angajatul s-a angajat în alt an, primește 21 de zile
				if (DataAngajarii.Year < acum.Year)
				{
					return ZileMaxConcediuAnuale;
				}

				// Dacă angajatul este angajat în anul curent, calculează proporțional
				int luniLucrate = Math.Max(0, 12 - DataAngajarii.Month + 1); // Lunile rămase din anul curent
				return (int)Math.Round((double)ZileMaxConcediuAnuale * luniLucrate / 12, MidpointRounding.AwayFromZero);
			}
		}

		// Zile consumate din cereri aprobate
		public int ZileConsumate => CereriConcediu
			.Where(c => c.Status == "Aprobat")
			.Sum(c => (int)(c.DataSfarsit - c.DataInceput).TotalDays + 1);

		// Zile rămase
		public int ZileRamase => ZileTotaleAnuale - ZileConsumate;
	}
}
