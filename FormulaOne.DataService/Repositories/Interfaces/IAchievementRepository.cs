using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService.Repositories;

public interface IAchievementRepository:IGenericRepository<Achievement>
{
    Task<Achievement?> GetDriverAchievementAsync(Guid id);
}