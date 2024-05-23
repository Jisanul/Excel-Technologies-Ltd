using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Noncommunicable
{
    public class GetNCDByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetNCDByID/{id}", async (int id, [FromServices] INCDRepository ncdRepository) =>
            {
                var ncd = await ncdRepository.GetNCDByID(id);
                return Results.Ok(ncd);
            })
            .WithMetadata(new EndpointNameMetadata("GetNCDByID"));
        }
    }

}
