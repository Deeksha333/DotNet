using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        //These all are property of Movie class
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)] //DataType is an attribute that specifie the type of data
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}