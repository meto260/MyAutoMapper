using System.Text.Json;

var result1 = new { naME = "adi", suRName = "soyadi", age = 2 }.Map<Person>();
Console.WriteLine(JsonSerializer.Serialize(result1));

var result2 = new { naME = "adi", suRName = "soyadi", age = 2 }.Create();
Console.WriteLine(JsonSerializer.Serialize(result2));

Console.Read();

class Person {
    public string Name { get; set; }
    public string SurName { get; set; }
}