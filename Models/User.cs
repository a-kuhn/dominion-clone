using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DominionClone.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = " is required")]
        [MinLength(2, ErrorMessage = " must be at least 2 characters long.")]
        public string Name { get; set; }


        [Required(ErrorMessage = " is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = " is required")]
        [MinLength(8, ErrorMessage = " must be at least 8 characters long.")]
        [PasswordRegEx]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = " is required")]
        [Compare(nameof(Password), ErrorMessage = " does not match password.")]
        public string PWConfirm { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //can eventually allow users to save their played games & calculate some stats/leaderboards
        List<Game> GamesPlayed { get; set; }

    }
}