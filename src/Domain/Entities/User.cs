using Microsoft.AspNetCore.Identity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public ICollection<UserLibrary> UsersLibraryItems { get; set; }

    }
}

//bool czy ma ważną subskrypcje 