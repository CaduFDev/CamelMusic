using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.ViewModels.Album
{
    public class AlbumShowViewModel
    {   
        public int Id { get; set; }

        [Display(Name = "YEAR")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "TITLE")]
        public string Title { get; set; }

        [MaxLength(500)]
        [Display(Name = "DESCRIPTION")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-MAIL")]
        public string Email { get; set; }
    }
}