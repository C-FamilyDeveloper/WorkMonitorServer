using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkMonitorServer.Models.DAL.DataEntities
{
    public class AcceptedSite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Url]
        public string URL { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Client Client { get; set; }
    }
}
