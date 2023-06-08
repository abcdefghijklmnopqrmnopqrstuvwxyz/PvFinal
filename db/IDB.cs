namespace Chess.db
{
    internal interface IDB<T>
    {
        /*
         * Interface for all users. Currecntly impleneted only 1 user, 
         * but in future there can be more account types like (premium, admin, etc...).
         * So we ensure all user classes contains these methods.
         */

        void Login(T element);

        void Register(T element);

    }
}