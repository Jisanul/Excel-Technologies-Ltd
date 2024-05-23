using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.NCD_Details
{
    public class DeleteNCD_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapDelete("/DeleteNCD_Details/{id}", async (int id,
                                                    [FromServices] INCD_DetailsRepository nCD_DetailsRepository,
                                                    [FromServices] LinkGenerator linkGenerator) =>
            {
                await nCD_DetailsRepository.DeleteNCD_Details(id);
                return Results.Ok();
            })
            .WithMetadata(new EndpointNameMetadata("DeleteNCD_Details"));
        }
    }

}
