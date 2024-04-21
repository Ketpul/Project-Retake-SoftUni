﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Project.Constants.DateConstants;

namespace Project.Data.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RestaurantNameMaxLength)]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string ImageUrl1 { get; set; } = string.Empty;
        
        [Required]
        public string ImageUrl2 { get; set; } = string.Empty;

        [Required]
        public string ImageUrl3 { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string RestaurateurId { get; set; } = string.Empty;

        [Required]
        public string GoogleMaps { get; set; } = string.Empty;

        public int AvgRating { get; set; }

        [Required]
        public RegionalCity RegionalCity { get; set; } 

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
