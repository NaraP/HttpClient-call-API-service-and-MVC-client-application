using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SampleDbContext _sampleDbContext;
        public ProjectRepository(SampleDbContext sampleDbContext)
        {
            _sampleDbContext = sampleDbContext;
        }
        public async Task<int> AddProject(Projecttype projecttype)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            string connectionString = "User ID=abbadmin@abbrcsdatabse;Password=relcare123#;Host=abbrcsdatabse.postgres.database.azure.com;Port=5432;Database=SampleDb;Pooling=true";

            optionsBuilder.UseNpgsql(connectionString);

            using (var context = new SampleDbContext(optionsBuilder.Options))
            {
                await context.Projecttype.AddAsync(projecttype);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteProject(Projecttype projecttype)
        {
            var projects = await _sampleDbContext.Projecttype.Where(x => x.ProjectId.Equals(projecttype.ProjectId)).FirstOrDefaultAsync();
            _sampleDbContext.Remove(projects);
            return await _sampleDbContext.SaveChangesAsync();
        }

        public async Task<List<Projecttype>> GetAllProjects()
        {
            return await _sampleDbContext.Projecttype.ToListAsync();
        }

        public async Task<int> Updateroject(Projecttype projecttype)
        {
            var projects = await _sampleDbContext.Projecttype.Where(x => x.ProjectId.Equals(projecttype.ProjectId)).FirstOrDefaultAsync();
            _sampleDbContext.Update(projects);
            return await _sampleDbContext.SaveChangesAsync();
        }
    }
}
