using System.ComponentModel.DataAnnotations.Schema;

namespace AllDeductedDatabaseImplement.Models
{
    [Table("discipline_group")]
    public class DisciplineGroup
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("discipline_id")]
        public int DisciplineId { get; set; }

        [Column("group_id")]
        public int GroupId { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Group Group { get; set; }
    }
}