using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetdotnet.Models;

namespace projetdotnet.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Absence> absences { get; set; }
        public DbSet<Etudiant> notes { get; set; }
        public DbSet<projetdotnet.Models.Note> Note { get; set; }
    }
}
