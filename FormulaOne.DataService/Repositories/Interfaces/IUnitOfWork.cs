namespace FormulaOne.DataService.Repositories;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementRepository Achievements { get; }
    Task<bool> CompleteAsync();
}