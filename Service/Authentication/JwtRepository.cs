using Common.ApiResult;
using Common.Setting;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Service.Authentication
{
    public class JwtRepository : IJwtRepository
    {
        private readonly SecuritySetting _siteSetting;
        //private readonly UserManager<User> _userManager;

        public JwtRepository(IOptions<SecuritySetting> options /*UserManager<User> userManager*/)
        {
            _siteSetting = options.Value;
            //_userManager = userManager;
        }
        public ResponseAccount CreateToken(UserDto userDto)
        {
            try
            {
                var secretKey = Encoding.UTF8.GetBytes(_siteSetting.SecretKey);
                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
                var keyEncrypting = Encoding.UTF8.GetBytes(_siteSetting.Encryptkey);
                var securityKeyEncryp = new SymmetricSecurityKey(keyEncrypting);
                var _EncryptingCredentials = new EncryptingCredentials(securityKeyEncryp, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);
                var Claims = GetClaims(userDto);
                var DesCriptor = new SecurityTokenDescriptor
                {
                    Issuer = _siteSetting.Issuer,
                    Audience = _siteSetting.Audience,
                    IssuedAt = DateTime.Now,
                    NotBefore = DateTime.Now.AddMinutes(_siteSetting.NotBefore),
                    Expires = DateTime.Now.AddMinutes(_siteSetting.Expires),
                    SigningCredentials = signingCredentials,
                    Subject = new ClaimsIdentity(Claims),
                    EncryptingCredentials = _EncryptingCredentials
                };
                var TokenHandlers = new JwtSecurityTokenHandler();
                var SecurityToken = TokenHandlers.CreateToken(DesCriptor);
                var JwtToken = TokenHandlers.WriteToken(SecurityToken);
                List<string> Roles = new List<string>();
                foreach (var item in Claims.ToList())
                {
                    if (item.Type == ClaimTypes.Role)
                    {
                        Roles.Add(item.Value);
                    }
                }
                return new ResponseAccount
                {
                    Token = JwtToken,
                    Roles = Roles
                };
            }
            catch (Exception)
            {
                throw new Exception(EnumExtensions.GetEnumDescription(ResponseStatus.ServerError));
            }
        }
        private IEnumerable<Claim> GetClaims(UserDto userDto)
        {
            //var roles = _userManager.GetRolesAsync(userAccountDto).Result;
            var ListCliams = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"test")
            };

            //if (roles == null)
            //{
            //    foreach (var item in roles)
            //    {
            //        ListCliams.Add(ClaimTypes.Role, item.ToString());
            //    }
            //}

            return ListCliams;
        }

    }
}
