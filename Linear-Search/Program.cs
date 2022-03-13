using System.Collections;
using LinearSearch;

int[] myArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

LinearCollection<int> linearCollection = new LinearCollection<int>(myArr);

linearCollection.Add(5345);

var findResult = linearCollection.Find(5345);
Console.WriteLine("Value is: " + findResult?.Value + "\nIndex is: " + findResult?.Index + "\n");

if (findResult == null) return;

findResult?.Reset();

while(true)
{
    Console.WriteLine("Value is: " + findResult?.Value + "\nIndex is: " + findResult?.Index + "\n");
    if ((bool)!findResult?.Next()) return;
}
