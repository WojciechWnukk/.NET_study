// See https://aka.ms/new-console-template for more information
UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();

List<Fruit> fruits = new List<Fruit>();
for (int i = 0; i <= 15; i++)
{
    var fruit = Fruit.Create();
    fruits.Add(fruit);
}
Console.WriteLine("All fruits:");
foreach (var fruit in fruits.Where(f => f.IsSweet==true).OrderByDescending(f => f.Price))
{
    Console.WriteLine(fruit);
}

Console.WriteLine($"Current USD course: {UsdCourse.Current.ToString("C2")}");