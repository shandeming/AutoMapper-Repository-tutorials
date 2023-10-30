using FormulaOne.DataService.Data;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class UnitOfWork:IUnitOfWork,IDisposable
{
    private readonly AppDbContext _context;
    private readonly ILoggerFactory _loggerFactory;
    public IDriverRepository Drivers { get; }
    public IAchievementRepository Achievements { get; }

    public UnitOfWork(AppDbContext context,ILoggerFactory loggerFactory)
    {
        _context = context;
        var logger = loggerFactory.CreateLogger("logs");
        Drivers = new DriverRepository(context,logger);
        Achievements = new AchievementRepository(context, logger);
    }
    public async Task<bool> CompleteAsync()
    {
        var result=await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}