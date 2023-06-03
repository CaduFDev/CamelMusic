using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Musicas.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }        
        public string Description { get; set; }        
        public string Email { get; set; }

        public virtual List<Musica> Musicas { get; set; }
    }
}