    public class StateManager
    {
        #region "Singleton"

        private static StateManager _instance;

        #endregion

        #region Members

        private int _lives;
        private int _score;

        #endregion

        private StateManager()
        {
            _lives = 3;
        }

        public int Lives
        {
            get => _lives;
            set => _lives = value;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public static StateManager Instance => _instance ?? (_instance = new StateManager());
    }