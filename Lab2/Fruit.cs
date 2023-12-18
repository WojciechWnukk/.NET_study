class Fruit
{
    public string Name { get; set; }
    public bool IsSweet { get; set; }
    public double Price { get; set; }
    public double UsdPrice => Price / UsdCourse.Current;
    public override string ToString()
    {
        return $"Fruit={Name}, IsSweet={IsSweet}, Price={Price.ToString("C2")}, UsdPrice={/*UsdPrice.ToString("C2")*/MyFormatter.FormatUsdPrice(UsdPrice)}";
    }
    public static Fruit Create()
    {
        Random r = new Random();
        string[] names = new string[] { "Apple", "Banana", "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };
        return new Fruit
        {
            Name = names[r.Next(names.Length)],
            IsSweet = r.NextDouble() > 0.5,
            Price = r.NextDouble() * 10
        };
    }
}


