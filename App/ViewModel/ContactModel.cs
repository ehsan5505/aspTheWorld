using System;
using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModel
{

    public class ContactModel
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1024, MinimumLength = 5)]
        public string Message { get; set; }

    }
}