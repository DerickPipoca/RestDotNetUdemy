using System.ComponentModel.DataAnnotations.Schema;

namespace RestDotNetUdemy.Models.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}