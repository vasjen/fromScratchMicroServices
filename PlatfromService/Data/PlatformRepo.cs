using PlatfromService.Models;

namespace PlatfromService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public int CreatePlatform(Platform plat)
        {
            if (plat == null)
                throw new ArgumentNullException(nameof(plat));

            _context.Platforms.Add(plat);
            Console.WriteLine("New item with id: {0} added to DB",plat.Id);

            return plat.Id;
     
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(item => item.Id == id);
        }

        public bool SaveChanges()
        {
            return  (_context.SaveChanges() >= 0);
        }
    }
}