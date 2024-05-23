using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.InformationAPI
{
    public class InsertDiseaseInformation : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertDiseaseInformation", async ([FromBody] Models.DiseaseInformation diseaseInformation,
                                                            [FromServices] IDiseaseInformationRepository diseaseInformationRepository,
                                                            [FromServices] LinkGenerator linkGenerator) =>
            {
                diseaseInformation.DiseaseID = 0;
                await diseaseInformationRepository.InsertDiseaseInformation(diseaseInformation);
                return Results.Created($"/GetDiseaseInformationByID/{diseaseInformation.DiseaseID}", diseaseInformation);
            })
            .WithMetadata(new EndpointNameMetadata("InsertDiseaseInformation"));
        }
    }

}
