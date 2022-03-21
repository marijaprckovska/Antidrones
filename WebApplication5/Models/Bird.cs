﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Bird
    {
        [Key]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Absolute { get; set; }
    }
}