﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeBook.Domain.Constants;

namespace RecipeBook.Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("username")]
        [StringLength(Lengths.Name)]
        [Required]
        public string Username { get; set; }

    }
}
