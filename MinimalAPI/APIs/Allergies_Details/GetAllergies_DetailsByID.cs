using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies_Details
{
    public class GetAllergies_DetailsByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetAllergies_DetailsByID/{id}", async (int id, [FromServices] IAllergies_DetailsRepository allergiesDetailsRepository) =>
            {
                var allergiesDetails = await allergiesDetailsRepository.GetAllergies_DetailsByID(id);
                return Results.Ok(allergiesDetails);
            })
            .WithMetadata(new EndpointNameMetadata("GetAllergies_DetailsByID"));
        }
    }

}
