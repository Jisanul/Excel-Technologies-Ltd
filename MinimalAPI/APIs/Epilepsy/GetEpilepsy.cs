using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Epilepsy
{
    public class GetEpilepsy : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetEpilepsies", async ([FromServices] IEpilepsyRepository epilepsyRepository) =>
            {
                var epilepsies = await epilepsyRepository.GetEpilepsiesAsync();
                return Results.Ok(epilepsies);
            });
        }
    }

}
