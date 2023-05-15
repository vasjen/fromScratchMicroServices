using PlatfromService.Dtos;
using PlatfromService.Models;

namespace PlatfromService
{
    public static class Extensions
    {
        public static ReadPlatformDto AsDto (this Platform item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            return new ReadPlatformDto(item.Id,item.Name, item.Publisher,item.Cost);
        } 
         public static IEnumerable<ReadPlatformDto> AsDtoList (this IEnumerable<Platform> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            List<ReadPlatformDto> ListDto = new();
            foreach (var item in items)
                ListDto.Add(item.AsDto());
            
            return ListDto;
        } 

        public static Platform DtoAs(this CreatePlatformDto item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return new Platform { Name = item.Name, Publisher = item.Publisher, Cost = item.Cost};
        }
    }
}