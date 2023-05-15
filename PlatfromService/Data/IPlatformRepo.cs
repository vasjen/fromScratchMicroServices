using PlatfromService.Models;

namespace PlatfromService.Data
{
    public interface IPlatformRepo
    {
        public bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);

        int CreatePlatform(Platform plat);
    }
}