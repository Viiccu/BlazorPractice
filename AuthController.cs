using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    IUserService userService;
    //public string? JwtToken { get; private set; }

    public AuthController(IUserService userService) => this.userService = userService;


    [HttpPost("signup")]
    public IActionResult Singup([FromBody] UserLogin user)
    {
        if(!userService.ValidateCredentials(user)) return BadRequest("User credentials invalid"); 

        userService.AddUser(user);
        var token = GenerateJwtToken(user.Username);
        return Ok(new { token });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin user)
    {
        if(!userService.ValidUser(user)) 
        {   
            //Console.WriteLine("forbidden");
            return NoContent();
        }
        var token = GenerateJwtToken(user.Username);  
        //JwtToken = token;  

        Console.WriteLine(token);
        return Ok(new { token });
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, username),
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secure_secret_key_that_is_long_enough"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "vicu",
            audience: "vicu",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}