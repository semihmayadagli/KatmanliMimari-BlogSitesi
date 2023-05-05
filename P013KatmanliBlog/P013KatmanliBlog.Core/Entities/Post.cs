using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P013KatmanliBlog.Core.Entities
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Post İsmi")]
        public string Name { get; set; }
        [Display(Name = "Post Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Oluşturma Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
