Console.WriteLine("Plese input a target sentence...\n (You can input any character)");
var userInput = Console.ReadLine();
string result = new(new char[userInput?.Length ?? 0]);

var iterationNum = 0;

while (Iterate(userInput ?? string.Empty, ref result)){ Console.WriteLine($"Iteration ({iterationNum++}):\nInput: {userInput}, Result: {result}"); }
Console.WriteLine($"Iteration ({iterationNum++}):\nInput: {userInput}, Result: {result}");

bool Iterate(string input, ref string output)
{
    var randomChars = new List<char>();

    for (var i = 0; i < input?.Length; i++)
        randomChars.Add(output[i] != input[i] ? Convert.ToChar(Random.Shared.Next(32, char.MaxValue)) : output[i]);

    output = new(randomChars.ToArray());

    return output != input;
}
