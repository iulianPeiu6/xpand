
using Domain.Entities;

public class PlanetExploration
{

    public int PlanetExplorationId { get; set; }
    public int PlanetId { get; set; }
    public Domain.Entities.Common.Enums.PlanetExplorationStatus PlanetExplorationStatusId { get; set; }
    public int CaptainId { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Planet Planet { get; set; }
    public PlanetExplorationStatus PlanetExplorationStatus { get; set; }
    public ICollection<PlanetExplorationRobot> Robots { get; set; }

    public PlanetExploration(int planetId, int createdBy)
    {
        PlanetId = planetId;
        PlanetExplorationStatusId = Domain.Entities.Common.Enums.PlanetExplorationStatus.ToDo;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }
}

