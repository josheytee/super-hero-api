using System;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
	public class DataContext: DbContext
	{
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            //SuperHeroes = superHeroes;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
	}
}

