namespace FormulaOne.Entities.Dtos.Requests;

public class CreateDriverAchievementRequest
{
    public int Wins { get; set; }
    public int PolePosition { get; set; }
    public int FastestLap { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverId { get; set; }
}