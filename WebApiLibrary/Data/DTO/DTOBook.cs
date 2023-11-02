using WebApiLibrary.Model;

namespace WebApiLibrary.Data.DTO
{
    public class DTOBook
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public bool InLibrart { get; set; }
        public string? Description { get; set; }

        public IList<DTOCategory>? Caregories { get; set; }
    }
}
