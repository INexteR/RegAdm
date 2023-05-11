using Model.DTOs;

namespace Model.Interfaces
{
    public interface IClientsRepository : IIdRepository<ClientDto>
    {
        IEnumerable<ClientDto> GetClientsForReservation(int reservationId);
    }
}
