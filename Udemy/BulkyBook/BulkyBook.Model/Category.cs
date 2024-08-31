using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="It must be between 1 to 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
