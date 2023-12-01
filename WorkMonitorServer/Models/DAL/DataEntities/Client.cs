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
        public virtual List<Screen> Screens { get; set; }
        public virtual List<Activity> Activities { get; set; }
        public virtual List<Log> Logs { get; set; }
        public virtual List<AcceptedApp> AcceptedApps { get; set; }
        public virtual List<AcceptedSite> AcceptedSites { get; set; }
    }
}
