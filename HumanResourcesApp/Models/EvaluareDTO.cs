namespace HumanResourcesApp.Models
{
	public class EvaluareDTO
	{
		public int Id { get; set; }

		public int Scor { get; set; }

		public string TipEvaluare { get; set; }

		public string FeedbackDetaliat
		{
			get
			{
				if (Scor < 50 && Scor >0) return "Performanța este sub standarde. Se recomandă îmbunătățiri.";
				if (Scor >= 50 && Scor < 70) return "Performanță acceptabilă, dar există loc de îmbunătățire.";
				if (Scor == 0) return "Nu s-au facut evaluari";
				return "Performanță satisfăcătoare.";
			}
		}

		public string Performanta
		{
			get
			{
				if (Scor >= 90) return "Excelent";
				if (Scor >= 70) return "Bun";
				if (Scor >= 50) return "Mediu";
				if (Scor == 0) return "Fără evaluări";
				return "Slab";
			}
		}

		public string Comentariu { get; set; }

		public DateTime DataEvaluare { get; set; }

		// Cheia externă pentru Angajat
		public int AngajatId { get; set; }
	}
}
