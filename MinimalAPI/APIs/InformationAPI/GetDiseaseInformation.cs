using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.InformationAPI
{
    public class GetDiseaseInformation : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetDiseaseInformation", async ([FromServices] IDiseaseInformationRepository diseaseInformationRepository) =>
            {
                var diseaseInformation = await diseaseInformationRepository.GetDiseaseInformation();
                return Results.Ok(diseaseInformation);
            })
            .WithMetadata(new EndpointNameMetadata("GetDiseaseInformation"));
        }
    }

}
