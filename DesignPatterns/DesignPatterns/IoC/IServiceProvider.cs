namespace IoC
{
    public interface IServiceProvider
    {
        T GetService<T>();
    }
}
