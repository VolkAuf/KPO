using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AllDeductedDatabaseImplement.Models
{
    [Table("discipline")]
    public class Discipline
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("hours_count")]
        [Required]
        public int HoursCount { get; set; }
        [Column("group_id")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        [Column("provider_id")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
