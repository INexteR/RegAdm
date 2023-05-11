using Model.DTOs;

namespace Model.Interfaces
{
    public interface IUsersRepository : IIdRepository<UserDto>
    {
        UserDto? GetUserForReservation(int reservationId);
    }
}
