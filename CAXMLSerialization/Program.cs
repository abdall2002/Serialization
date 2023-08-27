// See https://aka.ms/new-console-template for more information

using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Xml;
using CAXMLSerialization;

var e1 = new Employee
{
   Id = 1001,
   Fname = "Issam",
   Lname = "A.",
   Benefits = { "Pension", "Health Insurance" }
};

var xmlContent = SerializeToXmlString(e1);
Console.WriteLine(xmlContent);
File.WriteAllText("xmlDocument.xml", xmlContent);

var xmlContent2 = File.ReadAllText("xmlDocument.xml");
Employee e2 = DeserializeFromXmlString(xmlContent2);

/* Serialization */
static string SerializeToXmlString(Employee e1)
{
    var result = "";
    var xmlSerializer = new XmlSerializer(e1.GetType());
    using (var sw = new StringWriter())
    {
        using (var writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = false }))
        {
            xmlSerializer.Serialize(writer, e1);
            result = sw.ToString();
        }
    }
    return result;
}
/* Deserialization */
static Employee DeserializeFromXmlString(string xmlContent)
{
    Employee employee = null;
    var xmlSerializer = new XmlSerializer(typeof(Employee));
    using (TextReader reader = new StringReader(xmlContent))
    {
        employee = xmlSerializer.Deserialize(reader) as Employee;
    }
    return employee;
}
