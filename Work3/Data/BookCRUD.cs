using System.Collections.Generic;
using System.Xml.Linq;
using Work3.Models;

namespace Work3.Data
{
    public sealed class BookCRUD
    {
        public static void Create(Book book)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");
                XElement root = xdoc.Element("Books");

                root.Add(new XElement("Book",
                            new XAttribute("Id", book.Id),
                            new XElement("Name", book.Name),
                            new XElement("Genre", book.Genre),
                            new XElement("AgeRestriction", book.AgeRestriction),
                            new XElement("IdAuthor", book.IdAuthor)));

                xdoc.Save("Books.xml");
            }
            catch { }
        }

        public static List<Book> Read()
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");

                List<Book> books = new List<Book>();

                foreach (XElement element in xdoc.Element("Books").Elements("Book"))
                {
                    Book newBook = new Book
                    {
                        Id = (int)element.Attribute("Id"),
                        Name = (string)element.Element("Name"),
                        Genre = (string)element.Element("Genre"),
                        AgeRestriction = (int)element.Element("AgeRestriction"),
                        IdAuthor = (int)element.Element("IdAuthor")
                    };

                    books.Add(newBook);
                }

                return books;
            }
            catch
            {
                return new List<Book>();
            }
        }

        public static List<Book> ReadByIdAuthor(int id)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");

                List<Book> books = new List<Book>();

                foreach (XElement element in xdoc.Element("Books").Elements("Book"))
                {
                    if (element.Element("IdAuthor").Value == id.ToString())
                    {
                        Book newBook = new Book
                        {
                            Id = (int)element.Attribute("Id"),
                            Name = (string)element.Element("Name"),
                            Genre = (string)element.Element("Genre"),
                            AgeRestriction = (int)element.Element("AgeRestriction"),
                            IdAuthor = (int)element.Element("IdAuthor")
                        };

                        books.Add(newBook);
                    }
                    
                }

                return books;
            }
            catch
            {
                return new List<Book>();
            }
        }

        public static void Update(Book book)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");
                XElement root = xdoc.Element("Books");

                foreach (XElement element in root.Elements("Book"))
                {
                    if (element.Attribute("Id").Value == book.Id.ToString())
                    {
                        element.Element("Name").Value = book.Name;
                        element.Element("Genre").Value = book.Genre;
                        element.Element("AgeRestriction").Value = book.AgeRestriction.ToString();
                        element.Element("IdAuthor").Value = book.IdAuthor.ToString();
                    }
                }

                xdoc.Save("Books.xml");
            }
            catch { }
        }

        public static void Delete(int id)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");
                XElement root = xdoc.Element("Books");

                foreach (XElement element in root.Elements("Book"))
                {
                    if (element.Attribute("Id").Value == id.ToString())
                    {
                        element.Remove();
                    }
                }

                xdoc.Save("Books.xml");
            }
            catch { }
        }

        public static void DeleteByIdAuthor(int id)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Books.xml");
                XElement root = xdoc.Element("Books");

                foreach (XElement element in root.Elements("Book"))
                {
                    if (element.Element("IdAuthor").Value == id.ToString())
                    {
                        element.Remove();
                    }
                }

                xdoc.Save("Books.xml");
            }
            catch { }
        }
    }
}