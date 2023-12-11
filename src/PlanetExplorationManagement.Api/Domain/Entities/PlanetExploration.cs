namespace Domain.Entities
{
    public class PlanetExploration
    {
        public int PlanetExplorationId { get; set; }
        public int PlanetId { get; set; }
        public Common.Enums.PlanetExplorationStatus PlanetExplorationStatusId { get; set; }
        public string CaptainId { get; set; }
        public string Observations { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Planet Planet { get; set; }
        public PlanetExplorationStatus PlanetExplorationStatus { get; set; }
        public ICollection<PlanetExplorationRobot> Robots { get; set; }
    }
}