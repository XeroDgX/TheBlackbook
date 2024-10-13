using Website.Models;

namespace Website.Interfaces
{
    public interface ISetService
    {
        public Task<bool> CreateSet(Set set);
    }
}
