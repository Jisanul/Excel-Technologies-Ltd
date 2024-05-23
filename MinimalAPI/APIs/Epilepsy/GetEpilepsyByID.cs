using LibraryManagementSystem.API_Setup;
using LibraryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.APIs.Epilepsy
{
    public class GetEpilepsyByID : IWebApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/GetEpilepsyById/{id}", async ([FromRoute] int id,
                                                      [FromServices] IEpilepsyRepository epilepsyRepository) =>
            {
                var epilepsy = await epilepsyRepository.GetEpilepsyByIdAsync(id);
                return epilepsy is not null ? Results.Ok(epilepsy) : Results.NotFound();
            });
        }
    }

}
