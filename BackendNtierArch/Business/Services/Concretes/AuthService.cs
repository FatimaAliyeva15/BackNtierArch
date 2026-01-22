using AutoMapper;
using Business.Services.Abstracts;
using Core.Business.Utilities.Results.Abstracts;
using Core.Business.Utilities.Results.Concretes;
using Core.Entities.Concrete;
using Entities.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services.Concretes
{
    public class AuthService: IAuthSercive
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenOption _tokenOption;

        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _config = config;
            _tokenOption = _config.GetSection("TokenOptions").Get<TokenOption>();
        }

        public async Task<IResult> Register(RegisterDto register)
        {
            var user = _mapper.Map<AppUser>(register);
            var resultUser = await _userManager.CreateAsync(user, register.Password);
            if (!resultUser.Succeeded)
            {

                return new ErrorResult("Register olunmadi");

            }

            await _roleManager.CreateAsync(new IdentityRole("User"));

            var resultRole = await _userManager.AddToRoleAsync(user, "User");
            if (!resultRole.Succeeded)
            {
                return new ErrorResult("Rol artiq yaradilib");
            }

            return new SuccessResult("Ugurla qeydiyyat olundunuz");
        }

        public async Task<IDataResult<TokenDto>> Login(LoginDto login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.UserName);
            if (user is null)
            {
                return new ErrorDataResult<TokenDto>("Istifadecci tapilmadii");
            }
            bool isValidPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!isValidPassword)
            {
                return new ErrorDataResult<TokenDto>("Token yaradilmadi");
            }
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            JwtHeader header = new JwtHeader(signingCredentials);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("FullName",user.Email)
            };
            foreach (var userRole in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            JwtPayload payload = new JwtPayload(audience: _tokenOption.Audience, issuer: _tokenOption.Issuer, claims: claims, expires: DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration), notBefore: DateTime.UtcNow);
            JwtSecurityToken token = new JwtSecurityToken(header, payload);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string jwt = tokenHandler.WriteToken(token);
            TokenDto dto = new TokenDto();
            dto.Token = jwt;

            return new SuccessDataResult<TokenDto>(dto, "fsf");
        }

        public async Task<IResult> AddAdmin(RegisterDto register)
        {
            var admin = _mapper.Map<AppUser>(register);

            var result = await _userManager.CreateAsync(admin, register.Password);
            if (!result.Succeeded)
                return new ErrorResult(result.Errors.ToString());

            await _userManager.AddToRoleAsync(admin, "Admin");
            return new SuccessResult();
        }
    }
}
