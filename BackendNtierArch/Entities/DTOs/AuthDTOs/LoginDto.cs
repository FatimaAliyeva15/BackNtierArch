using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.AuthDTOs
{
    public class LoginDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
