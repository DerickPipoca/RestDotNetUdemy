using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RestDotNetUdemy.Models.Base;

namespace RestDotNetUdemy.Models
{
    [Table("books")]
    public class Book : BaseEntity
    {

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; } = DateTime.Now;

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("author")]
        public string Author { get; set; } = string.Empty;
    }
}