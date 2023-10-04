using demo.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

public class BookDAL
{
    private string connectionString;

    public BookDAL()
    {
        connectionString = "Server =.; Database = BookstoreDB; Trusted_Connection = True; Encrypt = False";
    }
    public void CreateBook(Book book)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO books (book_id, book_title, author_id, category_id, price, published_date) " +
                "VALUES (@BookId, @Title, @AuthorId, @CategoryId, @Price, @PublishedDate)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@BookId", SqlDbType.Int).Value = book.BookId;
            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = book.BookTitle;
            command.Parameters.Add("@AuthorId", SqlDbType.Int).Value = book.AuthorId;
            command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = book.CategoryId;
            command.Parameters.Add("@Price", SqlDbType.Decimal).Value = book.Price;
            command.Parameters.Add("@PublishedDate", SqlDbType.Date).Value = book.PublishedDate;

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public Book GetBookById(int bookId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM books WHERE book_id = @BookId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Book book = new Book
                {
                    BookId = (int)reader["book_id"],
                    BookTitle = (string)reader["book_title"],
                    AuthorId = (int)reader["author_id"],
                    CategoryId = (int)reader["category_id"],
                    Price = (decimal)reader["price"],
                    PublishedDate = (DateTime)reader["published_date"]
                };

                reader.Close();
                return book;
            }

            reader.Close();
            return null;
        }
    }

    public List<Book> GetAllBooks()
    {
        List<Book> books = new List<Book>();

        using (var connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM books";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book book = new Book
                {
                    BookId = (int)reader["book_id"],
                    BookTitle = (string)reader["book_title"],
                    AuthorId = (int)reader["author_id"],
                    CategoryId = (int)reader["category_id"],
                    Price = (decimal)reader["price"],
                    PublishedDate = (DateTime)reader["published_date"]
                };

                books.Add(book);
            }

            reader.Close();
        }

        return books;
    }
    public void DeleteBook(int bookId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM books WHERE book_id = @BookId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@BookId", SqlDbType.Int).Value = bookId;

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    public void UpdateBook(Book book)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE books SET book_title = @Title, author_id = @AuthorId, category_id = @CategoryId, " +
                "price = @Price, published_date = @PublishedDate WHERE book_id = @BookId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("@Title", SqlDbType.VarChar).Value = book.BookTitle;
            command.Parameters.Add("@AuthorId", SqlDbType.Int).Value = book.AuthorId;
            command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = book.CategoryId;
            command.Parameters.Add("@Price", SqlDbType.Decimal).Value = book.Price;
            command.Parameters.Add("@PublishedDate", SqlDbType.Date).Value = book.PublishedDate;
            command.Parameters.Add("@BookId", SqlDbType.Int).Value = book.BookId;

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
