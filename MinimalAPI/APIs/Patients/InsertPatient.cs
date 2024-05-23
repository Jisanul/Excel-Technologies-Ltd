using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Patients
{
    public class InsertPatient : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/InsertPatient", async ([FromBody] Models.Patient patient,
                                                 [FromServices] IPatientsRepository patientRepository,
                                                 [FromServices] LinkGenerator linkGenerator) =>
            {
                patient.PatientID = 0;
                await patientRepository.InsertPatient(patient);
                return Results.Created();
            })
            .WithMetadata(new EndpointNameMetadata("InsertPatient"));
        }

    }
}
