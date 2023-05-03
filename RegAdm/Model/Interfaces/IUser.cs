
namespace Model.Interfaces
{
    public interface IUser
    {
        int Id { get; }

        string FullName { get; }

        DateOnly BirthDate { get; }

        string Login { get; }

        string Password { get; }

        string Role { get; }
    }
}
