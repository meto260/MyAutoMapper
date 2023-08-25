# MyAutoMapper

# Install
```
NuGet\Install-Package MyAutoMapper -Version 1.0.0
```
version of package for use last version see https://www.nuget.org/packages/MyAutoMapper/1.0.0

# How to use
```using System.Text.Json;

var result1 = new { naME = "adi", suRName = "soyadi", age = 2 }.Map<Person>();
Console.WriteLine(JsonSerializer.Serialize(result1));

var result2 = new { naME = "adi", suRName = "soyadi", age = 2 }.Create();
Console.WriteLine(JsonSerializer.Serialize(result2));

Console.Read();

class Person {
    public string Name { get; set; }
    public string SurName { get; set; }
}
```
<code>Output</code>
```
{"Name":"adi","SurName":"soyadi"}
{"name":"adi","surname":"soyadi","age":2}
