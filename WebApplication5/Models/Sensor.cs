using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Sektor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}