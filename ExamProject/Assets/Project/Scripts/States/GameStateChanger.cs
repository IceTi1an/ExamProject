namespace Game
{
    public class GameStateChanger
    {
        private GameState _currentGameState;
        public void ChangeState(GameState gameState)
        {
            _currentGameState?.Exit();

            _currentGameState = gameState;
            _currentGameState.gameStateChanger = this;
            _currentGameState.Enter();
        }
    }
}

