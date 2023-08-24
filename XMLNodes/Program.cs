using System;
using System.IO;
using System.Text;
using System.Threading;
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

            var extension = Path.GetExtension(fileName);
            if (extension == "")
                fileName = fileName.Trim() + ".xml";
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
                var randomString = CreateRandomString(9).ToLower() + "mahesh.yadav";
                entity.SetAttribute("DisplayName", randomString);
                entity.SetAttribute("Name", "i:0#.f|membership|" + randomString + "@asteroidnepal.com");
                entity.SetAttribute("Sid", "i:0#.f|membership|" + randomString + "@asteroidnepal.com");
                entity.SetAttribute("Email", randomString + "@asteroidnepal.com");
                entity.SetAttribute("IsGroup", randomString.Contains("z")?"True":"False");
                doc.DocumentElement?.AppendChild(entity);
            }

            Console.WriteLine(noOfItems + " users added.");

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

        /// <summary>
        /// Create random string with specified size as parameter
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string CreateRandomString(int size)
        {
            // Required otherwise it creates same value
            Thread.Sleep(1);
            var builder = new StringBuilder();
            var random = new Random();

            for (var i = 0; i < size; i++)
            {
                var c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }

            var randomString = builder.ToString();
            //Console.WriteLine(randomString);
            return randomString;
        }
    }
}