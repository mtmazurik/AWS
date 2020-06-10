using AWSQueueReponook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSQueueReponook.Services
{
    public interface IRepositoryService
    {
        Task Create(string repository, string collection, AWSQueueReponook.Models.Repository repoObject);
        Task Update(string repository, string collection, AWSQueueReponook.Models.Repository repoObject);
        Task Delete(string repository, string collection, string _id);
    }
}