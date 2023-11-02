namespace WebApiLibrary.Data.DTO
{
    public class DTOCategory
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }

        public int BookId { get; set; }
    }
}
