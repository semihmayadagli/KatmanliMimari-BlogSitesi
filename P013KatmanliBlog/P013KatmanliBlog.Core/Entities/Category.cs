﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P013KatmanliBlog.Core.Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        [Display(Name ="İsim")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Durum")]
        public bool IsActive{ get; set; }
        [Display(Name = "Sıra Numarası")]
        public int ParentId { get; set; }
        [Display(Name = "Oluşturma Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public List<Post>? Posts { get; set; }

    }
}
