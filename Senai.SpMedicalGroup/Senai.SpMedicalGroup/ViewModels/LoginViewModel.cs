using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A senha deve ter entre 3 e 100 caracteres")]
        public string Senha { get; set; }
    }
}
