using System.IdentityModel.Tokens.Jwt;

namespace backend.Utils;

public class JwtUtils
{
    public static int ExtractUserIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        var userIdClaim = jsonToken?.Claims.First(claim => claim.Type == "nameid").Value;

        if (userIdClaim != null)
        {
            var userId = int.Parse(userIdClaim);
            return userId;
        }

        return -1;
    }
}