using FreelApp.Application.InputModels;
using FreelApp.Application.Services.Interfaces;
using FreelApp.Application.ViewModels;
using FreelApp.Core.Entities;
using FreelApp.Infraestructure.Persistence;

namespace FreelApp.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly FreelAppDbContext _dbContext;
        public UserService(FreelAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName,inputModel.Email,inputModel.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
        public List<UserViewModel> GetAll(string query)
            => _dbContext.Users.Select(u => new UserViewModel(u.Id, u.FullName,u.Email,u.BirthDate,u.CreatedAt,u.Active)).ToList();


    }
}
