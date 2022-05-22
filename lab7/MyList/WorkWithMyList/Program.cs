using MyList;

var listNumb = new MyList<int>() { 5 };
var listStr = new MyList<string>() { "дом" };

StrListInfo();
Console.WriteLine();
IntListInfo();

listNumb.Add(4);
listNumb.Add(4);
listNumb.Add(9);
listNumb.Add(4);

IntListInfo();

foreach (var item in listNumb)
{
    Console.WriteLine("foreach int: " + item);
}

listStr.AddFirst("гараж");
listStr.Add("машина");

foreach (var item in listStr)
{
    Console.WriteLine("foreach str: " + item);
}

listStr.Insert(1, "каша");

listStr[2] = "самолёт";
listStr.RemoveAt(3);
StrListInfo();

string join = string.Join(", ", listStr);

Console.WriteLine("join str: " + join);
Console.WriteLine("max: " + listNumb.Max());
Console.WriteLine("max: " + listNumb.Min());

#region info
void StrListInfo()
{
    Console.WriteLine("list int: " + listStr);
    Console.WriteLine("Count: " + listStr!.Count);
    Console.WriteLine("first element: " + listStr.First());
    Console.WriteLine("last element: " + listStr.Last());
}

void IntListInfo()
{
    Console.WriteLine("list int: " + listNumb);
    Console.WriteLine("Count: " + listNumb!.Count);
    Console.WriteLine("first element: " + listNumb.First());
    Console.WriteLine("last element: " + listNumb.Last());
}
#endregion