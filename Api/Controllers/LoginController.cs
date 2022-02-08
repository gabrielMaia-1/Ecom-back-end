using Api.Commons.Models.Dtos;
using Api.Models.Responses;
using Application.Common.Interfaces.Repositories;
using Application.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public  ActionResult AuthenticateAsync([FromBody] UsuarioDto dto, [FromServices] IUsuarioRepository repo)
        {
            var user = repo.GetUser(dto.Username, dto.Password);

            if (user is null) return NotFound(new { message = "Usuário não encontrado." });
            
            return Ok(new LoginResponse { Username = user.Username, Token = TokenService.GenerateToken(user) });
        }


        [HttpGet]
        [Route("anom")]
        [AllowAnonymous]
        public ActionResult<string> TestAnom()
        {
            return Ok(User.Identity.Name);
        }

        [HttpGet]
        [Route("auth")]
        [Authorize(Roles = "modasfoca")]
        public ActionResult<string> TestAuth()
        {
            return Ok(User.Identity.Name);
        }
    }
}
