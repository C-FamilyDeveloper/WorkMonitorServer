using Microsoft.AspNetCore.Mvc.Formatters;

namespace WorkMonitorServer.Models.Services
{
    public class ByteArrayInputFormatterService : InputFormatter
    {
        public ByteArrayInputFormatterService()
        {
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/octet-stream"));
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(byte[]);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var stream = new MemoryStream();
            await context.HttpContext.Request.Body.CopyToAsync(stream);
            return await InputFormatterResult.SuccessAsync(stream.ToArray());
        }
    }
}
