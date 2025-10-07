using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test003.Infrastructure.Persistence.Entities;

[Table("model")]
public class Model
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("manufacturer_id", TypeName = "integer")]
    public int ManufacturerId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name", TypeName = "varchar(100)")]
    public string Name { get; set; } = null!;

    [ForeignKey("ManufacturerId")]
    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}