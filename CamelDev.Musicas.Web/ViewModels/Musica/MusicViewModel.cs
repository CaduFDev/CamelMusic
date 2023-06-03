using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.ViewModels.Musica
{
    public class MusicViewModel
    {
        [Required(ErrorMessage ="O ID é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage ="É Necessário inserir um nome")]
        [MaxLength(100, ErrorMessage ="Excedeu o limite de 100 caractéres!")]
        [Display(Name ="Nome da musica")]
        public string Name { get; set; }

        [Display(Name = "Letra")]
        public string Lyrics { get; set; }

        [Required(ErrorMessage = "Selecione um album válido.")]
        [Display(Name = "Nome do album")]
        public int IdAlbum { get; set; }
    }
}