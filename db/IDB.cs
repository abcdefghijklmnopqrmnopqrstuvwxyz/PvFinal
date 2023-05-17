namespace Chess.db
{
    internal interface IDB<T>
    {
        void Login(T element);

        void Register(T element);

    }
}