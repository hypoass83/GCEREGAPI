using Domain.InterfacesServices.Security;
using Domain.InterfacesStores.Security;
using Domain.Models.Security;

public class MouchardMiddleware
{
    private readonly RequestDelegate _next;


    public MouchardMiddleware(RequestDelegate next)
    {
        _next = next;

    }

    public async Task Invoke(HttpContext context, IMouchardService _moucharService, ICurrentUserService currentUserService)
    {


        // Avant d'exécuter la requête
        var start = DateTime.UtcNow;

        await _next(context); // Appel à l'API
        if (context.Request.Method != "GET")
        {
            // Après l'exécution de la requête
            var mouchard = new MouchardModel
            {
                MoucharDate = start,
                SneackHour = start.ToString("HH:mm"),
                UserID = context.User.Identity.IsAuthenticated ? currentUserService.GetCurentUserId() : null,
                MoucharAction = context.Response.StatusCode == 200 ? "SUCCESS" : "FAILURE",
                MoucharDescription = $"Request to {context.Request.Path}",
                MoucharOperationType = context.Request.Method,
                MoucharProcedureName = context.Request.Path,
                MoucharHost = context.Connection.RemoteIpAddress.ToString(),
                MoucharHostAdress = context.Connection.LocalIpAddress.ToString(),
                //ExamCentreID = 2, // Exemple statique, dépend de votre logique d'application
                MoucharBusinessDate = DateTime.UtcNow
            };

            _moucharService.LogAction(mouchard);
        }
    }
}

