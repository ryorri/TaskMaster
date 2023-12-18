﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Error> ErrorEntry { get; set; }
        public ICollection<Warning> WarningEntry { get; set; }
    }
}
