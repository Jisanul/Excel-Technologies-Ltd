using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies_Details
{
    public class UpdateAllergies_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateAllergies_Details", async ([FromBody] Models.Allergies_Details allergiesDetails,
                                                          [FromServices] IAllergies_DetailsRepository allergiesDetailsRepository) =>
            {
                if (allergiesDetails != null)
                {
                    await allergiesDetailsRepository.UpdateAllergies_Details(allergiesDetails);
                    return Results.Ok();
                }
                return Results.NoContent();
            })
            .WithMetadata(new EndpointNameMetadata("UpdateAllergies_Details"));
        }
    }

}
