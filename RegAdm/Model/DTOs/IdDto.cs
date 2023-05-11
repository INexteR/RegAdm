namespace Model.DTOs
{
    public abstract class IdDto
    {
        public int Id { get; }

        public IdDto(int id)
        {
            Id = id;
        }
    }
}
