// See https://aka.ms/new-console-template for more information
/*
for(int i=1; i<101; i++) {
    if(i%3==0 && i%5==0) {
        Console.Write("FizzBuzz\n");
    } else if(i%3==0) {
        Console.Write("Fizz\n");
    } else if(i%5==0) {
        Console.Write("Buzz\n");
    } else {
        Console.Write(i + "\n");
    }
}
*/
using Lab1;
using System.Data;
using System.Text.Json;

List<HighScore> highScores;
const string FileName = "highscores.json";
if (File.Exists(FileName))
{
    highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
}
else
{
    highScores = new List<HighScore>();
}

var rand = new Random();
var value = rand.Next(1, 101);
Console.WriteLine("Guess a number between 1 and 100");
int guess = Convert.ToInt32(Console.ReadLine());
int guesses = 1;
while (guess != value)
{
    if (guess > value)
    {
        Console.WriteLine("You guessed too high!");
    }
    else if (guess < value)
    {
        Console.WriteLine("You guessed too low!");
    }
    guess = Convert.ToInt32(Console.ReadLine());
    guesses++;

}
Console.WriteLine("You guessed correctly in " + guesses + " guesses!\n Enter your name: ");
string name = Console.ReadLine()!;
var hs = new HighScore { Name = name, Trials = guesses };
highScores.Add(hs);
File.WriteAllText(FileName, JsonSerializer.Serialize(highScores));

for (int x = 0; x <= 100; x++)
{
    foreach (var item in highScores)
    {

        if (item.Trials == x)
        {
            Console.WriteLine($"{item.Name} -- {item.Trials} prób");
        }
    }
}
