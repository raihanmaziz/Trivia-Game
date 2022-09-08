using TriviaGame.Gameplay.Countdown;
using TriviaGame.Global;
using TriviaGame.Global.Database;
using TriviaGame.Global.Save;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Gameplay.GameFlow
{
    public class GameFlowManager : MonoBehaviour
    {
        [SerializeField] private CountdownManager _countdown;
        private string[] _listLevel;
        private SaveData _saveData;
        private DatabaseController _database;

        private void Awake()
        {
            _saveData = SaveData.saveInstance;
            _database = DatabaseController.databaseInstance;
        }

        private void Start()
        {
            _listLevel = _database.GetLevelList(_saveData.selectedPack);
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
                SceneManager.LoadScene("Level");
            }
            else
            {
                SceneManager.LoadScene("Level");
            }
        }
    }
}

