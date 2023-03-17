using System.Reflection.Metadata;
using System.Xml.Linq;

namespace XmlPractice
{
    public static class XExamples
    {
        public static void CreateNewDocument(string path)
        {
            XDocument xdoc = new XDocument(new XElement("people",
                new XElement("person",
                    new XAttribute("name", "Tom"),
                    new XElement("company", "Microsoft"),
                    new XElement("age", 37)),
                new XElement("person",
                    new XAttribute("name", "Bob"),
                    new XElement("company", "Google"),
                    new XElement("age", 41))));

            xdoc.Save(path);
        }

        public static void ReadPeopleByCompany(string company)
        {
            var path = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people2.xml";
            XDocument xdoc = XDocument.Load(path);

            var microsoft = xdoc.Element("people")?   
                .Elements("person")                                                  
                .Where(p => p.Element("company")?.Value == company)
                .Select(p => new 
                {
                    name = p.Attribute("name")?.Value,
                    age = p.Element("age")?.Value,
                    company = p.Element("company")?.Value
                });

            if (microsoft is not null)
            {
                foreach (var person in microsoft)
                {
                    Console.WriteLine($"Name: {person.name}  Age: {person.age}");
                }

                Console.WriteLine();
            }
        }

        public static void CreateNewPersonNode(Person person) 
        {
            var path = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people2.xml";
            var xdoc = XDocument.Load(path);
            XElement? root = xdoc.Element("people");

            if (root != null)
            {
                root.Add(new XElement("person",
                            new XAttribute("name", person.Name),
                            new XElement("company", person.Company),
                            new XElement("age", person.Age)));

                xdoc.Save(path);
            }
        }

        public static void UpdatePersonNode(Person person)
        {
            var path = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people2.xml";
            var xdoc = XDocument.Load(path);

            var node = xdoc.Element("people")?
                .Elements("person")
                .FirstOrDefault(p => p.Attribute("name")?.Value == person.Name);

            if (node != null)
            {
                var age = node.Element("age");
                if (age != null) age.Value = person.Age.ToString();

                var company = node.Element("company");
                if (company != null) company.Value = person.Company;

                xdoc.Save(path);
            }
        }

        public static void RemovePersonNode(Person person)
        {
            var path = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people2.xml";
            var xdoc = XDocument.Load(path);

            var node = xdoc.Element("people")?
                .Elements("person")
                .FirstOrDefault(p => p.Attribute("name")?.Value == person.Name);

            if (node != null)
            {
                node.Remove();

                xdoc.Save(path);
            }
        }
    }
}
