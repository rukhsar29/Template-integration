using Book.Entities.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Entities.Implementations
{
    public class EntityUsers : IEntityUsers
    {
        private readonly traffictraineesContext _context;

        public EntityUsers(traffictraineesContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewBook(UserDetails userDetails)
        {
            await _context.UserDetails.AddAsync(userDetails);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var viewModel =await  _context.UserDetails.Where(x => x.UserId == id).SingleOrDefaultAsync();
            viewModel.IsActive = false;
            _context.Entry(viewModel).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public UserDetails GetEditUsers(int id)
        {
            var v =_context.UserDetails.Where(x => x.UserId == id).FirstOrDefault();
            var Details = new UserDetails
            {
                UserId = v.UserId,
                UserEmail = v.UserEmail,
                FullName = v.FullName

            };

            return Details;
        }

        public async Task<List<UserDetails>> GetUserDetails()
        {
            try
            {
                return await _context.UserDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool PostEditUser(UserDetails userDetails)
        {
            var viewModel = _context.UserDetails.Where(x => x.UserId == userDetails.UserId).FirstOrDefault();
            viewModel.UserId = userDetails.UserId;
            viewModel.FullName = userDetails.FullName;
            viewModel.UserEmail = userDetails.UserEmail;
            _context.Entry(viewModel).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
