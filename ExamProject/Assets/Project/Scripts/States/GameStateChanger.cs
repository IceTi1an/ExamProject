using UnityEngine;

namespace Game
{
    public enum DayType { Usual, NewYear }
    public class GameStateChanger : MonoBehaviour
    {
        private GameState _currentGameState;

        public static DayType dayType = DayType.Usual;
        public void ChangeState(GameState gameState)
        {
            _currentGameState?.Exit();

            _currentGameState = gameState;
            _currentGameState.gameStateChanger = this;
            _currentGameState.Enter();
        }
    }
}

