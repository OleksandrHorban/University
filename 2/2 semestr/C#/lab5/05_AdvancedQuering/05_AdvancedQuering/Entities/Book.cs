using BookShop.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int Copies { get; set; }
        public decimal Price { get; set; }
        public EditionType EditionType { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public ICollection<BookCategory> BookCategories { get; set; } = null!;
    }
}