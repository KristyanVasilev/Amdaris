namespace Data.ForSchool.Bags
{
    public class Bagpack : Bag
    {
        public Bagpack(string name, decimal price, string color, string manufacturer, int capacity, Type type)
            : base(name, price, color, manufacturer, capacity, type)
        {
        }
    }
}
