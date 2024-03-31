namespace DemoPlatzi.Middlewares
{
    public class TimeMidleware
    {
        // nos permite invocar el middleware siguiente en el ciclo
        readonly RequestDelegate next;

        public TimeMidleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {
            // invocamos al siguiente middleware
            await next.Invoke(context);

            // verificamos si en el Request (url) existe el parametro time
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                // agregamos la hora actual a la respuesta del request
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }
    }

    // clase que nos permite invocar nuestro middleware desde la app
    public static class TimeMiddlewareExtension
    {
        // recibimos el ApplicationBuilder y lo retornamos con nuetsro middleware agregado
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMidleware>();
        }
    }
}
