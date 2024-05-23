using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Noncommunicable
{
    public class DeleteNCD : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeleteNCD/{id}", async (int id,
                                                    [FromServices] INCDRepository ncdRepository,
                                                    [FromServices] LinkGenerator linkGenerator) =>
            {
                await ncdRepository.DeleteNCD(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("DeleteNCD"));
        }
    }

}
