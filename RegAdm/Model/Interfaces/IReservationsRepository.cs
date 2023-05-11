using Model.DTOs;

namespace Model.Interfaces
{
    public interface IReservationsRepository : IIdRepository<ReservationDto>
    {
        IEnumerable<ReservationDto> GetReservationsForClient(int clientId);
        IEnumerable<ReservationDto> GetReservationsForRoom(int roomId);
        IEnumerable<ReservationDto> GetReservationsForUser(int userId);
    }
}
