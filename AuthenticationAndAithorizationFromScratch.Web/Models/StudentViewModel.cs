﻿using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAithorizationFromScratch.Web.Models
{
    public class StudentViewModel
    {
        [Key]
        [StringLength(20)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

    }
}
