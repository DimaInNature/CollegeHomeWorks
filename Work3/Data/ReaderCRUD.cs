using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Work3.Models;

namespace Work3.Data
{
    public sealed class ReaderCRUD
    {
        public static void Create(Reader author)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Readers.xml");
                XElement root = xdoc.Element("Readers");

                root.Add(new XElement("Reader",
                            new XAttribute("Id", author.Id),
                            new XElement("Name", author.Name),
                            new XElement("Surname", author.Surname),
                            new XElement("Patronymic", author.Patronymic),
                            new XElement("Phone", author.Phone),
                            new XElement("BirthDay", author.BirthDay),
                            new XElement("DateOfTaking", author.DateOfTaking),
                            new XElement("Books", new XAttribute("Id", author.Book.Id))
                            ));

                xdoc.Save("Readers.xml");
            }
            catch { }
        }

        public static List<Reader> Read()
        {
            try
            {
                XDocument xdoc = XDocument.Load("Readers.xml");

                List<Reader> readers = new List<Reader>();

                foreach (XElement element in xdoc.Element("Readers").Elements("Reader"))
                {
                    Reader newReader = new Reader
                    {
                        Id = (int)element.Attribute("Id"),
                        Name = (string)element.Element("Name"),
                        Surname = (string)element.Element("Surname"),
                        Patronymic = (string)element.Element("Patronymic"),
                        Phone = (string)element.Element("Phone"),
                        BirthDay = (DateTime)element.Element("BirthDay"),
                        DateOfTaking = (DateTime)element.Element("DateOfTaking")
                    };

                    newReader.FullName = 
                        $"{newReader.Name} {newReader.Surname} {newReader.Patronymic}";

                    readers.Add(newReader);
                }

                return readers;
            }
            catch
            {
                return new List<Reader>();
            }
        }

        public static List<Reader> ReadByFullName(string name,
            string surname, string patronymic)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Readers.xml");

                List<Reader> readers = new List<Reader>();

                foreach (XElement element in xdoc.Element("Readers").Elements("Reader"))
                {
                    if(element.Element("Name").Value == name &&
                        element.Element("Surname").Value == surname &&
                        element.Element("Patronymic").Value == patronymic )
                    {
                        Reader newReader = new Reader
                        {
                            Id = (int)element.Attribute("Id"),
                            Name = (string)element.Element("Name"),
                            Surname = (string)element.Element("Surname"),
                            Patronymic = (string)element.Element("Patronymic"),
                            Phone = (string)element.Element("Phone"),
                            BirthDay = (DateTime)element.Element("BirthDay"),
                            DateOfTaking = (DateTime)element.Element("DateOfTaking")
                        };

                        newReader.FullName = $"{newReader.Name}" +
                            $" {newReader.Surname} {newReader.Patronymic}";
                        readers.Add(newReader);
                    }            
                }

                return readers;
            }
            catch
            {
                return new List<Reader>();
            }
        }

        public static void Update(Reader reader)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Readers.xml");
                XElement root = xdoc.Element("Readers");

                foreach (XElement element in root.Elements("Reader"))
                {
                    if (element.Attribute("Id").Value == reader.Id.ToString())
                    {
                        element.Element("Name").Value = reader.Name;
                        element.Element("Surname").Value = reader.Surname;
                        element.Element("Patronymic").Value = reader.Patronymic;
                        element.Element("Phone").Value = reader.Phone;
                        element.Element("BirthDay").Value = reader.BirthDay.ToString();
                    }
                }

                xdoc.Save("Readers.xml");
            }
            catch { }    
        }

        public static void Delete(int id)
        {
            try
            {
                XDocument xdoc = XDocument.Load("Readers.xml");
                XElement root = xdoc.Element("Readers");

                foreach (XElement element in root.Elements("Reader"))
                {
                    if (element.Attribute("Id").Value == id.ToString())
                    {
                        element.Remove();
                    }
                }

                xdoc.Save("Readers.xml");
            }
            catch { }
        }
    }
}