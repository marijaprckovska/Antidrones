using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Dron
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Absolute { get; set; }
    }
    public class DataContex : DbContext
    {
        public DbSet<Dron> dron { get; set; }
        public DbSet<Bird> bird { get; set; }
        public DbSet<Sensor> sensor { get; set; }
        public DbSet<Detekcija> detekcija { get; set; }
    }
}
