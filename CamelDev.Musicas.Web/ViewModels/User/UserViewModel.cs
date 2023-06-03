using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.ViewModels.User
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="E-mail é obrigatório")]
        [MaxLength(100,ErrorMessage ="O E-mail não pode ter mais que 100 caractéres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}