using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Entities.Interface
{
    public interface IEntityUsers
    {
        Task<List<UserDetails>> GetUserDetails();
        Task<bool> AddNewBook(UserDetails userDetails);
        Task<bool> Delete(int id);
        UserDetails GetEditUsers(int id);
        bool PostEditUser(UserDetails userDetails);
    }
}
