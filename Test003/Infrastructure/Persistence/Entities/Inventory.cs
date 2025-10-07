using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test003.Infrastructure.Persistence.Entities;

[Table("inventory")]
public class Inventory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("phone_id", TypeName = "integer")]
    public int PhoneId { get; set; }

    [Required]
    [Range(0, short.MaxValue)]
    [Column("total_quantity", TypeName = "smallint")]
    [DefaultValue(0)]
    public short TotalQuantity { get; set; }

    [Required]
    [Range(0, short.MaxValue)]
    [Column("remaining_quantity", TypeName = "smallint")]
    [DefaultValue(0)]
    public short RemainingQuantity { get; set; }

    [ForeignKey("PhoneId")]
    public virtual Phone Phone { get; set; } = null!;
}