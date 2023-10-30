using FormulaOne.DataService.Data;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class AchievementRepository:GenericRepository<Achievement>,IAchievementRepository
{
    public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid id)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == id);
        }
        catch (Exception e)
        {
            _logger.LogError(e,"{Repo} GetDriverAchievementAsync error",typeof(AchievementRepository));
            throw;
        }
    }
    public override async Task<IEnumerable<Achievement>> All()
    {
        try
        {
            return await _dbSet.Where(d => d.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} All function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            //get my entity
            var result =await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return false;
            }
            result.Status = 0;
            result.UpdatedDate=DateTime.Now;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Delete function error", typeof(AchievementRepository));
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            var result =await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
            if (result == null)
            {
                return false;
            }
            result.UpdatedDate = DateTime.Now;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionship = achievement.WorldChampionship;
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Repo} Update function error", typeof(AchievementRepository));
            throw;
        }
    }
}