using Book.Entities;
using Books.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Repository.Interface
{
    public interface IUsers
    {
        Task<List<Users>> GetUserDetails();
        Task<bool> AddNewBook(AddUserParams insert);
        Task<bool> Delete(int id);
        Users GetEditUser(int id);
        bool PostEditUser(Users users);
    }
}
