using System.Data;
using Microsoft.EntityFrameworkCore;
using Test003.Core.Application.Interfaces;
using Test003.Infrastructure.Persistence.DbContexts;
using Test003.Infrastructure.Persistence.Entities;
using Test003.Presentation.APIs.Phone.Dtos;

namespace Test003.Core.Application.Services;

/// <summary>
/// Phone service
/// </summary>
public class PhoneService : IPhoneService
{
    private PsqlDbContext _context;

    public PhoneService(PsqlDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Register phone
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="DataException"></exception>
    public async Task<PhoneResponseDto> RegisterPhoneAsync(PhoneRegisterRequestDto request)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(x => x.Id == request.ManufacturerId);
            if (manufacturer == null)
            {
                throw new DataException($"Manufacturer ID: {request.ManufacturerId} does not exist.");
            }

            var model = await _context.Models.FirstOrDefaultAsync(x =>
                x.Id == request.ModelId && x.ManufacturerId == request.ManufacturerId);
            if (model == null)
            {
                throw new DataException($"Models ID: {request.ModelId} does not exist.");
            }

            var existingPhone =
                await _context.Phones.AnyAsync(x => x.ModelId == request.ModelId && x.Name == request.Name);
            if (existingPhone)
            {
                throw new DataException($"Phone '{request.Name}' already exists");
            }

            // Add phone to database - can use automapper
            var entity = new Phone
            {
                ModelId = request.ModelId,
                Name = request.Name,
                StorageCapacity = request.StorageCapacity,
                RamCapacity = request.RamCapacity,
                YearOfManufacture = request.YearOfManufacture,
                OsVersion = request.OsVersion,
                BodyColor = request.BodyColor,
                BodyColorName = request.BodyColorName,
                DefaultPrice = request.DefaultPrice,
                DefaultCurrency = request.DefaultCurrency
            };

            _context.Phones.Add(entity);
            await _context.SaveChangesAsync();

            // Add inventory to database
            var inventory = new Inventory
            {
                PhoneId = entity.Id,
                TotalQuantity = request.Quantity,
                RemainingQuantity = request.Quantity
            };
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            // Create response dto - can use automapper
            var response = new PhoneResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                StorageCapacity = entity.StorageCapacity,
                RamCapacity = entity.RamCapacity,
                YearOfManufacture = entity.YearOfManufacture,
                OsVersion = entity.OsVersion,
                BodyColor = entity.BodyColor,
                BodyColorName = entity.BodyColorName,
                DefaultPrice = entity.DefaultPrice,
                DefaultCurrency = entity.DefaultCurrency,
                Manufacturer = new ManufacturerResponseDto
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name
                },
                Model = new ModelResponseDto
                {
                    Id = model.Id,
                    Name = model.Name
                },
                Inventory = new InventoryResponseDto
                {
                    Id = inventory.Id,
                    TotalQuantity = inventory.TotalQuantity,
                    RemainingQuantity = inventory.RemainingQuantity
                }
            };
            return response;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}