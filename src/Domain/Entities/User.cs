﻿using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

    }
}

//bool czy ma ważną subskrypcje 