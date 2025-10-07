using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test003.Presentation.APIs.Phone.Dtos;

public class PhoneRegisterRequestDto
{
    [Required(ErrorMessage = "Manufacturer ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Manufacturer ID must be a positive integer.")]
    public int ManufacturerId { get; set; }

    [Required(ErrorMessage = "Model ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Model ID must be a positive integer.")]
    public int ModelId { get; set; }

    [Required(ErrorMessage = "Phone name is required.")]
    [MaxLength(255, ErrorMessage = "Phone name cannot exceed 255 characters.")]
    [MinLength(1, ErrorMessage = "Phone name must be at least 1 character.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Storage capacity is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Storage capacity must be a positive integer.")]
    public int StorageCapacity { get; set; }

    [Required(ErrorMessage = "RAM capacity is required.")]
    [Range(1, short.MaxValue, ErrorMessage = "RAM capacity must be a positive short integer.")]
    public short RamCapacity { get; set; }

    [Required(ErrorMessage = "Year of manufacture is required.")]
    [Range(1900, 2100, ErrorMessage = "Year of manufacture must be between 1900 and 2100.")]
    public short YearOfManufacture { get; set; }

    [Required(ErrorMessage = "OS version is required.")]
    [MaxLength(30, ErrorMessage = "OS version cannot exceed 30 characters.")]
    [MinLength(1, ErrorMessage = "OS version must be at least 1 character.")]
    public string OsVersion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Body color is required.")]
    [MaxLength(20, ErrorMessage = "Body color cannot exceed 20 characters.")]
    [MinLength(1, ErrorMessage = "Body color must be at least 1 character.")]
    public string BodyColor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Body color name is required.")]
    [MaxLength(30, ErrorMessage = "Body color name cannot exceed 30 characters.")]
    [MinLength(1, ErrorMessage = "Body color name must be at least 1 character.")]
    public string BodyColorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Default price is required.")]
    [Range(1, float.MaxValue, ErrorMessage = "Default price must be larger zero.")]
    [Column(TypeName = "decimal(12,2)")]
    public decimal DefaultPrice { get; set; }

    [Required(ErrorMessage = "Default currency is required.")]
    [MaxLength(3, ErrorMessage = "Default currency must be exactly 3 characters.")]
    [MinLength(3, ErrorMessage = "Default currency must be exactly 3 characters.")]
    public string DefaultCurrency { get; set; } = string.Empty;

    [Range(1, short.MaxValue, ErrorMessage = "Quantity must be larger zero.")]
    public short Quantity { get; set; } = 0;
}