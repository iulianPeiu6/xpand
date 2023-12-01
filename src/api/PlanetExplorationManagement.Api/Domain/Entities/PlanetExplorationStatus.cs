namespace Domain.Entities
{
    public class PlanetExplorationStatus
    {
        public Common.Enums.PlanetExplorationStatus PlanetExplorationStatusId { get; set; }
        public string Label { get; set; }

        public PlanetExplorationStatus(string label)
        {
            Label = label;
        }
    }
}