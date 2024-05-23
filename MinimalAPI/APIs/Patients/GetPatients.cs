using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Patients
{
    public class GetPatients : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetPatient", async ([FromServices] IPatientsRepository patientRepository) =>
            {
                var patients = await patientRepository.GetPatients();
                return Results.Ok(patients);
            })
            .WithMetadata(new EndpointNameMetadata("GetPatient"));
        }
    }
}
