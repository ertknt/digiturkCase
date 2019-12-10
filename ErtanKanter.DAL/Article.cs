using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErtanKanter.DAL
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
        
        public DateTime? Date { get; set; }

        public string Author { get; set; }

        public bool IsActive { get; set; }
    }
}
