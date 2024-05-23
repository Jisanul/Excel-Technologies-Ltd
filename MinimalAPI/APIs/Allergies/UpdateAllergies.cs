using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace LibraryManagementSystem.APIs.Allergies
{
    public class UpdateAllergies : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPut("/UpdateAllergies", async ([FromBody] Models.Allergies allergies, [FromServices] IAllergiesRepository allergiesRepository) =>
            {
                if (allergies != null)
                {
                    await allergiesRepository.UpdateAllergies(allergies);
                    return Results.Ok();

                }
                return Results.NoContent();
            })
        .WithMetadata(new EndpointNameMetadata("UpdateAllergies"));
        }
    }

}
