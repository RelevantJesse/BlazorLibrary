using BlazorLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLibrary.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task AddNewBook(Book book)
        {
            book.Author = _context.Authors.FirstOrDefault(a => a.Id == book.Author.Id);

            await _context.AddAsync(book);
            await _context.SaveChangesAsync();
        }
    }
}
