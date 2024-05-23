using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Noncommunicable
{
    public class UpdateNCD : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateNCD", async ([FromBody] Models.NCD ncd,
                                            [FromServices] INCDRepository ncdRepository) =>
            {
                if (ncd != null)
                {
                    await ncdRepository.UpdateNCD(ncd);
                    return Results.Ok();
                }
                return Results.NoContent();
            })
            .WithMetadata(new EndpointNameMetadata("UpdateNCD"));
        }
    }

}
