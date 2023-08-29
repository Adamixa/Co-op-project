using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityResturantInformation.Models;

namespace UniversityResturantInformation.Models
{
    public class RestaurantDB : DbContext
    {

        public RestaurantDB(DbContextOptions<RestaurantDB> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<Compliant> Complaints { get; set; }
        public virtual DbSet<Menu_Item> Menu_Items { get; set; }


    }
}