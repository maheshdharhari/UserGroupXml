using System;
using System.Text;
using System.Xml;

namespace UserGroupXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter xml file name: ");
            var fileName = Console.ReadLine();
            if (fileName == null)
            {
                return;
            }
            fileName= fileName.Trim()+".xml";
            CreateXmlFile(fileName);
            var doc = new XmlDocument();
            doc.Load(fileName);
            Console.WriteLine("How many users do you want to be created: ");
            // Read no of users
            var val = Console.ReadLine();
            var noOfItems = Convert.ToInt32(val);
            // Add users
            for (var i = 1; i <= noOfItems; i++)
            {
                var entity = doc.CreateElement("Entity");
                entity.SetAttribute("DisplayName", "Mahesh Yadava" + i);
                entity.SetAttribute("Name", "i:0#.f|membership|Mahesh.Yadava" + i + "@asteroidnepal.com");
                entity.SetAttribute("Sid", "i:0#.f|membership|Mahesh.Yadava" + i + "@asteroidnepal.com");
                entity.SetAttribute("Email", "Mahesh.Yadava" + i + "@asteroidnepal.com");
                doc.DocumentElement?.AppendChild(entity);
            }

            Console.WriteLine(noOfItems+ " users added.");

            doc.Save(fileName);
            Console.ReadLine();

            // Create xml file
            void CreateXmlFile(string file)
            {
                var writer = new XmlTextWriter(file, Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Entities");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                Console.WriteLine("XML File created!");
            }
        }
    }
}