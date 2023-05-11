namespace CarHandlerApp.Models
{
    public class AttemptsSingleton
    {
        private static AttemptsSingleton? _instance = null;
        private int _attempts = 0;

        private AttemptsSingleton() { }

        public static AttemptsSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AttemptsSingleton();
                }
                return _instance;
            }
        }

        public int Attempts
        {
            get { return _attempts; }
            set { _attempts = value; }
        }
    }   
}
