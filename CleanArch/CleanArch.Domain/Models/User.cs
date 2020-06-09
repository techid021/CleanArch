using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArch.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(250)]
        public string Password { get; set; }

    }
}
