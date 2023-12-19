using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllDeductedDatabaseImplement.Models
{
    [Table("group")]
    public class Group
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("curator_name")]
        public string CuratorName { get; set; }
        [Column("provider_id")]
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }

        [ForeignKey("GroupId")]
        public virtual List<DisciplineGroup> DisciplineGroups { get; set; }

        [ForeignKey("GroupId")]
        public virtual List<OrderGroup> OrderGroups { get; set; }
    }
}
