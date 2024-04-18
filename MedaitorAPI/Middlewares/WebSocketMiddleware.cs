using System.Net.WebSockets;
using System.Text;

namespace MedaitorAPI.Middlewares;

public class WebSocketMiddleware
{
    List<WebSocket> webSockets = new List<WebSocket>();

    private readonly RequestDelegate _next;

    public WebSocketMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/ws")
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await Echo(webSocket);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
        else
        {
            await _next(context);
        }
    }

    async Task Echo(WebSocket webSocket)
    {
        webSockets.Add(webSocket);

        var buffer = new byte[1024 * 4];

        var message = Encoding.UTF8.GetBytes("Hoşgeldiniz");
        await webSocket.SendAsync(
            new ArraySegment<byte>(message, 0, message.Length),
            WebSocketMessageType.Text,
            true,
            CancellationToken.None);

        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            webSockets.ForEach(async ws =>
            {
                await ws.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);
            });



            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        webSockets.Remove(webSocket);
        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }


}


