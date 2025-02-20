﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMSAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }






    }
}
