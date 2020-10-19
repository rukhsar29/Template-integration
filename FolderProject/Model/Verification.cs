using System;
using System.Collections.Generic;

namespace FolderProject.Model
{
    public partial class Verification
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? Verify { get; set; }
    }
}
