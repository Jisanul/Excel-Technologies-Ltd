using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Allergies_Details
{
    public class GetAllergies_Details : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetAllergies_Details", async ([FromServices] IAllergies_DetailsRepository allergiesDetailsRepository) =>
            {
                var allergiesDetails = await allergiesDetailsRepository.GetAllergies_Details();
                return Results.Ok(allergiesDetails);
            })
            .WithMetadata(new EndpointNameMetadata("GetAllergies_Details"));
        }
    }

}
