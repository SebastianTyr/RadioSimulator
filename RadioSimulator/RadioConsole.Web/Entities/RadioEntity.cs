using RadioConsole.Web.Models.Enums;
using Type = RadioConsole.Web.Models.Enums.Type;
using RadioConsole.Web.Models;

namespace RadioConsole.Web.Entities
{
    public class RadioEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public string SerialNumber { get; set; }
        public int SignalStrength { get; set; }
        public int BatteryLevel { get; set; }
        public ActualMode Mode { get; set; }
    }
}
