using Bogus;
using BookShop.Entities;
using BookShop.Enums;
using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookShop.Console
{
    public class BookShopRepository
    {
        private readonly BookShopContext _context;
        public BookShopRepository(BookShopContext context)
        {
            _context = context;
        }

        //query 1
        public async Task<List<Book>> GetBooksByAgeRestriction(AgeRestriction ageRestriction)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == ageRestriction)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query 2
        public async Task<List<Book>> GetGoldenBooks()
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.EditionType == EditionType.Gold)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query 3
        public async Task<List<Book>> GetBooksByPrice()
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query 4
        public async Task<List<Book>> GetBooksNotReleasedIn(int year)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate.Year != year)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query 5
        public async Task<List<Book>> GetBooksByCategory(List<string> categories)
        {
            List<Guid> categoriesId = new List<Guid>();

            for (int i = 0; i < categories.Count; i++)
            {
                var result = await _context
                    .Categories
                    .Where(c => c.Name == categories[i])
                    .Select(c => c.ID)
                    .ToListAsync();

                categoriesId.AddRange(result);
            }

            List<BookCategory> bookCategories = new List<BookCategory>();

            if (categoriesId.Count > 0)
                for (int i = 0; i < categoriesId.Count; i++)
                {
                    var result = await _context
                        .BookCategories
                        .Where(bc => bc.CategoryId == categoriesId[i])
                        .ToListAsync();

                    bookCategories.AddRange(result);
                }

            List<Book> books = new List<Book>();

            if (bookCategories.Count > 0)
                for (int i = 0; i < bookCategories.Count; i++)
                {
                    var result = await _context
                        .Books
                        .Where(b => b.ID == bookCategories[i].BookId)
                        .ToListAsync();

                    books.AddRange(result);
                }

            if (books is not null) { return books.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query6
        public async Task<List<Book>> GetBooksReleasedBefore(int day, int month, int year)
        {
            var result = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate.Year < year
                         && b.ReleaseDate.Month < month
                         && b.ReleaseDate.Day < day)
                .ToListAsync();

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query7
        public async Task<List<string>> GetAuthorNamesEndingIn(string input)
        {
            var authors = await _context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            foreach (var author in authors)
            {
                result.Add(author.FirstName + " " + author.LastName);
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query8
        public async Task<List<string>> GetBookTitlesContaining(string input)
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var bookTitles = new List<string>();

            foreach (var book in books)
            {
                bookTitles.Add(book.Title);
            }

            var result = new List<string>();

            foreach (var bookTitle in bookTitles)
            {
                if (bookTitle.Contains(input))
                    result.Add(bookTitle);
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query9
        public async Task<List<string>> GetBooksByAuthor(string input)
        {
            var authors = await _context
                .Authors
                .Where(a => a.LastName.StartsWith(input))
                .AsNoTracking()
                .ToListAsync();

            var allBooks = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            for (int i = 0; i < allBooks.Count; i++)
            {
                for (int j = 0; j < authors.Count; j++)
                {
                    if (allBooks[i].AuthorId == authors[j].ID)
                    {
                        result.Add($"{allBooks[i].Title} - {authors[j].FirstName} {authors[j].LastName}");
                    }
                }
            }

            if (result is not null) { return result.ToList(); }
            else { throw new NullReferenceException(); }
        }

        //query10
        public async Task<int> CountBooks(int length)
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Title.Length > length)
                .ToListAsync();

            if (books is not null) { return books.Count; }
            else { throw new NullReferenceException(); }
        }

        //query11
        public async Task<List<string>> CountCopiesByAuthor()
        {
            var authors = await _context
                .Authors
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            for (int i = 0; i < authors.Count; i++)
            {
                int copies = 0;

                for (int j = 0; j < books.Count; j++)
                {
                    if (authors[i].ID == books[j].AuthorId)
                    {
                        copies += books[j].Copies;

                        result.Add($"{authors[j].FirstName} {authors[j].LastName} - {copies}");
                    }
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }
        }

        //query12
        public async Task<List<string>> GetTotalProfitByCategory()
        {
            var bookCategories = await _context
                .BookCategories
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            for (int i = 0; i < bookCategories.Count; i++)
            {
                decimal totalPrice = 0;

                var categoryName = await _context
                    .Categories
                    .AsNoTracking()
                    .Where(c => c.ID == bookCategories[i].CategoryId)
                    .Select(c => c.Name)
                    .FirstOrDefaultAsync();

                for (int j = 0; j < books.Count; j++)
                {
                    if (bookCategories[i].BookId == books[j].ID)
                    {
                        totalPrice += books[j].Price;

                        result.Add($"{categoryName} - {totalPrice}$");
                    }
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }

        }

        //query13
        public async Task<List<string>> GetMostRecentBooks()
        {
            var bookCategories = await _context
                .BookCategories
                .AsNoTracking()
                .ToListAsync();

            var books = await _context
                .Books
                .AsNoTracking()
                .ToListAsync();

            var result = new List<string>();

            for (int i = 0; i < bookCategories.Count; i++)
            {
                var category = await _context
                    .Categories
                    .AsNoTracking()
                    .Where(c => c.ID == bookCategories[i].CategoryId)
                    .FirstOrDefaultAsync();

                var mostRecentBooks = await _context
                    .Books
                    .AsNoTracking()
                    .Where(b => b.ID == bookCategories[i].BookId)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToListAsync();

                result.Add($"{category.Name}: ");

                for (int j = 0; j < mostRecentBooks.Count; j++)
                {
                    result.Add($"{mostRecentBooks[j].Title} - {mostRecentBooks[j].ReleaseDate}");
                }
            }

            if (result is not null) { return result; }
            else { throw new NullReferenceException(); }
        }

        //query14
        public async Task IncreasePrices()
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate.Year < 2010)
                .ToListAsync();

            if (books is not null)
            {
                books.ForEach(x => {
                    x.Price += 5;
                });
            }

            await _context.SaveChangesAsync();
        }

        //query15
        public async Task<int> RemoveBooks()
        {
            var books = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Copies < 4200)
                .ToListAsync();

            var result = books.Count;

            var booksToDelete = await _context
                .Books
                .AsNoTracking()
                .Where(b => b.Copies < 4200)
                .ExecuteDeleteAsync();

            if (result is not 0) { return result; }
            else { throw new NullReferenceException(); }
        }
    }
}
