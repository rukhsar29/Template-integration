using System;
using System.Collections.Generic;
using System.Text;

namespace Books.DTO
{
    public class Users
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
    }

    public class AddUserParams
    {
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
