using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WorkMonitorServer.Models.DataEntities
{
    public class Screen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ScreenshotDateTime { get; set; }
        public byte[] Image { get; set; }
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public Client ScreenedClient { get; init; }
    }
}
