namespace Domain.Entities
{
    public class PlanetExplorationRobot
    {
        public int PlanetExplorationId { get; set; }
        public int RobotId { get; set; }
        public PlanetExploration PlanetExploration { get; set; }
    }
}