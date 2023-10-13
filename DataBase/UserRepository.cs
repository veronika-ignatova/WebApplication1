﻿using Core.Interface;
using Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class UserRepository : IUserRepository
    {
        protected readonly MyDbContext _myDbContext;
        public UserRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        private IUser CastToIUser(Models.User user)
        {
            if (user == null) return null;
            return new Core.Entities.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                CreateDate = user.CreateDate,
                Password = user.Password,
                Address = CastToIAddress(user.Address)
            };
        }

        private IAddress? CastToIAddress(Models.Address? address)
        {
            if (address == null) return null;
            return new Core.Entities.Address
            {
                City = address.City,
                Country = address.Country,
                Id = address.Id,
                Index = address.Index,
                Street = address.Street
            };
        }

        public IUser GetUserById(Guid id)
        {
            var users = _myDbContext.Users;
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return CastToIUser(user);
                }
            }
            return null;
        }

        public bool CreateUser(IUser user)
        {
            try
            {
                _myDbContext.Users.Add(new Models.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                    CreateDate = user.CreateDate,
                    Password = user.Password
                });
                _myDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IUser GetUserByEmail(string email)
        {
            var users = _myDbContext.Users;
            foreach (var user in users)
            {
                if(user.Email.ToLower() == email.ToLower())
                {
                    return CastToIUser(user);
                }
            }
            return null;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            var users = _myDbContext.Users.Include(x => x.Address);

            List<IUser> list = new ();
            foreach (var user in users)
            {
                if(user != null) list.Add(CastToIUser(user));
            }
            return list;
        }
    }
}
