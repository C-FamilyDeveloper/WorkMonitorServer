using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WorkMonitorServer.Models.DAL.DataEntities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ActivityApplication { get; set; }
        [MaybeNull]
        public string? ActivitySite { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public TimeSpan WorkTime { get; set; }
        public TimeSpan IdleTime { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Client Client { get; init; }
    }
}
