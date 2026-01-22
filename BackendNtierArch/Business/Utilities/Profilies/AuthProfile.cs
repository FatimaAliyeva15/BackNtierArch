using AutoMapper;
using Core.Entities.Concrete;
using Entities.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profilies
{
    public class AuthProfile: Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
