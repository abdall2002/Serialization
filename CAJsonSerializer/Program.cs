// See https://aka.ms/new-console-template for more information



using System;
using CAJsonSerializer;
using Newtonsoft.Json;
using System.Text.Json;

var e1 = new Employee
{
    Id = 1001,
    Fname = "Issam",
    Lname = "A.",
    Benefits = { "Pension", "Health Insurance" }
};
var jsonContent = SerializeToJsonStringUsingNewSoftJson(e1);
Console.WriteLine("content json using newtonsoft");
Console.WriteLine("-----------------------------");
Console.WriteLine(jsonContent);

var e2 = DeserializeToJsonStringNewSoftJson(jsonContent);
Console.WriteLine("content json using Json.Net");
Console.WriteLine("-----------------------------");
var jsonContent2 = SerializeToJsonStringUsingJSONNET(e1);
Console.WriteLine(jsonContent2);

var e3 = DeserializeToJsonStringJSONNET(jsonContent2);

static string SerializeToJsonStringUsingNewSoftJson(Employee employee)
{
    var result = "";
    result = JsonConvert.SerializeObject(employee, Formatting.Indented);

    return result;

}
static Employee DeserializeToJsonStringNewSoftJson(string jsonContent)
{
    Employee employee = null;
    employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
    return employee;
}

static string SerializeToJsonStringUsingJSONNET(Employee employee)
{
    var result = "";
    result = System.Text.Json.JsonSerializer.Serialize(employee,
        new JsonSerializerOptions { WriteIndented = true });

    return result;

}
static Employee DeserializeToJsonStringJSONNET(string jsonContent)
{
    Employee employee = null;
    employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
    return employee;
}





