using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Noncommunicable
{
    public class InsertNCD : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertNCD", async ([FromBody] Models.NCD ncd,
                                             [FromServices] INCDRepository ncdRepository,
                                             [FromServices] LinkGenerator linkGenerator) =>
            {
                ncd.NCDID = 0;
                await ncdRepository.InsertNCD(ncd);
                return Results.Created($"/GetNCDByID/{ncd.NCDID}", ncd);
            })
            .WithMetadata(new EndpointNameMetadata("InsertNCD"));
        }
    }
}
