using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o campo de usuário.")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Preencha o campo de senha.")]
        [DataType(DataType.Password,ErrorMessage = "A senha deve conter caracteres minusculos e maiusculos, um caractere especial e numeros.")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
