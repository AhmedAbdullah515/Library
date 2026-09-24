using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.BookDTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
      
        public string Title { get; set; }
   
        public string Author { get; set; }
       
        public int PublishedYear { get; set; }
       
        public double Price { get; set; }
       
        public int AvailableCopies { get; set; }
        public string CategoryName {  get; set; }
    }
}
