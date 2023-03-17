using System.Xml;

namespace XmlPractice
{
    public static class XMLExamples
    {
        public static void ReadXmlDocument ()
        {
            var xDoc = new XmlDocument();
            xDoc.Load("C:\\temp\\skills\\XmlPractice\\XmlPractice\\XmlPractice\\people.xml");

            XmlElement? xRoot = xDoc.DocumentElement; // people
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    Console.WriteLine(attr?.Value);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                        {
                            Console.WriteLine($"Company: {childnode.InnerText}");
                        }
                        if (childnode.Name == "age")
                        {
                            Console.WriteLine($"Age: {childnode.InnerText}");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void ReadXmlDocumentToObject () 
        {
            var people = new List<Person>();

            var xDoc = new XmlDocument();
            xDoc.Load("C:\\temp\\skills\\XmlPractice\\XmlPractice\\XmlPractice\\people.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    Person person = new Person();
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    person.Name = attr?.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                            person.Company = childnode.InnerText;

                        if (childnode.Name == "age")
                            person.Age = int.Parse(childnode.InnerText);
                    }
                    people.Add(person);
                }
                foreach (var person in people)
                    Console.WriteLine($"{person.Name} ({person.Company}) - {person.Age}");
            }
            Console.WriteLine();
        }

        public static void SelectNodes(string selector)
        {
            var xDoc = new XmlDocument();
            xDoc.Load("C:\\temp\\skills\\XmlPractice\\XmlPractice\\XmlPractice\\people.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            XmlNodeList? Nodes = xRoot?.SelectNodes(selector);
            if (Nodes is not null)
            {
                foreach (XmlNode node in Nodes)
                    Console.WriteLine(node.OuterXml);

                foreach (XmlNode node in Nodes)
                    Console.WriteLine(node.InnerText);

                Console.WriteLine();
            }
        }

        public static void SelectSingleNode(string selector)
        {
            var xDoc = new XmlDocument();
            xDoc.Load("C:\\temp\\skills\\XmlPractice\\XmlPractice\\XmlPractice\\people.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            XmlNode? Node = xRoot?.SelectSingleNode(selector);
            if (Node is not null)
            {
                Console.WriteLine(Node.OuterXml);
                Console.WriteLine(Node.InnerText);

                Console.WriteLine();
            }
        }

        public static void CreateNewPersonNode(Person person)
        {
            var filePath = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people.xml";
            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement? xRoot = xDoc.DocumentElement;

            XmlElement personElem = xDoc.CreateElement("person");

            XmlAttribute nameAttr = xDoc.CreateAttribute("name");

            XmlElement companyElem = xDoc.CreateElement("company");
            XmlElement ageElem = xDoc.CreateElement("age");

            XmlText nameText = xDoc.CreateTextNode(person.Name);
            XmlText companyText = xDoc.CreateTextNode(person.Company);
            XmlText ageText = xDoc.CreateTextNode(person.Age.ToString());

            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);

            personElem.Attributes.Append(nameAttr);
            personElem.AppendChild(companyElem);
            personElem.AppendChild(ageElem);

            xRoot?.AppendChild(personElem);

            xDoc.Save(filePath);
        }

        public static void DeleteLastPersonNode()
        {
            var filePath = @"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people.xml";
            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement? xRoot = xDoc.DocumentElement;
            XmlNode? firstNode = xRoot?.LastChild;
            if (firstNode is not null) xRoot?.RemoveChild(firstNode);
            xDoc.Save(filePath);
        }
    }
}
