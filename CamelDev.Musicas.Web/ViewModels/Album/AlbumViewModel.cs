using CamelDev.Musicas.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CamelDev.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage ="O ID do album é necesário")]
        public int Id { get; set; }

        [Display(Name = "YEAR")]
        public int Year { get; set; }

        [Required(ErrorMessage ="É necessário inserir um nome ao album")]
        [Display(Name = "TITLE")]
        public string Title { get; set; }

        [MaxLength(500,ErrorMessage ="Não pode ultrapassar os 500 caractéres")]
        [Display(Name = "DESCRIPTION")]
        public string Description { get; set; }

        [Required(ErrorMessage ="É Necessário inserir um E-Mail.")]
        [DataType(DataType.EmailAddress)]
        [EmailCamelDev(ErrorMessage ="O E-mail, tem que ser da CamelDev.")]
        [Display(Name = "E-MAIL")]
        public string Email { get; set; }
    }
}