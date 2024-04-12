using JWP.API.Models;

namespace JWP.API.Repository
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Users user);
    }
}
