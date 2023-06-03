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
    public class AlbunsRepositories:RepositorieGenericEntity<Album, int>
    {
        public AlbunsRepositories(MusicasDbContext context):base(context)
        {
            
        }

        public override List<Album> Select()
        {
            return _context.Set<Album>().Include(p=>p.Musicas).ToList();
        }

        public override Album SelectForId(int id)
        {
            return _context.Set<Album>().Include(m => m.Musicas).SingleOrDefault(a => a.Id == id);
        }
    }
}