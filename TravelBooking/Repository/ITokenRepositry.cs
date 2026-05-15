using Microsoft.AspNetCore.Identity;

namespace TravelBooking.Repository
{
    public interface ITokenRepositry
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
