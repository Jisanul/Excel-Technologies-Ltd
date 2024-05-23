using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.NCD_Details
{
    public class GetNCD_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetNCD_Details", async ([FromServices] INCD_DetailsRepository ncdDetailsRepository) =>
            {
                var ncdDetails = await ncdDetailsRepository.GetNCD_Details();
                return Results.Ok(ncdDetails);
            })
            .WithMetadata(new EndpointNameMetadata("GetNCD_Details"));
        }
    }

}
