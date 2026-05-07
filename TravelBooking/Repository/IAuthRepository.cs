
using TravelBooking.Models.DTO;

namespace TravelBooking.Repository
{
    public interface IAuthRepository
    {
        public Task<bool> UserExistsAsync(string email);
        public Task<UserRegisterDTO> RegisterUserAsync(UserRegisterDTO userRegisterDTO);

        public Task<UserLoginDTO> LoginUserAsync(UserLoginDTO userLoginDTO);
    }
}