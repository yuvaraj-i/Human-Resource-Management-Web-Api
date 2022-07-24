using HumanResourceManagement.Models;

namespace HumanResourceManagement.Interfaces
{
    public interface IJwtTokenManager
    {
        public Token GenerateUserToken(string userName, string role);
    }
}
