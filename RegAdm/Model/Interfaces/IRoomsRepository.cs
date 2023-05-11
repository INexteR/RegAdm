using Model.DTOs;

namespace Model.Interfaces
{
    public interface IRoomsRepository : IIdRepository<RoomDto>
    {
        RoomDto? GetRoomForReservation(int reservationId);
        IEnumerable<RoomDto> GetRoomsForType(int roomTypeId);
    }
}
