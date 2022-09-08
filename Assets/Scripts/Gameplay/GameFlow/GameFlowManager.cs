using TriviaGame.Gameplay.Countdown;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Gameplay.GameFlow
{
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField] private CountdownManager _countdown;

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _countdown.StartCountdown();
        }

        public void Timeout()
        {
            SceneManager.LoadScene("Level");
        }
    }
}

