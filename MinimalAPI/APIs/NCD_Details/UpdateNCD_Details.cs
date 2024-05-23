using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.NCD_Details
{
    public class UpdateNCD_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateNCD_Details", async ([FromBody] Models.NCD_Details ncdDetails,
                                                    [FromServices] INCD_DetailsRepository ncdDetailsRepository) =>
            {
                if (ncdDetails != null)
                {
                    await ncdDetailsRepository.UpdateNCD_Details(ncdDetails);
                    return Results.Ok();
                }
                return Results.NoContent();
            })
            .WithMetadata(new EndpointNameMetadata("UpdateNCD_Details"));
        }
    }

}
