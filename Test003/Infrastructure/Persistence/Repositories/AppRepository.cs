using DevNetCore.SimpleRepository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Test003.Infrastructure.Persistence.Repositories;

/// <summary>
/// Application repository
/// </summary>
public class AppRepository : SimpleRepository
{
    protected AppRepository(DbContext dbContext) : base(dbContext)
    {
    }
}