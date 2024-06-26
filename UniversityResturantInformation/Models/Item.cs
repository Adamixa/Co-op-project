﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityResturantInformation.Models
{
    //[Index(nameof(ItemCode), IsUnique = true, Name = "Unique_Item_Code")]
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Item Code is required")]
        public int ItemCode { get; set; }
        [Required(ErrorMessage = "Item Name is required")]
        public string ItemName { get; set; }
        public int Cal { get; set; }
        public bool IsDeleted { get; set; }
        public float Total { get; set; }
        public int NumberOfRating { get; set; }
        public string File { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "Please Add Image")]
        public IFormFile UploadedImage { get; set; }
    }
}
