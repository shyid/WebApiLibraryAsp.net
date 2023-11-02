using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }

        public IList<AuthorBook> AuthorBooks { get; set; } 
            = new List<AuthorBook>();
    }
}
