namespace Domain.Entities
{
    public class PlanetExploration
    {
        public int PlanetExplorationId { get; set; }
        public int PlanetId { get; set; }
        public Common.Enums.PlanetExplorationStatus PlanetExplorationStatusId { get; set; }
        public int? CaptainId { get; set; }
        public string Observations { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Planet Planet { get; set; }
        public PlanetExplorationStatus PlanetExplorationStatus { get; set; }
        public ICollection<PlanetExplorationRobot> Robots { get; set; }
    }
}