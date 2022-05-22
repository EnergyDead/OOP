// See https://aka.ms/new-console-template for more information
using ExtensionMethods;

Console.WriteLine("Hello, World!");

var studName = new string[] { "Bob", "Max", "Julli" };
string max = string.Empty;
studName.FindMaxEx(ref max);
Console.WriteLine(max);