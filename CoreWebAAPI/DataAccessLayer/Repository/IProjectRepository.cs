using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IProjectRepository
    {
        Task<int> AddProject(Projecttype projecttype);
        Task<int> Updateroject(Projecttype projecttype);
        Task<int> DeleteProject(Projecttype projecttype);
        Task<List<Projecttype>> GetAllProjects();

    }
}
