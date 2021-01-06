using RadioConsole.Web.Models.Enums;
using Type = RadioConsole.Web.Models.Enums.Type;

namespace RadioConsole.Web.Models
{
    public class RadioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public string SerialNumber { get; set; }
        public int SignalStrength { get; set; }
        public int BatteryLevel { get; set; }
        public ActualMode Mode { get; set; }
        public Unit Unit { get; set; }
    }
}
