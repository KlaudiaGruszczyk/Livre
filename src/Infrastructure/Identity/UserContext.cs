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

    public string GetUserId()
    {
        var authHeader = httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            throw new Exception("Invalid Authorization header");
        }

        var token = authHeader.Substring("Bearer ".Length);

        var handler = new JwtSecurityTokenHandler();
        var decodedToken = handler.ReadJwtToken(token);

        UserId = decodedToken.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
        return UserId;
    }
}