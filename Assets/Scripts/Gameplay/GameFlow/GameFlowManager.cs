using TriviaGame.Gameplay.Countdown;
using TriviaGame.Global;
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

        public void AnswerQuestion(int answer, int correctAnswer, string levelID)
        {
            _countdown.StopCountdown();
            if (answer == correctAnswer)
            {
                EventManager.TriggerEvent("FinishLevel", levelID);

            }
            else
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}

