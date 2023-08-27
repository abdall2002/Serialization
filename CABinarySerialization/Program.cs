// See https://aka.ms/new-console-template for more information


using System;
using CABinarySerialization;
using System.Runtime.Serialization.Formatters.Binary;

var e1 = new Employee
{
    Id = 1001,
    Fname = "Issam",
    Lname = "A.",
    Benefits = { "Pension", "Health Insurance" }
};

string binaryContent = NonSerializeToBinaryString(e1);
Console.WriteLine(binaryContent);

Employee e2 = DeserializeFromBinaryContent(binaryContent);

static Employee DeserializeFromBinaryContent(string binaryContent)
{
    byte[] bytes = Convert.FromBase64String(binaryContent);
    using (var stream = new MemoryStream(bytes))
    {
        var binaryFormatter = new BinaryFormatter();
        stream.Seek(0, SeekOrigin.Begin);
        return binaryFormatter.Deserialize(stream) as Employee;

    }
}

static string NonSerializeToBinaryString(Employee employee)
{
    using (var stream = new MemoryStream())
    {
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(stream, employee);
        stream.Flush();
        stream.Position = 0;
        return Convert.ToBase64String(stream.ToArray());
    }
}