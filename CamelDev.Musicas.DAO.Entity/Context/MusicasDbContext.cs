using CamelDev.Musicas.DAO.Entity.TypeConfiguration;
using CamelDev.Musicas.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Musicas.DAO.Entity.Context
{
    public class MusicasDbContext : DbContext
    {        
        public MusicasDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Musica> Musica { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new MusicaTypeConfiguration());
        }
    }
}
