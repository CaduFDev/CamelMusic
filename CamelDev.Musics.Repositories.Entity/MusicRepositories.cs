using CamelDev.Musicas.DAO.Entity.Context;
using CamelDev.Musicas.Domain;
using CamelDev.Repositories.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CamelDev.Musics.Repositories.Entity
{
    public class MusicRepositories : RepositorieGenericEntity<Musica, long>
    {
        public MusicRepositories(MusicasDbContext musicasDbContext) : base (musicasDbContext)
        { 
            
        }

        public override List<Musica> Select()
        {
            return _context.Set<Musica>().Include(p=>p.Album).ToList();
        }
        public override Musica SelectForId(long id)
        {
            return _context.Set<Musica>().Include(p => p.Album).SingleOrDefault(p=>p.Id == id);
        }
    }
}
