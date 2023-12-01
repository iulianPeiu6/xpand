using System.ComponentModel;

namespace Domain.Entities.Common.Enums
{
    public enum PlanetExplorationStatus
    {
        [Description("OK")]
        Ok = 1,
        [Description("!OK")]
        NotOk,
        [Description("TODO")]
        ToDo,
        [Description("En route")]
        EnRoute
    }
}
