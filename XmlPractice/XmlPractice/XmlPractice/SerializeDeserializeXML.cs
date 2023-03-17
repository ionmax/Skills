using System.Xml.Serialization;

namespace XmlPractice
{
    public static class SerializeDeserializeXML
    {
        public static Member DeserializeXmlStringToObject()
        {
            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var reader = new FileStream(@"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\member.xml", FileMode.OpenOrCreate))
            {
                return (Member)xmlSerializer.Deserialize(reader);
            }
        }

        public static void SerializeObjectToXmlFile()
        {
            var member = new Member
            {
                Name = "John",
                Email = "john@gmail.com",
                Age = 30,
                //JoiningDate = DateTime.Now,
                IsPlatinumMember = false
            };

            var xmlSerializer = new XmlSerializer(typeof(Member));
            using (var writer = new FileStream(@"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\member.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, member);
            }
        }

        public static void SerializeListToXmlFile()
        {
            var memberList = new List<Member>
            {
                new Member
                {
                    Name = "John",
                    Email = "john@gmail.com",
                    Age = 30,
                    JoiningDate = DateTime.Now,
                    IsPlatinumMember = false
                },
                new Member
                {
                    Name = "Peter",
                    Email = "peter@gmail.com",
                    Age = 35,
                    JoiningDate = DateTime.Now,
                    IsPlatinumMember = true
                },
                new Member
                {
                    Name = "David",
                    Email = "david@gmail.com",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsPlatinumMember = true
                },
                new Member
                {
                    Name = "George",
                    Email = "george@gmail.com",
                    Age = 29,
                    JoiningDate = DateTime.Now,
                    IsPlatinumMember = false
                }
            };

            var xmlSerializer = new XmlSerializer(typeof(List<Member>));
            using (var writer = new FileStream(@"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\member2.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, memberList);
            }
        }

        public static List<Member> DeserializeXmlFileToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Member>));
            using(var reader = new FileStream(@"C:\temp\skills\XmlPractice\XmlPractice\XmlPractice\member2.xml", FileMode.OpenOrCreate))
            {
                return (List<Member>)xmlSerializer.Deserialize(reader);
            }
        }
    }
}
