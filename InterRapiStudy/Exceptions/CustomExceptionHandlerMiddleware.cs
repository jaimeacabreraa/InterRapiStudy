using System.Net;
using Newtonsoft.Json;

namespace InterRapiStudy.Exceptions;

public class CustomExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            // Manejar la excepción aquí
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Aquí puedes personalizar cómo manejar la excepción, por ejemplo, logueándola
        // o devolviendo una respuesta específica al cliente.

        // Ejemplo: Loguear la excepción
        Console.WriteLine($"Se ha producido una excepción: {exception}");

        // Devolver una respuesta de error al cliente
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new
        {
            error = new
            {
                message = exception.Message
                // Puedes agregar más detalles según lo necesites
            }
        };

        // Serializar y escribir la respuesta en el cuerpo de la respuesta HTTP
        var jsonResponse = JsonConvert.SerializeObject(response);
        return context.Response.WriteAsync(jsonResponse);
    }
}