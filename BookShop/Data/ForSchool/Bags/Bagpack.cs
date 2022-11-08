using Data.ForSchool.Bags.Enums;

namespace Data.ForSchool.Bags
{
    public class Bagpack : Bag
    {
        public Bagpack(int id, decimal price, string name, string color, string manufacturer, int capacity, Gender gender)
            : base(id, price, name, color, manufacturer, capacity, gender)
        {
        }
    }
}
