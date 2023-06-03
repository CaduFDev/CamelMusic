using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamelDev.Musicas.Web.Annotations
{
    public class EmailCamelDevAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString().EndsWith("@cameldev.com.br");
        }
        
    }    
}