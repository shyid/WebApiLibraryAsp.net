using System.ComponentModel.DataAnnotations;

namespace WebApiLibrary.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
