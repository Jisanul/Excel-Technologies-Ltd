using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies_Details
{
    public class InsertAllergies_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertAllergies_Details", async ([FromBody] Models.Allergies_Details allergiesDetails,
                                                           [FromServices] IAllergies_DetailsRepository allergiesDetailsRepository,
                                                           [FromServices] LinkGenerator linkGenerator) =>
            {
                allergiesDetails.ID = 0;
                await allergiesDetailsRepository.InsertAllergies_Details(allergiesDetails);
                return Results.Created($"/GetAllergies_DetailsByID/{allergiesDetails.ID}", allergiesDetails);
            })
            .WithMetadata(new EndpointNameMetadata("InsertAllergies_Details"));
        }
    }

}
