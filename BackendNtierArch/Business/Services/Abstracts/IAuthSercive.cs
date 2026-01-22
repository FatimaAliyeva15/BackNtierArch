using Core.Business.Utilities.Results.Abstracts;
using Entities.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstracts
{
    public interface IAuthSercive
    {
        public Task<IResult> Register(RegisterDto register);
        public Task<IDataResult<TokenDto>> Login(LoginDto login);
        public Task<IResult> AddAdmin(RegisterDto register);
    }
}
