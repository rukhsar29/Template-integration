using System;
using System.Collections.Generic;

namespace FolderProject.Model
{
    public partial class OtpVerification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Otp { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsExpired { get; set; }
    }
}
