namespace Chess.db
{
    internal interface IDB<T>
    {
        bool Login(T element);

        bool Register(T element);

    }
}