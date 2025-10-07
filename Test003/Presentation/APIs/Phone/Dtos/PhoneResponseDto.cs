namespace Test003.Presentation.APIs.Phone.Dtos;

/// <summary>
/// Phone response DTO
/// </summary>
public class PhoneResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int StorageCapacity { get; set; }
    public short RamCapacity { get; set; }
    public short YearOfManufacture { get; set; }
    public string OsVersion { get; set; } = string.Empty;
    public string BodyColor { get; set; } = string.Empty;
    public string BodyColorName { get; set; } = string.Empty;
    public decimal DefaultPrice { get; set; }
    public string DefaultCurrency { get; set; } = string.Empty;

    public ManufacturerResponseDto? Manufacturer { get; set; }
    public ModelResponseDto? Model { get; set; }
    public InventoryResponseDto? Inventory { get; set; }
}

public class ManufacturerResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class ModelResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class InventoryResponseDto
{
    public int Id { get; set; }
    public short TotalQuantity { get; set; }
    public short RemainingQuantity { get; set; }
}