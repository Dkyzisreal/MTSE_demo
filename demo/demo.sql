-- Create the database
CREATE DATABASE BookstoreDB;
GO
select * from books;
-- Use the database
USE BookstoreDB;
GO

-- Create the authors table
CREATE TABLE authors (
  author_id INT PRIMARY KEY,
  author_name VARCHAR(100) NOT NULL
);
GO

-- Create the categories table
CREATE TABLE categories (
  category_id INT PRIMARY KEY,
  category_name VARCHAR(100) NOT NULL
);
GO

-- Create the books table
CREATE TABLE books (
  book_id INT PRIMARY KEY,
  book_title VARCHAR(200) NOT NULL,
  author_id INT NOT NULL,
  category_id INT NOT NULL,
  price DECIMAL(10, 2) NOT NULL,
  published_date DATE NOT NULL,
  FOREIGN KEY (author_id) REFERENCES authors(author_id),
  FOREIGN KEY (category_id) REFERENCES categories(category_id)
);
GO

-- Insert sample data into the authors table
INSERT INTO authors (author_id, author_name)
VALUES
  (1, 'J.K. Rowling'),
  (2, 'George R.R. Martin'),
  (3, 'Harper Lee');
GO

-- Insert sample data into the categories table
INSERT INTO categories (category_id, category_name)
VALUES
  (1, 'Fantasy'),
  (2, 'Mystery'),
  (3, 'Classic');
GO

-- Insert sample data into the books table
INSERT INTO books (book_id, book_title, author_id, category_id, price, published_date)
VALUES
  (1, 'Harry Potter and the Philosopher''s Stone', 1, 1, 19.99, '1997-06-26'),
  (2, 'A Game of Thrones', 2, 1, 24.99, '1996-08-01'),
  (3, 'To Kill a Mockingbird', 3, 3, 14.99, '1960-07-11');
GO