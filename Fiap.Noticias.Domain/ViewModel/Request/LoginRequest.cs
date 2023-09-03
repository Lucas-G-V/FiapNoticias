﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.ViewModel.Request
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
