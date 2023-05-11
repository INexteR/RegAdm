using Model.DTOs;

namespace Model.Interfaces
{
    public interface IRoomTypesRepository : IIdRepository<RoomTypeDto>
    {
        RoomTypeDto? GetTypeForRoom(int roomId);
    }
}
