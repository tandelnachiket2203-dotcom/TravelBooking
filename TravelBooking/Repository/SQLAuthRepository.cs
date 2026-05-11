using TravelBooking.Data;
using TravelBooking.Models.DTO;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Models.Domains;

namespace TravelBooking.Repository
{
    public class SQLAuthRepository : IAuthRepository
    {
        public SQLAuthRepository(TravellBokkingDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public TravellBokkingDBContext DbContext { get; }

        public async Task<UserLoginDTO> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            var user=await DbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == userLoginDTO.Email.ToLower() && u.Password == userLoginDTO.Password);
            if(user==null)
            {
                return null;
            }
      bool validPassword = user.Password == userLoginDTO.Password;
            if (!validPassword)
            {
                return null;
            }   
    return userLoginDTO; 
        
        }

        public async Task<UserRegisterDTO> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
        {
            var user=new User
            {
                Email=userRegisterDTO.Email,
                FristName=userRegisterDTO.FirstName,
                LastName=userRegisterDTO.LastName,
                Password=userRegisterDTO.Password,
                Phone=userRegisterDTO.Phone,
                CreatedAt=DateTime.UtcNow,
                LastUpdatedAt=DateTime.UtcNow
            
            };
            DbContext.Users.Add(user);
            await DbContext.SaveChangesAsync();
            return userRegisterDTO;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var userExists = await DbContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
            return userExists;
        }
    }
}