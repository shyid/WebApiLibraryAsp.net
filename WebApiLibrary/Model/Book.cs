using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public bool InLibrart { get; set; }
        public string? Description { get; set; }

        public IList<Category>? Caregories { get; set; }
        public IList<AuthorBook> AuthorBooks { get; set; }
            = new List<AuthorBook>();

    }
}
