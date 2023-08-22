using System.Drawing;
using System.Drawing.Imaging;

namespace WorkMonitorServer.Models.Services
{
    #pragma warning disable CA1416 // Validate platform compatibility
    public static class ImageSaverService
    {
        public static void Save(byte[] imageData)
        {
            using MemoryStream ms = new(imageData);
            Image.FromStream(ms).Save(
                @"C:\Users\User\Downloads\screenshot" + DateTime.Now.ToString(@"yyyy_MM_dd_HH_mm_ss") + @".jpg", ImageFormat.Jpeg);
        }
    }
}
