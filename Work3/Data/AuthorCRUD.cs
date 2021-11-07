using System.Collections.Generic;
using System.Xml.Linq;
using Work3.Models;

namespace Work3.Data
{
    public sealed class AuthorCRUD
    {
        public static void Create(Author author)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Authors.xml");
                XElement root = xdoc.Element("Authors");

                root.Add(new XElement("Author",
                            new XAttribute("Id", author.Id),
                            new XElement("Name", author.Name),
                            new XElement("Surname", author.Surname),
                            new XElement("Patronymic", author.Patronymic)
                            ));

                xdoc.Save("Authors.xml");
            }
            catch { }
        }

        public static List<Author> Read()
        {
            try
            {
                XDocument xdoc = XDocument.Load("Authors.xml");

                List<Author> authors = new List<Author>();

                foreach (XElement element in xdoc.Element("Authors").Elements("Author"))
                {
                    Author newAuthor = new Author
                    {
                        Id = (int)element.Attribute("Id"),
                        Name = (string)element.Element("Name"),
                        Surname = (string)element.Element("Surname"),
                        Patronymic = (string)element.Element("Patronymic")
                    };

                    newAuthor.FullName = $"{newAuthor.Name} {newAuthor.Surname} {newAuthor.Patronymic}";

                    authors.Add(newAuthor);
                }

                return authors;
            }
            catch
            {
                return new List<Author>();
            }
        }

        public static void Update(Author author)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Authors.xml");
                XElement root = xdoc.Element("Authors");

                foreach (XElement element in root.Elements("Author"))
                {
                    if (element.Attribute("Id").Value == author.Id.ToString())
                    {
                        element.Element("Name").Value = author.Name;
                        element.Element("Surname").Value = author.Surname;
                        element.Element("Patronymic").Value = author.Patronymic;
                    }
                }

                xdoc.Save("Authors.xml");
            }
            catch { }
        }

        public static void Delete(int id)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Authors.xml");
                XElement root = xdoc.Element("Authors");

                foreach (XElement element in root.Elements("Author"))
                {
                    if (element.Attribute("Id").Value == id.ToString())
                    {
                        element.Remove();
                    }
                }

                xdoc.Save("Authors.xml");
            }
            catch { }
        }
    }
}