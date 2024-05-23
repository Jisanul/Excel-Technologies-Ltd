using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.NCD_Details
{
    public class InsertNCD_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertNCD_Details", async ([FromBody] Models.NCD_Details ncdDetails,
                                                     [FromServices] INCD_DetailsRepository ncdDetailsRepository,
                                                     [FromServices] LinkGenerator linkGenerator) =>
            {
                ncdDetails.ID = 0;
                await ncdDetailsRepository.InsertNCD_Details(ncdDetails);
                return Results.Created($"/GetNCD_DetailsByID/{ncdDetails.ID}", ncdDetails);
            })
            .WithMetadata(new EndpointNameMetadata("InsertNCD_Details"));
        }
    }


}
