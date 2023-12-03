namespace Domain.Entities
{
    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public PlanetExploration PlanetExploration { get; set; }
    }
}