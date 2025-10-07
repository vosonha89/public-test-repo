using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Test003.Core.Application.Services;
using Test003.Infrastructure.Persistence.DbContexts;
using Test003.Infrastructure.Persistence.Entities;
using Test003.Presentation.APIs.Phone.Dtos;

namespace Test003.Test.Service;

[TestClass]
public class PhoneServiceTest
{
    private PsqlDbContext _context;
    private PhoneService _phoneService;

    private PhoneRegisterRequestDto CreateValidPhoneRequest()
    {
        return new PhoneRegisterRequestDto
        {
            ManufacturerId = 1,
            ModelId = 1,
            Name = "Test Phone",
            StorageCapacity = 128,
            RamCapacity = 8,
            YearOfManufacture = 2023,
            OsVersion = "iOS 17",
            BodyColor = "#000000",
            BodyColorName = "Black",
            DefaultPrice = 999.99m,
            DefaultCurrency = "USD",
            Quantity = 10
        };
    }

    private Manufacturer CreateManufacturer()
    {
        return new Manufacturer
        {
            Id = 1,
            Name = "Apple"
        };
    }

    private Model CreateModel()
    {
        return new Model
        {
            Id = 1,
            Name = "iPhone 15",
            ManufacturerId = 1
        };
    }

    [TestInitialize]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<PsqlDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        _context = new PsqlDbContext(options);
        _phoneService = new PhoneService(_context);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _context?.Dispose();
    }

    #region False case

    [TestMethod]
    public async Task RegisterPhoneAsync_ManufacturerNotFound_ThrowsDataException()
    {
        var request = CreateValidPhoneRequest();

        var exception =
            await Assert.ThrowsExceptionAsync<DataException>(() => _phoneService.RegisterPhoneAsync(request));

        Assert.AreEqual($"Manufacturer ID: {request.ManufacturerId} does not exist.", exception.Message);
    }

    [TestMethod]
    public async Task RegisterPhoneAsync_ModelNotFound_ThrowsDataException()
    {
        var request = CreateValidPhoneRequest();
        var manufacturer = CreateManufacturer();

        await _context.Manufacturers.AddAsync(manufacturer);
        await _context.SaveChangesAsync();

        var exception =
            await Assert.ThrowsExceptionAsync<DataException>(() => _phoneService.RegisterPhoneAsync(request));

        Assert.AreEqual($"Models ID: {request.ModelId} does not exist.", exception.Message);
    }

    [TestMethod]
    public async Task RegisterPhoneAsync_ModelWithWrongManufacturer_ThrowsDataException()
    {
        var request = CreateValidPhoneRequest();
        var manufacturer = CreateManufacturer();
        var model = new Model
        {
            Id = 1,
            Name = "iPhone 15",
            ManufacturerId = 999
        };

        await _context.Manufacturers.AddAsync(manufacturer);
        await _context.Models.AddAsync(model);
        await _context.SaveChangesAsync();

        var exception =
            await Assert.ThrowsExceptionAsync<DataException>(() => _phoneService.RegisterPhoneAsync(request));

        Assert.AreEqual($"Models ID: {request.ModelId} does not exist.", exception.Message);
    }

    [TestMethod]
    public async Task RegisterPhoneAsync_PhoneAlreadyExists_ThrowsDataException()
    {
        var request = CreateValidPhoneRequest();
        var manufacturer = CreateManufacturer();
        var model = CreateModel();
        var existingPhone = new Phone
        {
            Id = 1,
            ModelId = request.ModelId,
            Name = request.Name,
            StorageCapacity = request.StorageCapacity,
            RamCapacity = (short)request.RamCapacity,
            YearOfManufacture = (short)request.YearOfManufacture,
            OsVersion = request.OsVersion,
            BodyColor = request.BodyColor,
            BodyColorName = request.BodyColorName,
            DefaultPrice = request.DefaultPrice,
            DefaultCurrency = request.DefaultCurrency
        };

        await _context.Manufacturers.AddAsync(manufacturer);
        await _context.Models.AddAsync(model);
        await _context.Phones.AddAsync(existingPhone);
        await _context.SaveChangesAsync();

        var exception =
            await Assert.ThrowsExceptionAsync<DataException>(() => _phoneService.RegisterPhoneAsync(request));

        Assert.AreEqual($"Phone '{request.Name}' already exists", exception.Message);
    }

    #endregion

    #region True case

    [TestMethod]
    public async Task RegisterPhoneAsync_ValidRequest_ReturnsPhoneResponseDto()
    {
        var request = CreateValidPhoneRequest();
        var manufacturer = CreateManufacturer();
        var model = CreateModel();

        await _context.Manufacturers.AddAsync(manufacturer);
        await _context.Models.AddAsync(model);
        await _context.SaveChangesAsync();

        var result = await _phoneService.RegisterPhoneAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(request.Name, result.Name);
        Assert.AreEqual(request.StorageCapacity, result.StorageCapacity);
        Assert.AreEqual(request.RamCapacity, result.RamCapacity);
        Assert.AreEqual(request.YearOfManufacture, result.YearOfManufacture);
        Assert.AreEqual(request.OsVersion, result.OsVersion);
        Assert.AreEqual(request.BodyColor, result.BodyColor);
        Assert.AreEqual(request.BodyColorName, result.BodyColorName);
        Assert.AreEqual(request.DefaultPrice, result.DefaultPrice);
        Assert.AreEqual(request.DefaultCurrency, result.DefaultCurrency);
        Assert.AreEqual(manufacturer.Name, result.Manufacturer?.Name);
        Assert.AreEqual(model.Name, result.Model?.Name);
        Assert.AreEqual(request.Quantity, result.Inventory?.TotalQuantity);
        Assert.AreEqual(request.Quantity, result.Inventory?.RemainingQuantity);

        // Verify data was saved to database
        var phoneInDB = await _context.Phones.FirstOrDefaultAsync(p => p.Name == request.Name);
        var inventoryInDB = await _context.Inventories.FirstOrDefaultAsync(i => i.PhoneId == phoneInDB.Id);

        Assert.IsNotNull(phoneInDB);
        Assert.IsNotNull(inventoryInDB);
    }

    #endregion
}