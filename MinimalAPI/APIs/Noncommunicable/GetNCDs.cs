using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Noncommunicable
{
    public class GetNCDs : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetNCDs", async ([FromServices] INCDRepository ncdRepository) =>
            {
                var ncds = await ncdRepository.GetNCDs();
                return Results.Ok(ncds);
            })
            .WithMetadata(new EndpointNameMetadata("GetNCDs"));
        }
    }

}
