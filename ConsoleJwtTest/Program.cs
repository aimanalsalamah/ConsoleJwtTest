using System.Security.Claims;

var jwt = Console.ReadLine();
if(!string.IsNullOrEmpty(jwt))
{
    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    var tokens = handler.ReadToken(jwt) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
    foreach (var token in tokens.Claims)
    {
        Console.WriteLine($"Type:{token.Type}, Value:{token.Value}");
    }
    var user = new ClaimsPrincipal(new ClaimsIdentity(tokens.Claims, "Auth"));
    var username = user.FindFirst(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub).Value;
}