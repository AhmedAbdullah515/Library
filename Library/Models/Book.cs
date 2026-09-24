using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        [Range(1900,2026)]
        public int PublishedYear { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; }= new List<BorrowRecord>();

    }
}
