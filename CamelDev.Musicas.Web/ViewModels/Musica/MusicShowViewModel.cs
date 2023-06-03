using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.ViewModels.Musica
{
    public class MusicShowViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da musica")]
        public string Name { get; set; }

        [Display(Name ="Letra da música")]
        public string Lyrics { get; set; }
        
        [Display(Name ="Nome do album")]
        public string NameAlbum { get; set; }
        
    }
}