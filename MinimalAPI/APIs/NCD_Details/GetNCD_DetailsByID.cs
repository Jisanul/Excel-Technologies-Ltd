using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.NCD_Details
{
    public class GetNCD_DetailsByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetNCD_DetailsByID/{id}", async (int id, [FromServices] INCD_DetailsRepository ncdDetailsRepository) =>
            {
                var ncdDetails = await ncdDetailsRepository.GetNCD_DetailsByID(id);
                return Results.Ok(ncdDetails);
            })
            .WithMetadata(new EndpointNameMetadata("GetNCD_DetailsByID"));
        }
    }

}
