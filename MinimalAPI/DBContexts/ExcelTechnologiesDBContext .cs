using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DBContexts
{
    public class ExcelTechnologiesDBContext : DbContext
    {

        public ExcelTechnologiesDBContext(DbContextOptions<ExcelTechnologiesDBContext> options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }

        //public ExcelTechnologiesContext() : base("name=ExcelTechnologiesContext")
        //{
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Define relationships and keys if needed using Fluent API
        //    modelBuilder.Entity<Patient>()
        //        .HasMany(p => p.NCD_Details)
        //        .WithRequired(nd => nd.Patient)
        //        .HasForeignKey(nd => nd.PatientID);

        //    modelBuilder.Entity<Patient>()
        //        .HasMany(p => p.Allergies_Details)
        //        .WithRequired(ad => ad.Patient)
        //        .HasForeignKey(ad => ad.PatientID);
        //}
    }

}
