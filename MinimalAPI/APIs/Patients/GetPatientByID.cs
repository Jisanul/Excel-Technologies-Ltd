using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Patients
{
    public class GetPatientByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetPatientByID/{id}", async (int id, [FromServices] IPatientsRepository patientRepository) =>
            {
                var patient = await patientRepository.GetPatientByID(id);
                return Results.Ok(patient);
            })
            .WithMetadata(new EndpointNameMetadata("GetPatientByID"));
        }
    }

}
