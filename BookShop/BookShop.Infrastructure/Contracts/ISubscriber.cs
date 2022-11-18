namespace BookShop.Infrastructure.Contracts
{
    public interface ISubscriber<T>
    {
        void Notify(T item);
    }
}
