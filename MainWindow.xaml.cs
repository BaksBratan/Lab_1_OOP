// MainWindow.xaml.cs
using System.Collections.Generic;
using System.Windows;

namespace LibraryManagementSystem
{
    public partial class MainWindow : Window
    {
        private Library library = new Library();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            int year = int.Parse(txtYear.Text);
            string isbn = txtISBN.Text;

            Book book = new Book(title, author, year, isbn);
            library.AddBook(book);
            MessageBox.Show("Book added successfully.");
            DisplayBooks();
        }

        private void BtnRemoveBook_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txtISBN.Text;
            library.RemoveBook(isbn);
            MessageBox.Show("Book removed successfully.");
            DisplayBooks();
        }
        private void BtnClearForm_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            txtISBN.Clear();
            lstBooks.Items.Clear();
        }


        private void BtnSearchByTitle_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            var books = library.SearchByTitle(title);
            DisplayBooks(books);
        }

        private void BtnSearchByAuthor_Click(object sender, RoutedEventArgs e)
        {
            string author = txtAuthor.Text;
            var books = library.SearchByAuthor(author);
            DisplayBooks(books);
        }

        private void BtnDisplayAllBooks_Click(object sender, RoutedEventArgs e)
        {
            var books = library.GetAllBooks();
            DisplayBooks(books);
        }

        private void DisplayBooks()
        {
            lstBooks.Items.Clear();
            foreach (var book in library.GetAllBooks())
            {
                lstBooks.Items.Add(book.ToString());
            }
        }

        private void DisplayBooks(List<Book> books)
        {
            lstBooks.Items.Clear();
            foreach (var book in books)
            {
                lstBooks.Items.Add(book.ToString());
            }
        }
    }
}