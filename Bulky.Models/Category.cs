﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("DisplayOrder")]
        [Range(1, 100, ErrorMessage = "Range Of Display Order should be from 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
