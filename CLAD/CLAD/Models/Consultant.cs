﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLAD.Models
{
    public class Consultant 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ImgName { get; set; }
        public bool IsVerified { get; set; }
    }
}
