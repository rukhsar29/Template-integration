using Book.Entities;
using Book.Entities.Interface;
using Books.DTO;
using Books.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository.Implementations
{
    public class UsersRepository : IUsers
    {
        private readonly IEntityUsers _entityUsers;

        public UsersRepository(IEntityUsers entityUsers)
        {
            _entityUsers = entityUsers;
        }

        public async Task<bool> AddNewBook(AddUserParams insert)
        {
            var newuser = new UserDetails()
            {
                FullName = insert.FullName,
                UserEmail = insert.UserEmail,
                IsActive=insert.IsActive
            };
            var result = await _entityUsers.AddNewBook(newuser);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            await _entityUsers.Delete(id);
            return true;
        }

        public async Task<List<Users>> GetUserDetails()
        {
            var userListDTO = new List<Users>();
            var usersList = await _entityUsers.GetUserDetails();


            userListDTO.AddRange(
            usersList.Where(x=>x.IsActive==true).Select(x => new Users
            {
                UserId = x.UserId,
                FullName = x.FullName,
                UserEmail = x.UserEmail
            }).ToList());


            return userListDTO;

        }
        public Users GetEditUser(int id)
        {

            var us =  _entityUsers.GetEditUsers(id);
            var newuser = new Users()
            {
                UserId=us.UserId,
                FullName = us.FullName,
                UserEmail = us.UserEmail
            };
            return newuser;

        }

        public bool PostEditUser(Users users)
        {
            var newuser = new UserDetails()
            {
                UserId =users.UserId,
                FullName = users.FullName,
                UserEmail = users.UserEmail
            };
             _entityUsers.PostEditUser(newuser);
            return true;
        }
    }
}
