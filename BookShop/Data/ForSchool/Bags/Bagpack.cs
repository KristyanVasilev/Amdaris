namespace Data.ForSchool.Bags
{
    public class Bagpack : Bag
    {
        public Bagpack(int id, decimal price, string name, string color, string manufacturer, int capacity, Type type) 
            : base(id, price, name, color, manufacturer, capacity, type)
        {
        }
    }
}
