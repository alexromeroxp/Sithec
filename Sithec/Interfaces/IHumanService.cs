using Sithec.Models;

namespace Sithec.Services
{
    public interface IHumanService
    {
        Task<IEnumerable<Human>> GetHumans();
        IEnumerable<Human> GetMockHumans();
        Task<Human> GetHuman(int id);
        Task<bool> UpdateHuman(int id, Human human);
        Task<Human> CreateHuman(Human human);
        Task<bool> DeleteHuman(int id);
    }
}
