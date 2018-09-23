using System.Collections.Generic;

namespace Online_Store.Core.Services.User
{
    public interface IUserService
    {
        string GeneratePasswordHash(string password);

        bool ValidateCredentials(string username, string password);

        bool CheckUsername(string username);

        bool IsUserLogged();

        string AddToCart(IList<string> parameters);
    }
}
