// Library.cs
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author.Contains(author, System.StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}