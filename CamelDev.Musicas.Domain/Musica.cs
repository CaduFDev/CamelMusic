using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Musicas.Domain
{
    public class Musica
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }

        public virtual Album Album { get; set; }
        public int IdAlbum { get; set; }
    }
}

