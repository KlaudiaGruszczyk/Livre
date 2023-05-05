using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string UserId { get; set; }
    public string Login { get; set; }

    public string GetUserId()
    {
        var authHeader = httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            throw new Exception("Invalid Authorization header");
        }

        var token = authHeader.Substring("Bearer ".Length);

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken decodedToken;
        try
        {
            decodedToken = handler.ReadJwtToken(token);
        }
        catch (Exception)
        {
            throw new Exception("Invalid JWT token");
        }

        var userIdClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "Id");
        if (userIdClaim == null)
        {
            throw new Exception("Invalid JWT token");
        }

        return userIdClaim.Value;
    }

    public string GetLogin()
    {
        var authHeader = httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            throw new Exception("Invalid Authorization header");
        }

        var token = authHeader.Substring("Bearer ".Length);

        var handler = new JwtSecurityTokenHandler();
        var decodedToken = handler.ReadJwtToken(token);

        Login = decodedToken.Claims.FirstOrDefault(c => c.Type == "Login")?.Value; 
        return Login;
    }
}