using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkMonitorServer.Models.DAL.DataEntities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Screen> Screens { get; set; }
        public List<Activity> Activities { get; set; }
        public List<Log> Logs { get; set; }
        public List<AcceptedApp> AcceptedApps { get; set; }
        public List<AcceptedSite> AcceptedSites { get; set; }
    }
}
