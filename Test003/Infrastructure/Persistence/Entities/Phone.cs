using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test003.Infrastructure.Persistence.Entities;

[Table("phone")]
public class Phone
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "integer")]
    public int Id { get; set; }

    [Required]
    [Column("model_id", TypeName = "integer")]
    public int ModelId { get; set; }

    [Required]
    [MaxLength(255)]
    [Column("name", TypeName = "varchar(255)")]
    public string Name { get; set; } = null!;

    [Required]
    [Column("storage_capacity", TypeName = "integer")]
    public int StorageCapacity { get; set; }

    [Required]
    [Column("ram_capacity", TypeName = "smallint")]
    public short RamCapacity { get; set; }

    [Required]
    [Column("year_of_manufacture", TypeName = "smallint")]
    public short YearOfManufacture { get; set; }

    [Required]
    [MaxLength(30)]
    [Column("os_version", TypeName = "varchar(30)")]
    public string OsVersion { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column("body_color", TypeName = "varchar(20)")]
    public string BodyColor { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    [Column("body_color_name", TypeName = "varchar(30)")]
    public string BodyColorName { get; set; } = null!;

    [Required]
    [Precision(12, 2)]
    [Column("default_price", TypeName = "decimal(12,2)")]
    public decimal DefaultPrice { get; set; }

    [Required]
    [MaxLength(3)]
    [Column("default_currency", TypeName = "char(3)")]
    public string DefaultCurrency { get; set; } = null!;

    [ForeignKey("ModelId")]
    public virtual Model Model { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}