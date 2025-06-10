namespace SingletonPattern
{
    // Klasa generyczna (szablon)
    public class Singleton<T>
        where T : new() // T - ogranicza zbiór typów do tych, które posiadają bezparametryczny publiczny konstruktor
    {
        private static object _syncLock = new object();

        private static T _instance;

        public static T Instance
        {
            get
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new T();
                }

                return _instance;
            }
        }
    }
}
