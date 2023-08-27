﻿using System.Text.Json;

var result1 = new { naME = "adi", suRName = "soyadi", age = 2 }.Map<Person>();
Console.WriteLine(JsonSerializer.Serialize(result1));
//output:{"Name":"adi","SurName":"soyadi"}

var result2 = new { naME = "adi", suRName = "soyadi", age = 2 }.Create();
Console.WriteLine(JsonSerializer.Serialize(result2));
//output:{"name":"adi","surname":"soyadi","age":2}

var result3 = new Person { Name = "nm", SurName = "snm" };
Console.WriteLine(JsonSerializer.Serialize(result3.Set("Name", "xxx")));
//output:{"Name":"xxx","SurName":"snm"}

Console.WriteLine(result3.Get("SurName"));
//output:snm

Console.Read();

class Person {
    public string Name { get; set; }
    public string SurName { get; set; }
}