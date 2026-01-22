using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.AuthDTOs
{
    public class TokenDto:IDto
    {
        public string Token { get; set; }
    }
}
