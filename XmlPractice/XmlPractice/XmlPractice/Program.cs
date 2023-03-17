using XmlPractice;

#region XML 
//Examples.ReadXmlDocument();
//XMLExamples.ReadXmlDocumentToObject();

//XMLExamples.CreateNewPersonNode(new Person { Name = "Misha", Company = "Creatio", Age = 21});
//XMLExamples.ReadXmlDocumentToObject();
//XMLExamples.SelectSingleNode("person[@name='Misha']");

//XMLExamples.DeleteLastPersonNode();
//XMLExamples.ReadXmlDocumentToObject();

//XMLExamples.SelectNodes("//person/company");

#endregion


#region Linq to XML
//XExamples.CreateNewDocument(@"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\people2.xml");

//XExamples.ReadPeopleByCompany("Microsoft");

//var mark = new Person { Name = "Mark", Company = "Microsoft", Age = 35 };
//XExamples.CreateNewPersonNode(mark);
//XExamples.ReadPeopleByCompany("Microsoft");

//mark.Age = 40;
//XExamples.UpdatePersonNode(mark);
//XExamples.ReadPeopleByCompany("Microsoft");

//XExamples.RemovePersonNode(mark);
//XExamples.ReadPeopleByCompany("Microsoft");

#endregion


#region Serialization

SerializeDeserializeXML.SerializeObjectToXmlFile();
SerializeDeserializeXML.SerializeListToXmlFile();

var member = SerializeDeserializeXML.DeserializeXmlStringToObject();
var list = SerializeDeserializeXML.DeserializeXmlFileToList();

Console.WriteLine();

#endregion