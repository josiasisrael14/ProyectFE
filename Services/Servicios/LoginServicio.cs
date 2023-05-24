using Domain;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Servicios
{
    public class LoginServicio : InterfazLogin
    {
        protected readonly ProyectDbContext _context;
        private readonly IConfiguration _config;
        public LoginServicio(ProyectDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public User GetUsersByIdentificador(User data)
        {
            try
            {
                var validardatos = _context.Users.FirstOrDefault(x => x.Username.ToLower() == data.Username.ToLower() && x.Userpass == data.Userpass && x.State == "A");

                if (validardatos != null)
                {
                    return validardatos;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public string generartoken(User data)
        {

            try
            {
                string? nameuser = data.Username;
                int user = data.IdUser;
                string USUString = user.ToString();
                int sucursal = data.IdBranchOffice;
                string rollString = sucursal.ToString();

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim("USERNAME", nameuser),
                    new Claim("ID_USUARIO", USUString),
                    new Claim("ID_ROLL", rollString),
                };

                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            catch (Exception)
            {
                throw;
            }
        }


    }
}
