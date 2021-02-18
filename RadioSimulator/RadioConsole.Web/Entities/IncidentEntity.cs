using RadioConsole.Web.Models.Enums;

namespace RadioConsole.Web.Entities
{
    public class IncidentEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Unit Group { get; set; }
    }
}
