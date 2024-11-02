using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class HRDbContext : DbContext
{
	public DbSet<Angajat> Angajati { get; set; }
	public DbSet<CerereConcediu> CereriConcediu { get; set; }
	public DbSet<Evaluare> Evaluari { get; set; }
	public DbSet<Document> Documente { get; set; }

	public HRDbContext(DbContextOptions<HRDbContext> options)
	  : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Angajat>()
			.HasMany(a => a.CereriConcediu)
			.WithOne(c => c.Angajat)
			.HasForeignKey(c => c.AngajatId);

		modelBuilder.Entity<Angajat>()
			.HasMany(a => a.Evaluari)
			.WithOne(e => e.Angajat)
			.HasForeignKey(e => e.AngajatId);

		modelBuilder.Entity<Angajat>()
			.HasMany(a => a.Documente)
			.WithOne(d => d.Angajat)
			.HasForeignKey(d => d.AngajatId);
	}
}