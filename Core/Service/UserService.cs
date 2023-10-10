using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IUser GetUserById(Guid id)
        {
            return userRepository.GetUserById(id);
            //var user = userRepository.GetUserById(id);
            //if(user is User)
            //{
            //    return user as User;
            //}
            //else
            //{
            //    return new User()
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        Age = user.Age,
            //        CreateDate = user.CreateDate,
            //        Email = user.Email,
            //        Password = user.Password,
            //    };
            //}
        }
        public bool CreateUser(IUser user)
        {
            user.Id = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            return userRepository.CreateUser(user);
        }

    }
}
