using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface ISetService
    {
        public Task<Result<bool>> CreateSet(Set set);
    }
}
